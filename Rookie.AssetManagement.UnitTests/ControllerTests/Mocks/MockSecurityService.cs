using System;
using Moq;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts.Dtos.User;

namespace Rookie.AssetManagement.UnitTests.ControllerTests.Mocks
{
    public class MockSecurityService : Mock<ISecurityService>
    {
        public MockSecurityService LoginUserAsyncOK(UserLoginResponse respone)
        {
            Setup(x => x.LoginUserAsync(It.IsAny<UserLoginRequest>())).ReturnsAsync(respone);
            return this;
        }
        public MockSecurityService LoginUserAsyncNotFound()
        {
            Setup(x => x.LoginUserAsync(It.IsAny<UserLoginRequest>())).Throws(new Exception());
            return this;
        }
        public MockSecurityService LoginUserAsyncForbid(UserLoginResponse respone)
        {
            Setup(x => x.LoginUserAsync(It.IsAny<UserLoginRequest>())).Throws(new Exception());
            return this;
        }
        public MockSecurityService MockChangePassword_ReturnsOk(UserLoginResponse respone)
        {
            Setup(x => x.ChangePassword(It.IsAny<ChangePasswordRequest>())).ReturnsAsync(respone);
            return this;
        }
        public MockSecurityService MockChangePasswordFirst_ReturnsOk(UserLoginResponse respone)
        {
            Setup(x => x.ChangePasswordFirstLogin(It.IsAny<string>())).ReturnsAsync(respone);
            return this;
        }
        public MockSecurityService MockChangePassword_BadRequest()
        {
            Setup(x => x.ChangePassword(It.IsAny<ChangePasswordRequest>())).Throws(new Exception());
            return this;
        }
    }
}

