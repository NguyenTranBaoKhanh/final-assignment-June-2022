using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business.Extensions;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.RequestModels;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using EnsureThat;
using System.Text.RegularExpressions;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        private readonly IMapper _mapper;

        private readonly UserManager<User> _userManager;

        private readonly ApplicationDbContext _context;

        public UserService
        (   UserManager<User> userManager,
            IBaseRepository<User> userRepository,
            IMapper mapper,
            ApplicationDbContext context
        )
        {
            _userManager = userManager;
            _mapper = mapper;
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var result = await (from u in _context.Users
                                join ur in _context.UserRoles on u.Id equals ur.UserId
                                join r in _context.Roles on ur.RoleId equals r.Id
                                where u.DeletedDate == null
                                select new UserDto
                                {
                                    Id = u.Id,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    UserName = u.UserName,
                                    DateOfBirth = u.DateOfBirth,
                                    Gender = u.Gender,
                                    JoinedDate = u.JoinedDate,
                                    Type = r.Name,
                                    Location = u.LocationID,
                                    StaffCode = u.StaffCode
                                }).ToListAsync();
            return result;
        }

        public async Task<UserDto> GetByStaffCodeAsync(string staffCode)
        {
            var result = await (from u in _context.Users
                                join ur in _context.UserRoles on u.Id equals ur.UserId
                                join r in _context.Roles on ur.RoleId equals r.Id
                                where !u.LockoutEnabled && u.StaffCode == staffCode
                                select new UserDto
                                {
                                    Id = u.Id,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    UserName = u.UserName,
                                    DateOfBirth = u.DateOfBirth,
                                    Gender = u.Gender,
                                    JoinedDate = u.JoinedDate,
                                    Type = r.Name,
                                    Location = u.LocationID,
                                    StaffCode = u.StaffCode
                                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<PagedResult<UserDto>> GetPaginationAsync(ViewUserRequest request)
        {
            var result = (from u in _context.Users
                          join ur in _context.UserRoles on u.Id equals ur.UserId
                          join r in _context.Roles on ur.RoleId equals r.Id
                          where !u.LockoutEnabled && u.LocationID == request.LocationId
                          select new UserDto
                          {
                              Id = u.Id,
                              FirstName = u.FirstName,
                              LastName = u.LastName,
                              UserName = u.UserName,
                              DateOfBirth = u.DateOfBirth,
                              Gender = u.Gender,
                              JoinedDate = u.JoinedDate,
                              Type = r.Name,
                              Location = u.LocationID,
                              StaffCode = u.StaffCode
                          }).AsSplitQuery();
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                result = result.Where(p => (p.LastName + " " + p.FirstName).Contains(request.Keyword) || (p.StaffCode).Contains(request.Keyword));
            }
            if (request.Type != null && request.Type.Count > 0)
            {
                result = result.Where(p => request.Type.Contains(p.Type));
            }
    
            int totalRow = await result.CountAsync();

            request.Limit = request.Limit > 0 ? request.Limit : 10;
            request.Page = request.Page > (int)Math.Ceiling((double)totalRow / request.Limit) ? (int)Math.Ceiling((double)totalRow / request.Limit) : request.Page;
            request.Page = request.Page > 0 ? request.Page : 1;

            if (request.SortBy == null)
            {
                if (request.Ascending) result = result.OrderBy(x => x.Id);
                else result = result.OrderByDescending(x => x.Id);
            }
            else if (request.SortBy == "Name")
            {
                if (request.Ascending) result = result.OrderBy(x => (x.FirstName + " " + x.LastName));
                else result = result.OrderByDescending(x => (x.FirstName + " " + x.LastName));
            }
            else if (request.SortBy == "JoinedDate")
            {
                if (request.Ascending) result = result.OrderBy(x => x.JoinedDate);
                else result = result.OrderByDescending(x => x.JoinedDate);
            }
            else if (request.SortBy == "Type")
            {
                if (request.Ascending) result = result.OrderBy(x => x.Type);
                else result = result.OrderByDescending(x => x.Type);
            }
            else
            {
                if (request.Ascending) result = result.OrderBy(x => x.Id);
                else result = result.OrderByDescending(x => x.Id);
            }

            result = result.Paged(request.Page, request.Limit);

            var data = await result.ToListAsync();

            List<string> categoryNames = new List<string>();

            var pagedResult = new PagedResult<UserDto>()
            {
                TotalRecords = totalRow,
                Items = data,
                Page = request.Page,
                Limit = request.Limit
            };

            return pagedResult;
        }

        public async Task<UserDto> AddAsync(UserCreateDto userRequest)
        {
            Ensure.Any.IsNotNull(userRequest);
            //username
            var firstName = string.Join("", userRequest.FirstName.Split(' '));
            string username = RemoveVNString(firstName).ToLower() + ConvertLastName(RemoveVNString(userRequest.LastName));
            var listUsername = await _userRepository.Entities
                    .Select(x => Regex.Replace(x.UserName, @"[\d-]", string.Empty))
                    .ToListAsync();   

            var count =  listUsername.Count(x => x == username);
            username = count == 0 ? username : username + count;

            //staffcode
            var lastUser = await _userRepository.Entities
                .OrderByDescending(u => u.Id)
                .FirstOrDefaultAsync();

            var code = Int32.Parse(lastUser.StaffCode.Substring(2));
            var staffCode = GenerateStaffCode(code + 1);
            //password

            var password = username + "@" + userRequest.DateOfBirth.AddDays(1).ToString("ddMMyyyy");
        
            var newUser = _mapper.Map<User>(userRequest);
            newUser.UserName = username;
            newUser.StaffCode = staffCode;
            newUser.IsLogged = false;
            newUser.LocationID = userRequest.LocationID;
            newUser.DateOfBirth = userRequest.DateOfBirth.AddDays(1);
            newUser.JoinedDate = userRequest.JoinedDate.AddDays(1);

            await _userManager.CreateAsync(newUser, password);
            await _userManager.AddToRoleAsync(newUser, userRequest.Type);
            await _userManager.SetLockoutEnabledAsync(newUser, false);

            var userDto = _mapper.Map<UserDto>(newUser);
            userDto.DateOfBirth = userDto.DateOfBirth.AddDays(-1);
            userDto.JoinedDate = userDto.JoinedDate.AddDays(-1);
            userDto.Type = userRequest.Type;
            userDto.Location = userRequest.LocationID;
            return userDto;
        }

        public async Task<UserDto> UpdateAsync(int id, UserUpdateDto userRequest)
        {
            var currentUser = await _userManager.FindByIdAsync(id + "");
            if(currentUser == null)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(currentUser);
            var userRole = roles.FirstOrDefault();

            currentUser.DateOfBirth = userRequest.DateOfBirth.AddDays(1);
            currentUser.JoinedDate = userRequest.JoinedDate.AddDays(1);
            currentUser.Gender = userRequest.Gender;
            await _userManager.RemoveFromRoleAsync(currentUser, userRole);
            await _userManager.AddToRoleAsync(currentUser, userRequest.Type);
            
            await _userManager.UpdateAsync(currentUser);
            var userDto = _mapper.Map<UserDto>(currentUser);
            userDto.DateOfBirth = userDto.DateOfBirth.AddDays(-1);
            userDto.JoinedDate = userDto.JoinedDate.AddDays(-1);
            userDto.Type = userRequest.Type;
            userDto.Location = currentUser.LocationID;
            return userDto;
         }


        public async Task<UserDto> RemoveAsync(int id)
        {
            var currentUser = await _userManager.FindByIdAsync(id + "");
            if(currentUser == null)
            {
                return null;
            }
            await _userManager.SetLockoutEnabledAsync(currentUser, true);
            await _userManager.UpdateAsync(currentUser);
            var userDto = _mapper.Map<UserDto>(currentUser);
            return userDto;
        }

        public async Task<UserInfoDto> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException($"User {id} is not found");
            }

            var userInfoDto = _mapper.Map<UserInfoDto>(user);
            return userInfoDto;
        }

        private string ConvertLastName(string lastname)
        {
            lastname = lastname.ToLower();
            string[] subs = lastname.Split(' ');
            var result = "";
            foreach (var sub in subs)
            {
                result += sub[0];
            }
            return result;
        }

        private string GenerateStaffCode(int code)
        {
            string stringCode = code.ToString();
            return "SD" + string.Concat(Enumerable.Repeat("0", 4 - stringCode.Length)) + stringCode;
        }

        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };

        public static string RemoveVNString(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

       
    }
}
