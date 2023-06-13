using System;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Contracts.RequestModels;
using Rookie.AssetManagement.Controllers;
using System.Collections.Generic;
using Xunit;
using Rookie.AssetManagement.Contracts.Dtos.Asset;
using Rookie.AssetManagement.UnitTests.ControllerTests.Mocks;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Rookie.AssetManagement.UnitTests.ControllerTests
{
    public class AssetControllerTest
    {
        [Fact]
        public async void GetAllPaging_ReturnsOk()
        {
            var mockData = new PagedResult<AssetDto>()
            {
                Items = new List<AssetDto>(),
                Page = 1,
                Limit = 1,
                TotalRecords = 1,
            };

            var mockAssetService = new MockAssetService().MockGetAssetsPaging(mockData);

            var controller = new AssetController(mockAssetService.Object);

            OkObjectResult result = await controller.GetAssetList(new AssetRequestDto()) as OkObjectResult;

            var content = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<PagedResult<AssetDto>>(content);
        }
        [Fact]
        public async void GetAllPaging_ReturnsBadRequest()
        {
            var mockAssetService = new MockAssetService().MockGetAssetPaging_ThrowException();

            var controller = new AssetController(mockAssetService.Object);

            var result = await controller.GetAssetList(new AssetRequestDto() { });

            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public async void UpdateAsset_ReturnsOk()
        {
            var assetDto = new AssetDto()
            {
                AssetName = "GMC",
                Specification = "ABC",
                InstalledDay = DateTime.Now,
                CategoryID = "LA",
                AssetState = (AssetStateEnumDto)2,
                LocationID = "HCM"
            };
            var mockAssetService = new MockAssetService().MockUpdateAsset(assetDto);

            var controller = new AssetController(mockAssetService.Object);

            var result = await controller.UpdateAsset("LA000001", new AssetUpdateDto());

            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async void UpdateAsset_ReturnsNotFound()
        {
            var assetDto = new AssetDto()
            {
                AssetName = "GMC",
                Specification = "ABC",
                InstalledDay = DateTime.Now,
                CategoryID = "LA",
                AssetState = (AssetStateEnumDto)2,
                LocationID = "HCM"
            };
            var mockAssetService = new MockAssetService().MockUpdateAsset(null);

            var controller = new AssetController(mockAssetService.Object);

            var result = await controller.UpdateAsset("LA00001", new AssetUpdateDto());

            Assert.IsType<NotFoundResult>( result.Result );
        }
        [Fact]
        public async void AddAsset_ReturnOk()
        {
            var assetAdd = new AssetDto()
            {
                AssetName = "canh",
                Specification = " cute",
                InstalledDay = DateTime.Now,
                CategoryID = "LA",
                AssetState = (AssetStateEnumDto)3,
                LocationID = "HN"
            };
            var mockAssetService = new MockAssetService().MockAddAsset_ReturnOK(assetAdd);

            var controller = new AssetController(mockAssetService.Object);

            OkObjectResult result = await controller.AddAsset(new AssetCreateDto()) as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void GetAssetByID_ReturnOk()
        {
            var assetDto = new AssetDto()
            {
                AssetCode = "LA000001"
            };
            var mockAssetService = new MockAssetService().MockGetAssetById_ReturnOK(assetDto);

            var controller = new AssetController(mockAssetService.Object);

            OkObjectResult result = await controller.GetAssetById("LA000001") as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void MockDelete_ReturnOk()
        {
            var mockData = new AssetDto()
            {
                AssetCode = "LA00001",

            };

            var mockAssetService = new MockAssetService().MockDelete_ReturnOk(mockData);
            var controller = new AssetController(mockAssetService.Object);
            OkObjectResult result = await controller.RemoveAsset(mockData.AssetCode) as OkObjectResult;
            var content = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<AssetDto>(content);

        }

        [Fact]
        public async void MockDelete_ReturnNull()
        {
            var mockData = new AssetDto()
            {
                AssetCode = "LA00001",

            };

            var mockAssetService = new MockAssetService().MockDelete_ReturnNotFound();
            var controller = new AssetController(mockAssetService.Object);
            NotFoundObjectResult result = await controller.RemoveAsset(mockData.AssetCode) as NotFoundObjectResult;
            Assert.Null(result);

        }

    }
}

