using Rookie.AssetManagement.Contracts.Dtos.User;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public static class AssignmentArrangeData
    {
        public static List<Assignment> GetSeedAssignment()
        {
            return new List<Assignment>
            {
                new Assignment()
                {
                    Id = 100,
                    AssetCode = "LA100000",
                    Asset = new Asset()
                    {
                        AssetCode = "LA100000",
                        AssetName = "Laptop 1",
                        CategoryID = "LA",
                        AssetState = AssetState.Available,
                        IsDeleted = false,
                    }
                },
                new Assignment()
                {
                    Id = 101,
                    AssetCode = "LA100001",
                    Asset = new Asset()
                    {
                        AssetCode = "LA100001",
                        AssetName = "Laptop 2",
                        CategoryID = "LA",
                        AssetState = AssetState.Available,
                        IsDeleted = false,
                    }
                },
                new Assignment()
                {
                    Id = 102,
                    AssetCode = "LA100002",
                    Asset = new Asset()
                    {
                        AssetCode = "LA100002",
                        AssetName = "Laptop 3",
                        AssetState = AssetState.Available,
                        CategoryID = "LA",
                        IsDeleted = false,
                    }
                },
                new Assignment()
                {
                    Id = 103,
                    AssetCode = "LA100003",
                    Asset = new Asset()
                    {
                        AssetCode = "LA100003",
                        AssetName = "Laptop 4",
                        CategoryID = "LA",
                        AssetState = AssetState.Available,
                        IsDeleted = false,
                    }
                },
                new Assignment()
                {
                    Id = 104,
                    AssetCode = "LA100004",
                    Asset = new Asset()
                    {
                        AssetCode = "LA100004",
                        AssetName = "Laptop 1",
                        CategoryID = "LA",
                        AssetState = AssetState.Available,
                        IsDeleted = false,
                    }
                },
                new Assignment()
                {
                    Id = 105,
                    AssetCode = "LA100005",
                    Asset = new Asset()
                    {
                        AssetCode = "LA100005",
                        AssetName = "Laptop 6",
                        CategoryID = "LA",
                        AssetState = AssetState.Available,
                        IsDeleted = false,
                    }
                }
            };
        }

        public static UserLoginResponse GetUser()
        {
            return new UserLoginResponse()
            {
                Id = 1,
                FullName = "Nguyen Hoang THong",
                UserName = "thongnh",
                Location = "HCM",
                Role = "Admin",
                StaffCode = "SD0001",
                Token = "My token",
                IsLogged = true
            };
        } 
        public static void InitAsignmentsData(ApplicationDbContext dbContext)
        {
            var assignments = GetSeedAssignment();
            dbContext.Assignments.AddRange(assignments);
            dbContext.SaveChanges();
        }
    }
}
