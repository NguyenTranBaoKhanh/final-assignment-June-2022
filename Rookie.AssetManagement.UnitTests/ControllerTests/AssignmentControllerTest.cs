using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.Assignment;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.UnitTests.ControllerTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.ControllerTests
{
    public class AssignmentControllerTest
    {
        [Fact]
        public async void AddAssignment_ReturnOK()
        {
            // Arrange  
            var assignmentCreateDto = new AssignmentCreateDto()
            {
                StaffCode = "SD0001",
                AssetCode = "LA000001",
                AssignedDate = DateTime.Now,
                Note = "Assign macbook M1 for Mr.Thong"
            };

            var assignmentDto = new AssignmentDto()
            {
                AssignedByUser = "SD0001",
                AssignedToUser = "SD0002",
                AssetName = "Macbook 1",
                AssetCode = "LA000001",
                AssignedDate = DateTime.Now,
                Note = "Assign macbook M1 for Mr.Thong"

            };

            var mockAssignmentService = new MockAssignmentService().MockAdddAssginment_Return_Ok(assignmentDto);

            var controller = new AssignmentController(mockAssignmentService.Object);

            // Act
            OkObjectResult result = await controller.AddAssignment(assignmentCreateDto) as OkObjectResult;
            var content = result.Value;

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<AssignmentDto>(content);
        }

        [Fact]
        public async void AddAssignment_Return_Same_Value_With_Input()
        {
            // Arrange  
            var assignmentCreateDto = new AssignmentCreateDto()
            {
                StaffCode = "SD0002",
                AssetCode = "LA000001",
                AssignedDate = DateTime.Now,
                Note = "Assign macbook M1 for Mr.Thong"
            };

            var assignmentDto = new AssignmentDto()
            {
                AssignedByUser = "SD0001",
                AssignedToUser = "SD0002",
                AssetName = "Macbook 1",
                AssetCode = "LA000001",
                AssignedDate = DateTime.Now,
                Note = "Assign macbook M1 for Mr.Thong"

            };

            var mockAssignmentService = new MockAssignmentService().MockAdddAssginment_Return_Ok(assignmentDto);

            var controller = new AssignmentController(mockAssignmentService.Object);

            // Act
            var result = await controller.AddAssignment(assignmentCreateDto) as OkObjectResult;
            AssignmentDto assignmentResult = (AssignmentDto)result.Value;

            // Assert
            Assert.Equal(assignmentCreateDto.StaffCode, assignmentResult.AssignedToUser);
            Assert.Equal(assignmentCreateDto.AssetCode, assignmentResult.AssetCode);
            Assert.Equal(assignmentCreateDto.AssignedDate.Date, assignmentResult.AssignedDate.Date);
            Assert.Equal(assignmentCreateDto.Note, assignmentResult.Note);
        }

        [Fact]
        public async void AddAssignment_Return_NotFound()
        {
            // Arrange  
            var assignmentCreateDto = new AssignmentCreateDto()
            {
                StaffCode = "SD00000",
                AssetCode = "LA00000",
                AssignedDate = DateTime.Now,
                Note = "Assign macbook M1 for Mr.Thong"
            };

            var mockAssignmentService = new MockAssignmentService().MockAdddAssginment_Return_Null();

            var controller = new AssignmentController(mockAssignmentService.Object);

            // Act
            var result = await controller.AddAssignment(assignmentCreateDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetAssignment_ReturnsOk()
        {
            var mockData = new PagedResult<AssignmentDto>()
            {
                Items = new List<AssignmentDto>(),
                Page = 1,
                Limit = 1,
                TotalRecords = 1,
            };
            var mockAssignmentService = new MockAssignmentService().MockGetAssignmentPaging(mockData);
            var controller = new AssignmentController(mockAssignmentService.Object);
            OkObjectResult result = await controller.GetAssignment(new AssignmentRequestDto()) as OkObjectResult;
            var content = result.Value;
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<PagedResult<AssignmentDto>>(content);

        }
        [Fact]
        public async void GetAssignment_ReturnsBadRequest()
        {
            var mockAssignmentService = new MockAssignmentService().MockGetAssignmentPaging_ThrowException();
            var controller = new AssignmentController(mockAssignmentService.Object);
            var result = await controller.GetAssignment(new AssignmentRequestDto() { });
            Assert.IsType<BadRequestResult>(result);

        }
        [Fact]
        public async void MockDelete_ReturnOk()
        {
            var mockData = new AssignmentDto()
            {
                Id = 1,

            };

            var mockAssignmentService = new MockAssignmentService().MockDelete_ReturnOk(mockData);
            var controller = new AssignmentController(mockAssignmentService.Object);
            OkObjectResult result = await controller.RemoveAssignment(mockData.Id) as OkObjectResult;
            var content = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<AssignmentDto>(content);

        }

        [Fact]
        public async void MockDelete_ReturnNull()
        {
            var mockData = new AssignmentDto()
            {
                Id = 1,

            };

            var mockAssignmentService = new MockAssignmentService().MockDelete_ReturnNotFound();
            var controller = new AssignmentController(mockAssignmentService.Object);
            NotFoundObjectResult result = await controller.RemoveAssignment(mockData.Id) as NotFoundObjectResult;
            Assert.Null(result);

        }

        [Fact]
        public async void GetUserAssignment_ReturnOk()
        {
            var mockData = new PagedResponseModel<AssignmentDto>()
            {
                Items = new List<AssignmentDto>(),
                CurrentPage = 1,
                TotalItems = 5,
            };
            var mockAssignmentService = new MockAssignmentService().MockGetUserAssignment_ReturnOk(mockData);
            var controller = new AssignmentController(mockAssignmentService.Object);
            OkObjectResult result = await controller.GetAssignmentByUser(new AssignmentQueryCriteriaDto(), new CancellationToken()) as OkObjectResult;
            var content = result.Value;
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<PagedResponseModel<AssignmentDto>>(content);
        }

        [Fact]
        public async void GetUserAssignment_ReturnNull()
        {

            var mockAssignmentService = new MockAssignmentService().MockGetUserAssignment_ReturnNull();
            var controller = new AssignmentController(mockAssignmentService.Object);
            OkObjectResult result = await controller.GetAssignmentByUser(new AssignmentQueryCriteriaDto(), new CancellationToken()) as OkObjectResult;
            var content = result.Value;
            Assert.Null(content);
        }

        [Fact]
        public async void MockUpdateWaitingReturningRequest_ReturnOk()
        {
            var assignmentDto = new AssignmentDto()
            {
                AssignedByUser = "SD0001",
                AssignedToUser = "SD0002",
                AssetName = "Macbook 1",
                AssetCode = "LA000001",
                AssignedDate = DateTime.Now,
                Note = "Assign macbook M1 for Gia Van"

            };
            var mockAssignmentService = new MockAssignmentService()
                .MockUpdateWaitingReturningRequest_ReturnOk(assignmentDto);

            var controller = new AssignmentController(mockAssignmentService.Object);
           
            var result = await controller.UpdateWaitingReturning(50);

            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public async void MockUpdateWaitingReturningRequest_Return_NotFound()
        {
            var mockAssignmentService = new MockAssignmentService()
                .MockUpdateWaitingReturningRequest_Return_NotFound();

            var controller = new AssignmentController(mockAssignmentService.Object);

            var result = await controller.UpdateWaitingReturning(1000);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
