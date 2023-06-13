using Microsoft.AspNetCore.Identity;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public static class UserArrangeData
    {
        public static List<User> GetSeedUserData()
        {
            var hasher = new PasswordHasher<User>();
            return new List<User>()
            {
                new User()
                {
                    UserName = "thongnh",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1001",
                    FirstName = "Thong",
                    LastName = "Nguyen Hoang",
                    Gender = "F",
                    IsLogged = true,
                    LocationID = "HCM",
                    DateOfBirth = DateTime.Parse("1989-08-27"),
                    JoinedDate = DateTime.Parse("2015-05-27"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7WE4A7DTOM5DETPA35OHKTOZMMYP"
                },
                new User()
                {
                    Id = 2,
                    UserName = "canhhm",
                    NormalizedUserName = "canhhm",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1002",
                    FirstName = "Canh",
                    LastName = "Ho Minh",
                    Gender = "M",
                    IsLogged = false,
                    LocationID = "HCM",
                    DateOfBirth = DateTime.Parse("1983-01-22"),
                    JoinedDate = DateTime.Parse("2018-05-19"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7RTOM5DETPA35OHKTOZMMYP"
                },
                new User()
                {
                    Id = 3,
                    UserName = "khanhntb",
                    NormalizedUserName = "khanhntb",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1003",
                    FirstName = "Khanh",
                    LastName = "Nguyen Tran Bao",
                    Gender = "F",
                    IsLogged = false,
                    LocationID = "HN",
                    DateOfBirth = DateTime.Parse("1987-02-11"),
                    JoinedDate = DateTime.Parse("2020-12-17"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7DTYM5DETPA35OHKTOZMMYP"
                },
                new User
                {
                    Id = 4,
                    UserName = "sangnv",
                    NormalizedUserName = "sangnv",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1005",
                    FirstName = "Sang",
                    LastName = "Nguyen Vinh",
                    Gender = "F",
                    IsLogged = false,
                    LocationID = "HN",
                    DateOfBirth = DateTime.Parse("1983-02-09"),
                    JoinedDate = DateTime.Parse("2018-04-14"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP"
                },
                new User
                {
                    Id = 5,
                    UserName = "nhattm",
                    NormalizedUserName = "nhattm",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1006",
                    FirstName = "Nhut",
                    LastName = "Tran Minh",
                    Gender = "M",
                    IsLogged = true,
                    LocationID = "HN",
                    DateOfBirth = DateTime.Parse("1980-08-11"),
                    JoinedDate = DateTime.Parse("2020-08-31"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4R7DTOM5DETPA35OHKTOZMMYP"
                },
                new User
                {
                    Id = 6,
                    UserName = "Vannng",
                    NormalizedUserName = "vannng",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    StaffCode = "SD1007",
                    FirstName = "Van",
                    LastName = "Nguyen Ngoc Gia",
                    Gender = "F",
                    IsLogged = true,
                    LocationID = "HN",
                    DateOfBirth = DateTime.Parse("1987-03-31"),
                    JoinedDate = DateTime.Parse("2016-04-03"),
                    CreatedDate = DateTime.Parse("2021-08-01"),
                    SecurityStamp = "NQLC7NG4A7DTOM5DHTPA35OHKTOZMMYP"
                },
            };
        }
        public static List<IdentityRole<int>> GetSeedRoleData()
        {
            return new List<IdentityRole<int>>()
            {
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "Staff",
                    NormalizedName = "STAFF"
                }
            };
        }
        public static List<IdentityUserRole<int>> GetSeedUserRoleData()
        {
            return new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>
                {
                    UserId = 1,
                    RoleId = 1,
                },
                new IdentityUserRole<int>
                {
                    UserId = 2,
                    RoleId = 1,
                },
                new IdentityUserRole<int>
                {
                    UserId = 3,
                    RoleId = 2,
                },
                new IdentityUserRole<int>
                {
                    UserId = 4,
                    RoleId = 2,
                },
            };
        }
        public static List<Location> GetSeedLocationData()
        {
            return new List<Location>()
            {
                new Location()
                {
                    LocationID = "HN",
                    LocationName = "Ha Noi"
                },
                 new Location()
                 {
                     LocationID = "HCM",
                     LocationName = "Ho Chi Minh"
                 }
            };
        }
        public static UserUpdateDto UpdateUser()
        {
            return new UserUpdateDto()
            {
                DateOfBirth = DateTime.Now,
                JoinedDate = DateTime.Now,
                Gender = "F",
                Type = "Admin"
            };
        }

        public static async void InitUsersData(ApplicationDbContext dbContext, UserManager<User> _userManager)
        {
            // Create User
            await _userManager.CreateAsync(new User()
            {
                UserName = "thongnh1",
                StaffCode = "SD1001",
                FirstName = "Thong",
                LastName = "Nguyen Hoang",
                Gender = "F",
                IsLogged = true,
                LocationID = "HCM",
                DateOfBirth = DateTime.Parse("1989-08-27"),
                JoinedDate = DateTime.Parse("2015-05-27"),
                CreatedDate = DateTime.Parse("2021-08-01"),
            }, "Abcd1234!");

            await _userManager.CreateAsync(new User()
            {
                UserName = "canhhm1",
                NormalizedUserName = "canhhm",
                StaffCode = "SD1002",
                FirstName = "Canh",
                LastName = "Ho Minh",
                Gender = "M",
                IsLogged = false,
                LocationID = "HCM",
                DateOfBirth = DateTime.Parse("1983-01-22"),
                JoinedDate = DateTime.Parse("2018-05-19"),
                CreatedDate = DateTime.Parse("2021-08-01"),
            }, "Abcd1234!");

            await _userManager.CreateAsync(new User()
            {
                UserName = "khanhntb1",
                NormalizedUserName = "khanhntb",
                StaffCode = "SD1003",
                FirstName = "Khanh",
                LastName = "Nguyen Tran Bao",
                Gender = "F",
                IsLogged = false,
                LocationID = "HN",
                DateOfBirth = DateTime.Parse("1987-02-11"),
                JoinedDate = DateTime.Parse("2020-12-17"),
                CreatedDate = DateTime.Parse("2021-08-01"),
            }, "Abcd1234!");

            await _userManager.CreateAsync(new User
            {
                UserName = "sangnv1",
                NormalizedUserName = "sangnv",
                StaffCode = "SD1005",
                FirstName = "Sang",
                LastName = "Nguyen Vinh",
                Gender = "F",
                IsLogged = false,
                LocationID = "HN",
                DateOfBirth = DateTime.Parse("1983-02-09"),
                JoinedDate = DateTime.Parse("2018-04-14"),
                CreatedDate = DateTime.Parse("2021-08-01"),
            }, "Abcd1234!");

            await _userManager.CreateAsync(new User
            {
                UserName = "nhattm1",
                NormalizedUserName = "nhattm",
                StaffCode = "SD1006",
                FirstName = "Nhut",
                LastName = "Tran Minh",
                Gender = "M",
                IsLogged = true,
                LocationID = "HN",
                DateOfBirth = DateTime.Parse("1980-08-11"),
                JoinedDate = DateTime.Parse("2020-08-31"),
                CreatedDate = DateTime.Parse("2021-08-01"),
            }, "Abcd1234!");

            // Enable for users 1-4
            var userEnabled1 = await _userManager.FindByIdAsync("1");
            await _userManager.SetLockoutEnabledAsync(userEnabled1, false);
            var userEnabled2 = await _userManager.FindByIdAsync("2");
            await _userManager.SetLockoutEnabledAsync(userEnabled2, false);
            var userEnabled3 = await _userManager.FindByIdAsync("3");
            await _userManager.SetLockoutEnabledAsync(userEnabled3, false);
            var userEnabled4 = await _userManager.FindByIdAsync("4");
            await _userManager.SetLockoutEnabledAsync(userEnabled4, false);
            // Disable user has id = 5
            var userDisabled = await _userManager.FindByIdAsync("5");
            await _userManager.SetLockoutEnabledAsync(userDisabled, true);
            dbContext.SaveChanges();
        }

        public static void CleanUpData(ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.SaveChanges();
        }

        
    }
}
