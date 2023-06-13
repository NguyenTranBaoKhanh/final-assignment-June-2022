using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.DataAccessor.Entities;
using System.Threading.Tasks;
using Rookie.AssetManagement.Contracts.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts.Constants;
using System.Text.RegularExpressions;

namespace Rookie.AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        private readonly ISecurityService _securityService;
        public SecurityController( ISecurityService securityService)
        {
            _securityService = securityService;

        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest loginRequest)
        {
            if (Regex.IsMatch(loginRequest.UserName, "[A-Z]"))
            {
                return NotFound();
            }
            var user = await _securityService.LoginUserAsync(loginRequest);
            int disableId = 0;
            if(user == null)
            {
                return NotFound();
            } 
            if(user.Id == disableId)
            {
                return Forbid();
            }
            return Ok(user);
        }

        [HttpGet("getMe")]
        [Authorize]
        public async Task<UserLoginResponse> GetMe()
        {
            var userResponseDto = await _securityService.GetMe();
            return userResponseDto;
        }

        [HttpPost("changePasswordFirstLogin")]
        [Authorize]
        public async Task<IActionResult> ChangePasswordFirstLogin([FromBody] ChangePasswordFirstLogin changePasswordFirstLogin)
        {
            var user = await _securityService.ChangePasswordFirstLogin(changePasswordFirstLogin.NewPassword);
            return Ok(user);
        }

        [HttpPost("changePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordRequest changePasswordRequest)
        {
            var user = await _securityService.ChangePassword(changePasswordRequest);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

    }

    
}
