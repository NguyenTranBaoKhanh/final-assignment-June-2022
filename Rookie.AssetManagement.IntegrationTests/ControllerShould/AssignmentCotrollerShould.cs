using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts.Dtos.Assignment;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using Rookie.AssetManagement.IntegrationTests.Common;
using Rookie.AssetManagement.IntegrationTests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.IntegrationTests.ControllerShould
{
    public class AssignmentCotrollerShould : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly IMapper _mapper;
        private readonly BaseRepository<Assignment> _assignmentRepository;
        private readonly BaseRepository<Asset> _assetRepository;
        private readonly BaseRepository<Request> _requestRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly AssignmentService _assignmentService;
        private readonly AssignmentController _assignmentController;
        private readonly UserManager<User> _userManager;
        public AssignmentCotrollerShould(SqliteInMemoryFixture fixture)
        {
            fixture.CreateDatabase();
            _dbContext = fixture.Context;
            _userManager = fixture.UserManager;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();
            _assignmentRepository = new BaseRepository<Assignment>(_dbContext);
            _assetRepository = new BaseRepository<Asset>(_dbContext);
            _requestRepository = new BaseRepository<Request>(_dbContext);

            // mock getMe
            var user = AssignmentArrangeData.GetUser();
            var mockSecurityService = new Mock<ISecurityService>();
            
            mockSecurityService.Setup(service => service.GetMe()).Returns(Task.FromResult(user));

            _assignmentService = new AssignmentService(_mapper, _dbContext, _assignmentRepository, _assetRepository, _requestRepository,  mockSecurityService.Object);
            _assignmentController = new AssignmentController(_assignmentService);

            UserArrangeData.InitUsersData(_dbContext, _userManager);
            AssetArrangeData.InitAssetData(_dbContext);
            AssignmentArrangeData.InitAsignmentsData(_dbContext);
            CategoryArrangeData.InitCategoryData(_dbContext);
            RequestArrangeDate.InitRequestsData(_dbContext);
        }

        [Fact]
        public async Task Add_Assignment_Success()
        {
            // Arrange
            var countAssignmentBeforeTest = _dbContext.Assignments.Count();
            var assignment = new AssignmentCreateDto() {
                AssetCode = "LA00100",
                StaffCode = "SD1001",
                AssignedDate = DateTime.Now,
                Note = "Assign asset for Mr.Thong"
            };

            // Act
            var result = await _assignmentController.AddAssignment(assignment);
            var countAssignmentAfterTest = _dbContext.Assignments.Count();

            //Assert
            countAssignmentAfterTest.Should().BeGreaterThan(countAssignmentBeforeTest);
            Assert.IsType<OkObjectResult>(result);
            Assert.True(countAssignmentAfterTest > countAssignmentBeforeTest);
        }

        [Fact]
        public async Task Add_Assignment_NotFound()
        {
            // Arrange
            var countAssignmentBeforeTest = _dbContext.Assignments.Count();
            var assignment = new AssignmentCreateDto()
            {
                AssetCode = "LA00100",
                StaffCode = "SD0000",
                AssignedDate = DateTime.Now,
                Note = "Assign Asset for Unknow"
            };

            //Act
            var result = await _assignmentController.AddAssignment(assignment);
            var countAssignmentAfterTest = _dbContext.Assignments.Count();

            // Assert
            countAssignmentAfterTest.Should().Equals(countAssignmentBeforeTest);
            Assert.IsType<NotFoundResult>(result);
            Assert.Equal(countAssignmentAfterTest, countAssignmentBeforeTest);
        }

        [Fact]
        public async Task Update_Waiting_Returning_Request_Success()
        {
            int assignmentId = 105;
            var countRequestBeforeTest = _dbContext.Requests.Count();
            var result = await _assignmentController.UpdateWaitingReturning(assignmentId) as OkObjectResult;
            var countRequestAfterTest = _dbContext.Requests.Count();

            AssignmentDto assignmentResult = (AssignmentDto)result.Value;

            var assignmentStateTest = assignmentResult.AssignmentState;
            assignmentStateTest.Should().NotBeNull();
            assignmentStateTest.Should().Equals(AssignmentStateEnumDto.WaitingReturn);
            countRequestAfterTest.Should().BeGreaterThan(countRequestBeforeTest);

            Assert.IsType<OkObjectResult>(result);
            Assert.True(countRequestAfterTest > countRequestBeforeTest);
            Assert.Equal(AssignmentStateEnumDto.WaitingReturn, assignmentStateTest);
        }

        [Fact]
        public async Task Get_Assignments_By_User_Success()
        {
            // Arrange
            var assignmentRequest = new AssignmentQueryCriteriaDto()
            {
                Limit = 5,
                Page = 1,
            };

            // Act
            var result = await _assignmentController.GetAssignmentByUser(assignmentRequest, new System.Threading.CancellationToken());

            // Should
            result.Should().NotBeNull();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_Waiting_Returning_Request_NotFound()
        {
            int assignmentId = 100;
            var countRequestBeforeTest = _dbContext.Requests.Count();
            var result = await _assignmentController.UpdateWaitingReturning(assignmentId) as NotFoundResult;
            var countRequestAfterTest = _dbContext.Requests.Count();
            countRequestAfterTest.Should().Equals(countRequestBeforeTest);
            Assert.Equal(countRequestBeforeTest, countRequestAfterTest);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAssignment_ReturnOk()
        {
            //arrange
            var assignmentRequest = new AssignmentRequestDto
            {
                Limit = 5,
                Page = 1,
            };
            //act
            var result = await _assignmentController.GetAssignment(assignmentRequest);
            //should
            result.Should().NotBeNull();
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetAssignment_ReturnNull()
        {
            //arrange
            var assignmentRequest = new AssignmentRequestDto
            {
            };
            //act
            var result = await _assignmentController.GetAssignment(assignmentRequest);
            //should
            result.Should().NotBeNull();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Accept_Respond_ReturnOk()
        {
            int assignmentId = 100;
            var result = await _assignmentController.AcceptResponsd(assignmentId) as OkObjectResult;

            AssignmentDto assignmentResult = (AssignmentDto)result.Value;

            var assignmentStateTest = assignmentResult.AssignmentState;
            assignmentStateTest.Should().NotBeNull();
            assignmentStateTest.Should().Equals(AssignmentStateEnumDto.Accepted);

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(AssignmentStateEnumDto.Accepted, assignmentStateTest);
        }

        [Fact]
        public async Task Accept_Respond_ReturnNotFound()
        {
            int assignmentId = 1000;
            var result = await _assignmentController.AcceptResponsd(assignmentId) as NotFoundResult;
            result.Should().NotBeNull();
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Decline_Respond_ReturnOk()
        {
            int assignmentId = 100;
            var result = await _assignmentController.DeclineResponsd(assignmentId) as OkObjectResult;

            AssignmentDto assignmentResult = (AssignmentDto)result.Value;

            var assignmentStateTest = assignmentResult.AssignmentState;
            assignmentStateTest.Should().NotBeNull();
            assignmentStateTest.Should().Equals(AssignmentStateEnumDto.Declined);

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(AssignmentStateEnumDto.Declined, assignmentStateTest);
        }

        [Fact]
        public async Task Decline_Respond_ReturnNotFound()
        {
            int assignmentId = 1000;
            var result = await _assignmentController.DeclineResponsd(assignmentId) as NotFoundResult;
            result.Should().NotBeNull();
            Assert.IsType<NotFoundResult>(result);
        }


    }
}
