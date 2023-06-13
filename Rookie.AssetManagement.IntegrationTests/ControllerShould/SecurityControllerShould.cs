using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.User;
using Rookie.AssetManagement.Controllers;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.IntegrationTests.Common;
using Rookie.AssetManagement.IntegrationTests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.IntegrationTests.ControllerShould
{
    public class SecurityControllerShould : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SecurityService _securityService;
        private readonly SignInManager<User> _signInManager;
        private readonly HttpContextAccessor _httpContext;
        private readonly SecurityController _controller;
        public SecurityControllerShould(SqliteInMemoryFixture fixture)
        {
            fixture.CreateDatabase();
            _dbContext = fixture.Context;
            _userManager = fixture.UserManager;
            _signInManager = fixture.SignInManager;
            _httpContext = new HttpContextAccessor();
            _securityService = new SecurityService(_userManager, _signInManager, _httpContext, _dbContext);
            _controller = new SecurityController(_securityService);
            UserArrangeData.InitUsersData(_dbContext, _userManager);
       
        }

        [Fact]
        public async Task Login_Success()
        {
            var users = _dbContext.Users.ToList();
            // Arrange
            UserLoginRequest loginRequest = new UserLoginRequest()
            {
                UserName = "thongnh",
                Password = "Abcd1234!"
            };

            //Act
            var result = await _controller.Login(loginRequest) as OkObjectResult;
            UserLoginResponse value = (UserLoginResponse)result.Value;
            // Assert
            result.Should().NotBeNull();
            value.Token.Should().NotBeNullOrEmpty();

            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(value.Token);
        }

        [Fact]
        public async Task Login_WrongPassword()
        {
            var users = _dbContext.Users.ToList();
            // Arrange
            UserLoginRequest loginRequest = new UserLoginRequest()
            {
                UserName = "thongnh",
                Password = "Wrongpassword!"
            };

            //Act
            var result = await _controller.Login(loginRequest);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Login_Forbid()
        {
            var users = _dbContext.Users.ToList();
            // Arrange
            UserLoginRequest loginRequest = new UserLoginRequest()
            {
                UserName = "nhattm1",
                Password = "Abcd1234!"
            };

            //Act
            var result = await _controller.Login(loginRequest);
            // Assert
            Assert.IsType<ForbidResult>(result);
        }

       
    }
}
