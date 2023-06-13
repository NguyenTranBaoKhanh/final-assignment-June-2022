using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts.Dtos.Asset;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.IntegrationTests.Common;
using Rookie.AssetManagement.IntegrationTests.TestData;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
namespace Rookie.AssetManagement.IntegrationTests.ControllerShould
{
	public class AssetControllerShould : IClassFixture<SqliteInMemoryFixture>
	{
		private readonly IMapper _mapper;
		private readonly ApplicationDbContext _context;
		private readonly IBaseRepository<Asset> _assetRepository;
		private readonly AssetService _assetService;
		private readonly AssetController _assetController;
		public AssetControllerShould(SqliteInMemoryFixture fixture)
		{
			fixture.CreateDatabase();
			_context = fixture.Context;
			var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
			_mapper = config.CreateMapper();
			_assetRepository = new BaseRepository<Asset>(_context);

			var user = AssetArrangeData.GetUser();
			var mockSecurityService = new Mock<ISecurityService>();

			mockSecurityService.Setup(service => service.GetMe()).Returns(Task.FromResult(user));

			_assetService = new AssetService(_context, _mapper, _assetRepository);
			_assetController = new AssetController(_assetService);
		}

		[Fact]

		public async Task Add_Asset_Success()
		{
			var countAssetBeforeTest = _context.Assets.Count();
			var newAsset = new AssetCreateDto()
			{
				AssetName = "Macbook",
				Specification = "Ram 16GB, SSD 256GB",
				InstalledDay = DateTime.Now,
				CategoryID = "LA",
				LocationID = "HCM",
				AssetState = (AssetStateEnumDto) 1
			};

			var result = await _assetController.AddAsset(newAsset);
			var countAssetAfterTest = _context.Assets.Count();
			countAssetAfterTest.Should().BeGreaterThan(countAssetBeforeTest);

			Assert.IsType<OkObjectResult>(result);
			Assert.True(countAssetAfterTest > countAssetBeforeTest);
		}

		[Fact]
		public async Task GetListAsset_ReturnOk()
		{
			//arrange
			var assetRequest = new AssetRequestDto
			{
				Limit = 5,
				Page = 1,
			};
			//act
			var result = await _assetController.GetAssetList(assetRequest);
			result.Should().NotBeNull();
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task GetListAsset_ReturnNull()
		{
			//arrange
			var assetRequest = new AssetRequestDto
			{
			};
			//act
			var result = await _assetController.GetAssetList(assetRequest);
			//should
			result.Should().NotBeNull();
			Assert.IsType<OkObjectResult>(result);
		}
	}
}

