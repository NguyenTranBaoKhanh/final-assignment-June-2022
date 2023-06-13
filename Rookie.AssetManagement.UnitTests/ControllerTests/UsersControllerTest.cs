using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.Asset;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Contracts.RequestModels;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.UnitTests.ControllerTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.ControllerTests
{
    public class UsersControllerTest
    {
        [Fact]
        public async void CreateUser_ReturnOk()
        {
            var userDto = new UserDto()
            {
                StaffCode = "SD0012",
                FirstName = "van",
                LastName = "nguyen ngoc gia van"
            };
            var mockUserService = new MockUserService().AddUserOk(userDto);

            var controller = new UserController(mockUserService.Object);

            var result = await controller.AddUser(new UserCreateDto());

            Assert.IsType<ActionResult<UserDto>>(result);
        }

        [Fact]
        public async void GetUserById_ReturnOk()
        {
            var userInfoDto = new UserInfoDto()
            {
                StaffCode = "SD0001",
                FirstName = "minh",
                LastName = "tran nhat",
            };
            var mockUserService = new MockUserService().GetUserByIdOk(userInfoDto);

            var controller = new UserController(mockUserService.Object);

            var result = await controller.GetUserById("1");

            Assert.IsType<ActionResult<UserInfoDto>>(result);
        }
        [Fact]
        public async void GetAllPaging_ReturnsOk()
        {
            var mockData = new PagedResult<UserDto>()
            {
                Items = new List<UserDto>(),
                Page = 1,
                Limit = 1,
                TotalRecords = 1,
            };

            var mockUserService = new MockUserService().MockGetUsersPaging(mockData);

            var controller = new UserController(mockUserService.Object);

            OkObjectResult result = await controller.GetUserList(new ViewUserRequest()) as OkObjectResult;

            var content = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<PagedResult<UserDto>>(content);
        }
        [Fact]
        public async void GetAllPaging_ReturnsBadRequest()
        {
            var mockUserService = new MockUserService().MockGetUsersPaging_ThrowException();

            var controller = new UserController(mockUserService.Object);

            var result = await controller.GetUserList(new ViewUserRequest() { });

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void GetByStaffCodeAsync_ReturnsOk()
        {
            var mockData = new UserDto()
            {
                Id = 1,
                FirstName = "Thong",
                LastName = "Nguyen hoang",
                UserName = "thongnh",
                Gender = "F",
            };

            var mockUserService = new MockUserService().MockGetByStaffCodeAsync(mockData);

            var controller = new UserController(mockUserService.Object);

            OkObjectResult result = await controller.Get("SD1001") as OkObjectResult;

            var content = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<UserDto>(content);
        }

        [Fact]
        public async void GetByStaffCodeAsync_ReturnsBadRequest()
        {
            var mockUserService = new MockUserService().MockGetByStaffCodeAsync_ThrowException();

            var controller = new UserController(mockUserService.Object);

            var result = await controller.Get("SD10001");

            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public async void UpdateAsync()
        {
            var userUpdate = new UserDto()
            {
                Id = 3,
                FirstName = "Thong",
                LastName = "Nguyen hoang",
                UserName = "thongnh",
                Gender = "F",
            };
            var mockUserService = new MockUserService().MockUserUpdate(1, userUpdate);


            var controller = new UserController(mockUserService.Object);

            var result = await controller.UpdateUser(3, new UserUpdateDto());

            Assert.NotNull(result);
        }

        [Fact]
        public async void MockDeleteAsync_ReturnOk()
        {
            var mockData = new UserDto()
            {
                Id = 1,
                FirstName = "Thong",
                LastName = "Nguyen hoang",
                UserName = "thongnh",
                Gender = "F",
                JoinedDate = DateTime.Now,
                Type = "1",
                Location = "HCM",
                IsLogged = false,
            };

            var mockUserService = new MockUserService().MockDelete_ReturnOk(mockData);

            var controller = new UserController(mockUserService.Object);

            var result = await controller.RemoveUser(id: 1);
            var content = result.Result as OkObjectResult;
            var StatusCode = content.StatusCode;

            Assert.Equal((int)HttpStatusCode.OK, StatusCode);
        }

        [Fact]
        public async void MockDeleteAsync_ReturnNull()
        {
            var mockData = new UserDto()
            {
                Id = 1,
                FirstName = "Thong",
                LastName = "Nguyen hoang",
                UserName = "thongnh",
                Gender = "F",
                JoinedDate = DateTime.Now,
                Type = "1",
                Location = "HCM",
                IsLogged = false,
            };

            var mockUserService = new MockUserService().MockDelete_ReturnNotFound();

            var controller = new UserController(mockUserService.Object);

            var result = await controller.RemoveUser(id: 1);
            var content = result.Result as NotFoundResult;

            Assert.Null(content);
        }
    }


}
