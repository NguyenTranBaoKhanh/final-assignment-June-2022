using System;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Contracts.Dtos.User;
using Rookie.AssetManagement.Contracts.RequestModels;
using Rookie.AssetManagement.Controllers;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.ControllerTests.Mocks
{
    public class SecurityControllerTest
    {
        [Fact]
        public async void Login_ReturnsOk()
        {
            var userLoginRequest = new UserLoginRequest()
            {
                UserName = "thongnh",
                Password = "Abcd123!"

            };
            var userLoginRespone = new UserLoginResponse();
            var mocksecurityService = new MockSecurityService().LoginUserAsyncOK(userLoginRespone);
            var controller = new SecurityController(mocksecurityService.Object);
            var result = await controller.Login(userLoginRequest);
            Assert.IsType<ForbidResult>(result);
        }
        [Fact]
        public async void ChangePasswordFirstLogin_ReturnsOk()
        {
            var userLoginResponese = new UserLoginResponse()
            {
                Id = 1,
                Token = "asdsd",
                UserName = "canhhm",
                Role = "STAFF",
                FullName = "Hominhcanh",
                StaffCode = "asds",
                Location = "HN",
                IsLogged = true

            };
            var mocksecurityService = new MockSecurityService().MockChangePasswordFirst_ReturnsOk(userLoginResponese);

            var controller = new SecurityController(mocksecurityService.Object);
            var result = await controller.ChangePasswordFirstLogin(new ChangePasswordFirstLogin()
            {
                NewPassword = "minhcanhbinhdai"
            });
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async void ChangePassword_ReturnOk()
        {
            var userLoginResponese = new UserLoginResponse()
            {
                Id = 1,
                Token = "asdsd",
                UserName = "thonghm",
                Role = "STAFF",
                FullName = "Hominhcanh",
                StaffCode = "asds",
                Location = "HN",
                IsLogged = false

            };
            var mocksecurityService = new MockSecurityService().MockChangePassword_ReturnsOk(userLoginResponese);

            var controller = new SecurityController(mocksecurityService.Object);
            var result = await controller.ChangePassword(new ChangePasswordRequest()
            {
                OldPassword = "Abcd1234!",
                NewPassword = "minhcanhbinhdai"
            });
            Assert.IsType<OkObjectResult>(result);
        }



    }
}

