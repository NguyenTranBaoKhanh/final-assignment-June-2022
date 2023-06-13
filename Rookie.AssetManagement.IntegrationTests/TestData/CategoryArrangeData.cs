using System.Collections.Generic;
using Rookie.AssetManagement.DataAccessor.Data;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.IntegrationTests.TestData
{
    public static class CategoryArrangeData
    {
        public static List<Category> GetSeedCategoryData()
        {
            return new List<Category>()
            {
                new Category()
                {
                    CategoryID = "SP",
                    CategoryName = "Smart Phone"
                }
            };
        }

        public static void InitCategoryData(ApplicationDbContext dbContext)
        {
            var categories = GetSeedCategoryData();
            dbContext.AddRange(categories);
            dbContext.SaveChanges();
        }
    }
}