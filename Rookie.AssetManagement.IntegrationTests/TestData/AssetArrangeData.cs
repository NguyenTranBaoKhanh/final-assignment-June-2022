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
    public static class AssetArrangeData
    {
        public static List<Asset> GetSeedAssetData()
        {
            return new List<Asset>()
            {
                new Asset()
                {
                    AssetCode = "LA00100",
                    AssetName = "Laptop 1",
                    AssetState = AssetState.Available,
                    IsDeleted = false,
                    CategoryID = "LA",
                },
                new Asset()
                {
                    AssetCode = "LA00101",
                    AssetName = "Laptop 2",
                    AssetState = AssetState.Available,
                    IsDeleted = false,
                    CategoryID = "LA",
                 },
                new Asset()
                {
                    AssetCode = "LA001002",
                    AssetName = "Laptop 3",
                    AssetState = AssetState.Available,
                    IsDeleted = false,
                    CategoryID = "LA",
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
        public static void InitAssetData(ApplicationDbContext dbContext)
        {
            var assets = GetSeedAssetData();
            dbContext.AddRange(assets);
            dbContext.SaveChanges();
        }

    }
}
