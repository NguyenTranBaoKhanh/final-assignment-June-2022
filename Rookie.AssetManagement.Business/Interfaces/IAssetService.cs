using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.Asset;


namespace Rookie.AssetManagement.Business.Interfaces
{
    public interface IAssetService
    {
        Task<AssetDto> AddAsync(AssetCreateDto assetRequest);
        Task<AssetDto> UpdateAsync(string assetCode,AssetUpdateDto assetRequest);
        Task<AssetDto> RemoveAsync(string assetCode);
        Task<AssetDto> GetByIdAsync(string assetCode);
        Task<PagedResult<AssetDto>> GetPaginationAsync(AssetRequestDto request);

    }
}

