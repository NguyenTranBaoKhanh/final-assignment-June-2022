using AutoMapper;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business.Extensions;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.Assignment;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Entities.Enums;
using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IBaseRepository<Assignment> _assignmentRepository;
        private readonly IBaseRepository<Asset> _assetRepository;
        private readonly IBaseRepository<Request> _requestRepository;
        private readonly ISecurityService _securityService;

        public AssignmentService(
            IMapper mapper,
            ApplicationDbContext context,
            IBaseRepository<Assignment> assignmentRepository,
            IBaseRepository<Asset> assetRepository,
            IBaseRepository<Request> requestRepository,
            ISecurityService securityService
        )
        {
            _mapper = mapper;
            _context = context;
            _assignmentRepository = assignmentRepository;
            _assetRepository = assetRepository;
            _requestRepository = requestRepository;
            _securityService = securityService;
        }

        public async Task<AssignmentDto> AddAsync(AssignmentCreateDto assignmentRequest)
        {
            var userAssignedTo = _context.Users.FirstOrDefault(u => u.StaffCode == assignmentRequest.StaffCode);
            var asset = _context.Assets.FirstOrDefault(a => a.AssetCode == assignmentRequest.AssetCode);
            if (userAssignedTo == null || asset == null)
            {
                return null;
            }

            var userAssignByRequest = await _securityService.GetMe();
            var userAssignBy = _context.Users.Find(userAssignByRequest.Id);

            Ensure.Any.IsNotNull(assignmentRequest);
            var newAssignment = new Assignment()
            {
                AssignedToUser = userAssignedTo,
                AssignedByUser = userAssignBy,
                AssetCode = assignmentRequest.AssetCode,
                Note = assignmentRequest.Note,
                AssignedDate = assignmentRequest.AssignedDate,
                AssignmentState = DataAccessor.Enums.AssignmentState.Waiting,
            };

            await _assignmentRepository.Add(newAssignment);

            var assignmentDto = _mapper.Map<AssignmentDto>(newAssignment);
            assignmentDto.AssetName = asset.AssetName;
            assignmentDto.SpecifiCation = asset.Specification;
            return assignmentDto;
        }

        public async Task<PagedResponseModel<AssignmentDto>> FindByUser(AssignmentQueryCriteriaDto assignmentQuery, CancellationToken cancellationToken)
        {
            var userRequest = await _securityService.GetMe();
            var userAssignments = _context.Assignments
                        .Where(assignment => assignment.AssignedToUserId == userRequest.Id)
                        .Include(assignment => assignment.AssignedByUser)
                        .Include(Assignment => Assignment.AssignedToUser)
                        .Include(assignment => assignment.Asset)
                        .ThenInclude(asset => asset.Category)
                        .AsQueryable();

            userAssignments = AssignmentFilter(
                        userAssignments.Where(assignment =>
                            !assignment.IsDeleted &&
                            !assignment.AssignedByUser.LockoutEnabled &&
                            !assignment.AssignedToUser.LockoutEnabled &&
                            assignment.AssignmentState != AssignmentState.Declined &&
                            assignment.AssignedDate.Date <= DateTime.Now.Date),
                        assignmentQuery);

            var assignments = await userAssignments
                        .AsNoTracking()
                        .PaginateAsync(assignmentQuery, cancellationToken);

            if (assignmentQuery.SortColumn == "Category")
            {
                if (assignmentQuery.SortOrder == SortOrderEnumDto.Decsending)
                {
                    assignments.Items = assignments.Items.OrderByDescending(a => a.Asset.Category.CategoryName).ToList();
                }
                else
                {
                    assignments.Items = assignments.Items.OrderBy(a => a.Asset.Category.CategoryName).ToList();
                }
            }

            if (assignmentQuery.SortColumn == "AssetName")
            {
                if (assignmentQuery.SortOrder == SortOrderEnumDto.Decsending)
                {
                    assignments.Items = assignments.Items.OrderByDescending(a => a.Asset.AssetName).ToList();
                }
                else
                {
                    assignments.Items = assignments.Items.OrderBy(a => a.Asset.AssetName).ToList();
                }
            }

            var assignmentsDto = _mapper.Map<IEnumerable<AssignmentDto>>(assignments.Items);

            return new PagedResponseModel<AssignmentDto>
            {
                CurrentPage = assignments.CurrentPage,
                TotalPages = assignments.TotalPages,
                TotalItems = assignments.TotalItems,
                Items = assignmentsDto
            };

        }


        public Task<AssignmentDto> GetByIdAsync(string assetCode)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<AssignmentDto>> GetPaginationAsync(AssignmentRequestDto request)
        {
            var result = (from a in _context.Assignments
                          join ut in _context.Users on a.AssignedToUserId equals ut.Id
                          join ub in _context.Users on a.AssignedByUserId equals ub.Id
                          join asset in _context.Assets on a.AssetCode equals asset.AssetCode
                          join c in _context.Categories on asset.CategoryID equals c.CategoryID
                          join ur in _context.UserRoles on ub.Id equals ur.UserId
                          join r in _context.Roles on ur.RoleId equals r.Id
                          where !ut.LockoutEnabled &&
                            ub.LocationID == request.LocationId &&
                            !asset.IsDeleted &&
                            !a.IsDeleted &&
                            !ub.LockoutEnabled &&
                            (a.AssignmentState == DataAccessor.Enums.AssignmentState.Accepted || a.AssignmentState == DataAccessor.Enums.AssignmentState.Waiting)
                          select new AssignmentDto
                          {
                              Id = a.Id,
                              AssetCode = a.AssetCode,
                              AssetName = asset.AssetName,
                              SpecifiCation = asset.Specification,
                              AssignedToUser = ut.UserName,
                              AssignedByUser = ub.UserName,
                              AssignedDate = a.AssignedDate,
                              AssignmentState = (AssignmentStateEnumDto)a.AssignmentState,
                              Note = a.Note,
                              LocationId = ub.LocationID,
                              FullName = ut.LastName + " " + ut.FirstName

                          }).AsSplitQuery();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                result = result.Where(a => (a.AssetName).Contains(request.Keyword) || (a.AssetCode).Contains(request.Keyword) || (a.AssignedToUser).Contains(request.Keyword));
            }
            if (request.State != null && request.State.Count > 0)
            {
                result = result.Where(a => request.State.Contains((int)a.AssignmentState));
            }
            if (request.AssignDate != DateTime.MinValue)
            {
                result = result.Where(a => request.AssignDate.Date == a.AssignedDate.Date);
            }

            int totalRow = await result.CountAsync();

            request.Limit = request.Limit > 0 ? request.Limit : 10;
            request.Page = request.Page > (int)Math.Ceiling((double)totalRow / request.Limit) ? (int)Math.Ceiling((double)totalRow / request.Limit) : request.Page;
            request.Page = request.Page > 0 ? request.Page : 1;
            if (request.SortBy == null)
            {
                if (request.Ascending) result = result.OrderBy(a => a.Id);
                else result = result.OrderByDescending(a => a.Id);
            }
            else if (request.SortBy == "AssetName")
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssetName);
                else result = result.OrderByDescending(a => a.AssetName);
            }
            else if (request.SortBy == "AssetCode")
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssetCode);
                else result = result.OrderByDescending(a => a.AssetCode);
            }
            else if (request.SortBy == "AssignedTo")
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssignedToUser);
                else result = result.OrderByDescending(a => a.AssignedToUser);
            }
            else if (request.SortBy == "AssignedBy")
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssignedByUser);
                else result = result.OrderByDescending(a => a.AssignedByUser);
            }
            else if (request.SortBy == "AssignedDate")
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssignedDate);
                else result = result.OrderByDescending(a => a.AssignedDate);
            }
            else if (request.SortBy == "State")
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssignmentState);
                else result = result.OrderByDescending(a => a.AssignmentState);
            }
            else
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssetCode);
                else result = result.OrderByDescending(a => a.AssetCode);
            }
            result = result.Paged(request.Page, request.Limit);

            var data = await result.ToListAsync();

            var pagedResult = new PagedResult<AssignmentDto>()
            {
                TotalRecords = totalRow,
                Items = data,
                Page = request.Page,
                Limit = request.Limit
            };

            return pagedResult;
        }

        public async Task<AssignmentDto> RemoveAsync(int assignmentId)
        {
            var assignment = _context.Assignments.FirstOrDefault(assignment => assignment.Id == assignmentId);
            assignment.IsDeleted = true;
            _context.Assignments.Update(assignment);
            _context.SaveChanges();
            var assignmentDto = _mapper.Map<AssignmentDto>(assignment);
            return assignmentDto;
        }

        public async Task<AssignmentDto> UpdateAsync(int id, AssignmentUpdateDtoRequest assignmentRequest)
        {
            Ensure.Any.IsNotNull(assignmentRequest);
            var userIdAssignedTo = 0;
            if (assignmentRequest.StaffCode.Contains("SD"))
            {
                var userAssignedTo = _context.Users.FirstOrDefault(u => u.StaffCode == assignmentRequest.StaffCode);
                userIdAssignedTo = userAssignedTo.Id;
            }
            else
            {
                var userAssignedTo = _context.Users.FirstOrDefault(u => u.UserName == assignmentRequest.StaffCode);
                userIdAssignedTo = userAssignedTo.Id;
            }
            var assignment = _context.Assignments.Include(x => x.AssignedToUser).Include(x => x.Asset)
                .FirstOrDefault(assignmentTmp => assignmentTmp.Id == id);
            var asset = _context.Assets.FirstOrDefault(a => a.AssetCode == assignmentRequest.AssetCode);
            var userAssignedBy = _context.Users.FirstOrDefault(u => u.Id == assignment.AssignedByUserId);
            if (assignment == null)
                return null;

            assignment.AssignedToUserId = userIdAssignedTo;
            assignment.AssetCode = assignmentRequest.AssetCode;
            assignment.AssignedDate = assignmentRequest.AssignedDate.AddDays(-1);
            assignment.Note = assignmentRequest.Note;

            await _assignmentRepository.Update(assignment);
            await _context.SaveChangesAsync();

            var assignmentDto = _mapper.Map<AssignmentDto>(assignment);

            assignmentDto.AssetName = asset.AssetName;
            assignmentDto.AssignedDate = assignmentDto.AssignedDate.AddDays(-1);
            assignmentDto.AssignedToUser = assignment.AssignedToUser.UserName;
            assignmentDto.AssignedByUser = userAssignedBy.UserName;

            return assignmentDto;

        }

        #region assignmentFilter
        private IQueryable<Assignment> AssignmentFilter(IQueryable<Assignment> assignmentQuery, AssignmentQueryCriteriaDto assignmentQueryCriteria)
        {
            if (!string.IsNullOrEmpty(assignmentQueryCriteria.Search))
            {
                string keyword = assignmentQueryCriteria.Search;
                assignmentQuery = assignmentQuery
                    .Where(assignment => assignment.Asset.AssetName.Contains(keyword)
                        || assignment.Asset.AssetCode.Contains(keyword)
                        || assignment.AssignedToUser.UserName.Contains(keyword));
            }

            if (assignmentQueryCriteria.State != null &&
               assignmentQueryCriteria.State.Count() > 0)
            {
                assignmentQuery = assignmentQuery
                .Where(assignment => assignmentQueryCriteria.State
                .Any(a => a == ((int)assignment.AssignmentState)));
            }
            return assignmentQuery;
        }
        #endregion
        public async Task<AssignmentDto> UpdateWaitingReturningAsync(int id)
        {
            var assignment = await _assignmentRepository.Entities
                .Where(a => a.Id == id)
                .Include(assignment => assignment.AssignedByUser)
                .Include(assignment => assignment.AssignedToUser)
                .Include(assignment => assignment.Asset)
                .ThenInclude(asset => asset.Category)
                .FirstOrDefaultAsync();

            assignment.AssignmentState = AssignmentState.WaitingReturn;
          
            var getMe = await _securityService.GetMe();
            var request = new Request
            {
                AssignmentId = assignment.Id,
                RequestedUserId = getMe.Id,
                RequestState = RequestState.Waiting,
            };

            var requestByAssignmentId = _requestRepository.Entities.FirstOrDefault(a => a.AssignmentId == id);
            if (requestByAssignmentId != null)
            {
                return null;
            }

            await _assignmentRepository.Update(assignment);
            await _requestRepository.Add(request);
            var assignmentDto = _mapper.Map<AssignmentDto>(assignment);
            return assignmentDto;
        }

        public async Task<AssignmentDto> AcceptRespondAsync(int assignmentId)
        {
            var assignment = await _assignmentRepository.GetById(assignmentId);
            if (assignment != null)
            {

                assignment.AssignmentState = (AssignmentState)1;
                var asset = await _assetRepository.Entities.Where(x => x.AssetCode == assignment.AssetCode).FirstOrDefaultAsync();
                asset.AssetState = AssetState.Assigned;
                await _assignmentRepository.Update(assignment);
                await _assetRepository.Update(asset);
                var assignmentDto = _mapper.Map<AssignmentDto>(assignment);
                return assignmentDto;
            }
            else
            {
                //assignment = null
                return null;
            }
        }

        public async Task<AssignmentDto> DeclineRespondAsync(int assignmentId)
        {
            var assignment = await _assignmentRepository.GetById(assignmentId);
            if (assignment != null)
            {

                assignment.AssignmentState = AssignmentState.Declined;
                await _assignmentRepository.Update(assignment);
                var assignmentDto = _mapper.Map<AssignmentDto>(assignment);
                return assignmentDto;

            }
            else
            {
                //assignment = null
                return null;
            }
        }
    }
}
