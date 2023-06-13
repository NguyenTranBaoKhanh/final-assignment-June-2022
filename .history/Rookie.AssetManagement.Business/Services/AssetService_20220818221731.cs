using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business.Extensions;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.Asset;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Entities.Enums;


namespace Rookie.AssetManagement.Business.Services
{
    public class AssetService : IAssetService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IBaseRepository<Asset> _assetRepository;

        public AssetService(ApplicationDbContext context, IMapper mapper, IBaseRepository<Asset> assetRepository)
        {
            _context = context;
            _mapper = mapper;
            _assetRepository = assetRepository;

        }

        public async Task<AssetDto> AddAsync(AssetCreateDto assetRequest)
        {
            Ensure.Any.IsNotNull(assetRequest);
            //username
            string assetCode = GenerateAssetCode(assetRequest.CategoryID);
            var catogory = _context.Categories.FirstOrDefault(c => c.CategoryID == assetRequest.CategoryID);
            var newAsset = _mapper.Map<Asset>(assetRequest);
            newAsset.AssetCode = assetCode;
            newAsset.LocationID = assetRequest.LocationID;
            newAsset.InstalledDay = assetRequest.InstalledDay.AddDays(1);
            _context.Assets.Add(newAsset);
            _context.SaveChanges();
            
            var assetDto = _mapper.Map<AssetDto>(newAsset);
            assetDto.InstalledDay = assetDto.InstalledDay.AddDays(-1);
            assetDto.CategoryName = catogory.CategoryName;
            return assetDto;
        }

        public async Task<PagedResult<AssetDto>> GetPaginationAsync(AssetRequestDto request)
        {
            var result = (from a in _context.Assets
                          join c in _context.Categories on a.CategoryID equals c.CategoryID
                          join l in _context.Locations on a.LocationID equals l.LocationID
                          join u in _context.Users on l.LocationID equals u.LocationID
                          join ur in _context.UserRoles on u.Id equals ur.UserId
                          join r in _context.Roles on ur.RoleId equals r.Id
                          where !u.LockoutEnabled && u.LocationID == request.LocationId && !a.IsDeleted
                          select new AssetDto
                          {
                              AssetCode = a.AssetCode,
                              AssetName = a.AssetName,
                              AssetState = (Contracts.Dtos.EnumDtos.AssetStateEnumDto)a.AssetState,
                              Specification = a.Specification,
                              CategoryName = c.CategoryName,
                              CategoryID = c.CategoryID,
                              InstalledDay = a.InstalledDay,
                              LocationID = u.LocationID,
                          }).AsSplitQuery();
            var ass = _context.Assets.Where(a => !a.IsDeleted).Include(a=>a.Location).Include(a => a.Category);

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                result = result.Where(a => (a.AssetName).Contains(request.Keyword) || (a.AssetCode).Contains(request.Keyword));
            }
            if (request.Category != null && request.Category.Count > 0)
            {
                result = result.Where(a => request.Category.Contains(a.CategoryID));
            }
            if (request.AssetState != null && request.AssetState.Count > 0)
            {
                result = result.Where(a => request.AssetState.Contains((int)a.AssetState));
            }

            result = result.Where(a => (a.LocationID == request.LocationId)).Distinct();
            int totalRow = await result.CountAsync();

            request.Limit = request.Limit > 0 ? request.Limit : 10;
            request.Page = request.Page > (int)Math.Ceiling((double)totalRow / request.Limit) ? (int)Math.Ceiling((double)totalRow / request.Limit) : request.Page;
            request.Page = request.Page > 0 ? request.Page : 1;
            if (request.SortBy == null)
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssetCode);
                else result = result.OrderByDescending(a => a.AssetCode);
            }
            else if (request.SortBy == "AssetName")
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssetName);
                else result = result.OrderByDescending(a => a.AssetName);
            }
            else if (request.SortBy == "AssetState")
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssetState);
                else result = result.OrderByDescending(a => a.AssetState);
            }
            else if (request.SortBy == "Category")
            {
                if (request.Ascending) result = result.OrderBy(a => a.CategoryID);
                else result = result.OrderByDescending(a => a.CategoryID);
            }
            else
            {
                if (request.Ascending) result = result.OrderBy(a => a.AssetCode);
                else result = result.OrderByDescending(a => a.AssetCode);
            }
            result = result.Paged(request.Page, request.Limit);

            var data = await result.ToListAsync();

            var pagedResult = new PagedResult<AssetDto>()
            {
                TotalRecords = totalRow,
                Items = data,
                Page = request.Page,
                Limit = request.Limit
            };

            return pagedResult;

        }

        public async Task<AssetDto> GetByIdAsync(string assetCode)
        {
            var asset = await _assetRepository.Entities
                .Where(a => a.AssetCode == assetCode)
                .FirstOrDefaultAsync();

            if (asset == null)
            {
                throw new NotFoundException($"Asset {assetCode} is not found");
            }
            var category = _context.Categories.Find(asset.CategoryID);
            var assetDto = _mapper.Map<AssetDto>(asset);
            assetDto.InstalledDay = assetDto.InstalledDay.AddDays(-1);
            assetDto.CategoryName = category.CategoryName;
            return assetDto;
        }

        private string GenerateAssetCode(string categoryId)
        {
            var lastAssetCode = _assetRepository.Entities
                .Where(x => x.AssetCode.StartsWith(categoryId))
                .OrderBy(x => x.AssetCode)
                .Select(x => x.AssetCode).LastOrDefault();

            if (lastAssetCode == null)
            {
                return $"{categoryId}000001";
            }
            var subCode = Int32.Parse(lastAssetCode.Substring(2)) + 1;
            string stringCode =  subCode.ToString();
            return categoryId + string.Concat(Enumerable.Repeat("0", 6 - stringCode.Length)) + stringCode;
        }

        public async Task<AssetDto> UpdateAsync(string assetCode, AssetUpdateDto assetRequest)
        {
            Ensure.Any.IsNotNull(assetRequest);
            //username
            var asset = _context.Assets.Include(x => x.Category).FirstOrDefault(asset => asset.AssetCode == assetCode);
            if (asset == null)
                return null;
            asset.AssetName = assetRequest.AssetName;
            asset.InstalledDay = assetRequest.InstalledDay.AddDays(1);
            asset.AssetState = (AssetState)assetRequest.AssetState;
            asset.Specification = assetRequest.Specification;
            asset.IsDeleted = false;
            _context.Assets.Update(asset);
            _context.SaveChanges();
            var assetDto = _mapper.Map<AssetDto>(asset);
            assetDto.CategoryName = asset.Category.CategoryName;
            assetDto.InstalledDay = assetDto.InstalledDay.AddDays(-1);
            return assetDto;
        }

        public async Task<AssetDto> RemoveAsync(string assetCode)
        {
            var asset = _context.Assets.FirstOrDefault(asset => asset.AssetCode == assetCode);
            asset.IsDeleted = true;
            _context.Assets.Update(asset);
            _context.SaveChanges();
            var assetDto = _mapper.Map<AssetDto>(asset);
            return assetDto;
        }
    }
}

