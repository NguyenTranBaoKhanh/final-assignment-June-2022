using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business.Extensions;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Contracts.Dtos.RequestDtos;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Services
{
    public class RequestService : IRequestService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IBaseRepository<Request> _requestRepository;
        private readonly ISecurityService _securityService;

        public RequestService(IMapper mapper, ApplicationDbContext context, IBaseRepository<Request> requestRepository, ISecurityService securityService)
        {
            _mapper = mapper;
            _context = context;
            _requestRepository = requestRepository;
            _securityService = securityService;
        }

        public Task<RequestDto> AddAsync(RequestCreateDto assignmentRequest)
        {
            throw new NotImplementedException();
        }

        public Task<RequestDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<RequestDto>> GetPaginationAsync(ReturnRequestDto request)
        {
            var result = (from a in _context.Requests
                          from ub in _context.Users.Where(ub => ub.Id == a.AcceptedUserId).DefaultIfEmpty()
                          join assi in _context.Assignments on a.AssignmentId equals assi.Id
                          join ut in _context.Users on a.RequestedUserId equals ut.Id
                          join asset in _context.Assets on assi.AssetCode equals asset.AssetCode
                          join ur in _context.UserRoles on ut.Id equals ur.UserId
                          join r in _context.Roles on ur.RoleId equals r.Id
                          where !ut.LockoutEnabled && ut.LocationID == request.LocationId && !a.IsDeleted
                          select new RequestDto
                          {
                              Id = a.Id,
                              AssetCode = asset.AssetCode,
                              AssetName = asset.AssetName,
                              AssignedDate = assi.AssignedDate,
                              RequestedBy = ut.UserName,
                              RequestState = (RequestStateEnumDto)a.RequestState,
                              ReturnedDate = a.ReturnedDate,
                              AcceptedBy = ub.UserName,

                          }).AsSplitQuery();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                result = result.Where(a => (a.AssetName).Contains(request.Keyword) || (a.AssetCode).Contains(request.Keyword) || (a.RequestedBy).Contains(request.Keyword)
                || (a.AcceptedBy).Contains(request.Keyword));
            }
            if (request.State != null && request.State.Count > 0)
            {
                result = result.Where(a => request.State.Contains((int)a.RequestState));
            }
            if (request.AssignedDate != DateTime.MinValue)
            {
                result = result.Where(a => request.AssignedDate.Date == a.AssignedDate.Date);
            }
            //result = result.Select(a => (a.AcceptedBy).Distinct);
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
            else if (request.SortBy == "RequestedBy")
            {
                if (request.Ascending) result = result.OrderBy(a => a.RequestedBy);
                else result = result.OrderByDescending(a => a.RequestedBy);
            }
            else if (request.SortBy == "AcceptedBy")
            {
                if (request.Ascending) result = result.OrderBy(a => a.AcceptedBy);
                else result = result.OrderByDescending(a => a.AcceptedBy);
            }
            else if (request.SortBy == "AssignedDate")
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssignedDate);
                else result = result.OrderByDescending(a => a.AssignedDate);
            }
            else if (request.SortBy == "State")
            {
                if (request.Ascending) result = result.OrderBy(a => a.RequestState);
                else result = result.OrderByDescending(a => a.RequestState);
            }
            else
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssetCode);
                else result = result.OrderByDescending(a => a.AssetCode);
            }
            result = result.Paged(request.Page, request.Limit);

            var data = await result.ToListAsync();

            var pagedResult = new PagedResult<RequestDto>()
            {
                TotalRecords = totalRow,
                Items = data,
                Page = request.Page,
                Limit = request.Limit
            };

            return pagedResult;
        }

        public Task<RequestDto> RemoveAsync(int requesttId)
        {
            throw new NotImplementedException();
        }

        public Task<RequestDto> UpdateAsync(RequestUpdateDto assetRequest)
        {
            throw new NotImplementedException();
        }
    }
}
