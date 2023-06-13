using Rookie.AssetManagement.Contracts.Dtos.User;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public class RequestArrangeDate
    {
        public static List<Request> GetSeedRequest()
        {
            return new List<Request>
            {
                new Request()
                {
                    AssignmentId = 100,
                    RequestState =  RequestState.Waiting,
                },
                new Request()
                {
                    AssignmentId = 101,
                    RequestState =  RequestState.Waiting,
                },
                new Request()
                {
                    AssignmentId = 102,
                    RequestState =  RequestState.Waiting,
                },
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
        public static void InitRequestsData(ApplicationDbContext dbContext)
        {
            var requests = GetSeedRequest();
            dbContext.Requests.AddRange(requests);
            dbContext.SaveChanges();
        }
    }
}
