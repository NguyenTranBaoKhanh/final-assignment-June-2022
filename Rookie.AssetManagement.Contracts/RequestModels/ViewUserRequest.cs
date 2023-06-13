using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.RequestModels
{
    public class ViewUserRequest : BaseQueryCriteria
    {
        public string? Keyword { get; set; }
        public List<string> Type { get; set; } = new List<string>();
        public string? SortBy { get; set; }
        public bool Ascending { get; set; }
        public string LocationId { get; set;}
    }
}
