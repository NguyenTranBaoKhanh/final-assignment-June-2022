using System;
using Moq;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.Asset;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Contracts.RequestModels;

namespace Rookie.AssetManagement.UnitTests.ControllerTests.Mocks
{
    public class MockAssetService : Mock<IAssetService>
    {
        public MockAssetService MockGetAssetsPaging(PagedResult<AssetDto> result)
        {
            Setup(x => x.GetPaginationAsync(It.IsAny<AssetRequestDto>())).ReturnsAsync(result);
            return this;
        }
        public MockAssetService MockGetAssetPaging_ThrowException()
        {
            Setup(x => x.GetPaginationAsync(It.IsAny<AssetRequestDto>())).Throws(new Exception());
            return this;
        }

        public MockAssetService MockUpdateAsset(AssetDto result)
        {
            Setup(x => x.UpdateAsync(It.IsAny<string>(), It.IsAny<AssetUpdateDto>())).ReturnsAsync(result);
            return this;
        }

        public MockAssetService MockUpdateAsset_ThrowException()
        {
            Setup(x => x.UpdateAsync(It.IsAny<string>(), It.IsAny<AssetUpdateDto>())).ReturnsAsync((AssetDto)null);
            return this;
        }
        public MockAssetService MockAddAsset_ReturnOK(AssetDto respone)
        {
            Setup(x => x.AddAsync(It.IsAny<AssetCreateDto>())).ReturnsAsync((respone));
            return this;
        }
        public MockAssetService MockGetAssetById_ReturnOK(AssetDto respone)
        {
            Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync((respone));
            return this;
        }

        public MockAssetService MockDelete_ReturnOk(AssetDto assetDto)
        {
            Setup(x => x.RemoveAsync(It.IsAny<string>())).ReturnsAsync(assetDto);
            return this;
        }

        public MockAssetService MockDelete_ReturnNotFound()
        {
            Setup(x => x.RemoveAsync(It.IsAny<string>())).ReturnsAsync((AssetDto)null);
            return this;
        }
    }
}

