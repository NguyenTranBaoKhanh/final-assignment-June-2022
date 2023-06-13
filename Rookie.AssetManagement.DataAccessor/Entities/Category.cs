using System.Collections.Generic;

namespace Rookie.AssetManagement.DataAccessor.Entities
{
    public class Category
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Asset> Assets { get; set; }
    }
}
