using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.RequestModels;
using System.Threading.Tasks;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Constants;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("All")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            //var products = _context.Products.ToList();
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{staffCode}")]
        public async Task<ActionResult> Get(string staffCode)
        {
            try
            {
                var user = await _userService.GetByStaffCodeAsync(staffCode);
                if (user == null)
                {
                    return NotFound($"User {staffCode} not exsit!");
                }
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("")]
        public async Task<ActionResult> GetUserList([FromQuery] ViewUserRequest request)
        {
            try
            {
                var data = await _userService.GetPaginationAsync(request);
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfoDto>> GetUserById(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<ActionResult<UserDto>> AddUser([FromBody] UserCreateDto userRequest)
        {
            var user = await _userService.AddAsync(userRequest);
            return Created(Endpoints.User, user);
        }

        [HttpPut("{id}")]
        //[AllowAnonymous]
        public async Task<ActionResult<UserDto>> UpdateUser([FromRoute] int id, [FromBody] UserUpdateDto userRequest)
        {
            var user = await _userService.UpdateAsync(id, userRequest);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> RemoveUser([FromRoute] int id)
        {
            var user = await _userService.RemoveAsync(id);
            return Ok(user);
        }
    }
}
