using Moq;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Contracts.RequestModels;
using System;

namespace Rookie.AssetManagement.UnitTests.ControllerTests.Mocks
{
    public class MockUserService : Mock<IUserService>
    {
        public MockUserService AddUserOk(UserDto response)
        {
            Setup(x => x.AddAsync(It.IsAny<UserCreateDto>())).ReturnsAsync(response);
            return this;
        }

        public MockUserService GetUserByIdOk(UserInfoDto response)
        {
            Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(response);
            return this;
        }
        public MockUserService MockGetUsersPaging(PagedResult<UserDto> result)
        {
            Setup(x => x.GetPaginationAsync(It.IsAny<ViewUserRequest>())).ReturnsAsync(result);

            return this;
        }
        public MockUserService MockGetUsersPaging_ThrowException()
        {
            Setup(x => x.GetPaginationAsync(It.IsAny<ViewUserRequest>())).Throws(new Exception());
            return this;
        }

        public MockUserService MockGetByStaffCodeAsync(UserDto result)
        {
            Setup(x => x.GetByStaffCodeAsync(It.IsAny<string>())).ReturnsAsync(result);
            return this;
        }

        public MockUserService MockGetByStaffCodeAsync_ThrowException()
        {
            Setup(x => x.GetByStaffCodeAsync(It.IsAny<string>())).Throws(new Exception());
            return this;
        }
        public MockUserService MockUserUpdate(int id, UserDto respone)
        {
            Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<UserUpdateDto>())).ReturnsAsync(respone);
            return this;
        }

        public MockUserService MockDelete_ReturnOk(UserDto userDto)
        {
            Setup(x => x.RemoveAsync(It.IsAny<int>())).ReturnsAsync(userDto);
            return this;
        }

        public MockUserService MockDelete_ReturnNotFound()
        {
            Setup(x => x.RemoveAsync(It.IsAny<int>())).ReturnsAsync((UserDto)null);
            return this;
        }
    }
}
