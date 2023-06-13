using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.Contracts.RequestModels;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> AddAsync(UserCreateDto request);
        Task<UserDto> UpdateAsync(int id, UserUpdateDto request);
        Task<UserInfoDto> GetByIdAsync(string id);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByStaffCodeAsync(string staffCode);
        Task<PagedResult<UserDto>> GetPaginationAsync(ViewUserRequest request);

        Task<UserDto> RemoveAsync(int id);
    }
}
