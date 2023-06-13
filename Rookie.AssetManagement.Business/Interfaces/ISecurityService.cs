using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Contracts.Dtos.User;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Interfaces
{
    public interface ISecurityService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest loginRequest);
        public Task<UserLoginResponse> GetMe();
        public Task<string> GenerateToken(User user);
        public Task<UserLoginResponse> ChangePasswordFirstLogin(string newPassword);
        public Task<UserLoginResponse> ChangePassword(ChangePasswordRequest changePasswordRequest);
    }
}
