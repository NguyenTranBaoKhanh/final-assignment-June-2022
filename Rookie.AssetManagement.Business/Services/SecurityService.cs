using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.User;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Services
{
    public class SecurityService : ISecurityService
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ApplicationDbContext _context;
        public SecurityService(UserManager<User> userManager, 
                SignInManager<User> signInManager,
                IHttpContextAccessor httpContext,
                ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext = httpContext;
            _context = context;
        }

        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.UserName);
            if (user == null)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var userRole = roles.FirstOrDefault();
            var userIsDisable = await _userManager.GetLockoutEnabledAsync(user);

            if (userIsDisable)
            {
                var userDisable = new UserLoginResponse() { Id = 0 };
                return userDisable;
            }

            var checkSuccess = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, lockoutOnFailure: false);
            if (checkSuccess.Succeeded)
            {
                var userResponse = new UserLoginResponse()
                {
                    Id = user.Id,
                    Token = await GenerateToken(user),
                    UserName = user.UserName,
                    Role = userRole,
                    FullName = $"{user.LastName} {user.FirstName}",
                    StaffCode = user.StaffCode,
                    Location = user.LocationID,
                    IsLogged = user.IsLogged,

                };
                return userResponse;
            }
            return null;
        }

        public async Task<UserLoginResponse> ChangePasswordFirstLogin(string newPassword)
        {
            var userFromClient = await GetMe();
            var hasher = new PasswordHasher<User>();
            var user = _context.Users.Find(userFromClient.Id);
            user.PasswordHash = hasher.HashPassword(null, newPassword);
            user.IsLogged = true;
            _context.SaveChanges();

            var roles = await _userManager.GetRolesAsync(user);
            var userRole = roles.FirstOrDefault();

            var userResponse = new UserLoginResponse()
            {
                Id = user.Id,
                Token = await GenerateToken(user),
                UserName = user.UserName,
                Role = userRole,
                FullName = $"{user.LastName} {user.FirstName}",
                StaffCode = user.StaffCode,
                Location = user.LocationID,
                IsLogged = true,

            };
            return userResponse;
        }

        public async Task<UserLoginResponse> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            var userFromClient = await GetMe();
            var id = userFromClient.Id;
            var user = await _userManager.FindByIdAsync(id + "");
            var hasher = new PasswordHasher<User>();
            var oldPassword = hasher.VerifyHashedPassword(user, user.PasswordHash, changePasswordRequest.OldPassword);
            var checkPassword = (oldPassword.ToString() == "Success") ? true : false;
            if (!checkPassword)
            {
                return null;
            }
            await _userManager.ChangePasswordAsync(user, changePasswordRequest.OldPassword, changePasswordRequest.NewPassword);
            var roles = await _userManager.GetRolesAsync(user);
            var userRole = roles.FirstOrDefault();

            var userResponse = new UserLoginResponse()
            {
                Id = user.Id,
                Token = await GenerateToken(user),
                UserName = user.UserName,
                Role = userRole,
                FullName = $"{user.LastName} {user.FirstName}",
                StaffCode = user.StaffCode,
                Location = user.LocationID,
                IsLogged = user.IsLogged,

            };
            return userResponse;
        }

        public async Task<string> GenerateToken(User user)
        {
            var tokenConfig = JWTSettings.Key;
            string fullName = $"{user.LastName} {user.FirstName}";

            var roles = await _userManager.GetRolesAsync(user);
            var userRole = roles.FirstOrDefault();

            List<Claim> claims = new List<Claim>()
            {
                new Claim(UserClaims.Id, user.Id.ToString()),
                new Claim(UserClaims.StaffCode, user.StaffCode),
                new Claim(UserClaims.FullName, fullName),
                new Claim(UserClaims.Location, user.LocationID),
                new Claim(UserClaims.UserName, user.UserName),
                new Claim(UserClaims.Role, userRole)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfig));
            var cerd = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: JWTSettings.Issuer,
                audience: JWTSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(JWTSettings.DurationInMinutes),
                signingCredentials: cerd);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<UserLoginResponse> GetMe()
        {
            if(_httpContext.HttpContext != null)
            {
                var userIdentity = _httpContext.HttpContext.User.Identity as ClaimsIdentity;
                var Id = int.Parse(userIdentity.FindFirst(UserClaims.Id).Value);
                return new UserLoginResponse()
                {
                    Id = Id,
                    StaffCode = userIdentity.FindFirst(UserClaims.StaffCode).Value,
                    FullName = userIdentity.FindFirst(UserClaims.FullName).Value,
                    Location = userIdentity.FindFirst(UserClaims.Location).Value,
                    UserName = userIdentity.FindFirst(UserClaims.UserName).Value,
                    Role = userIdentity.FindFirst(UserClaims.Role).Value,
                    IsLogged = _context.Users.Find(Id).IsLogged
                };     
            }
            return null;
        }
    }
}
