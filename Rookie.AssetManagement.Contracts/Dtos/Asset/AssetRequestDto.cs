using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.Asset
{
    public class AssetRequestDto : BaseQueryCriteria
    {
        public string? Keyword { get; set; }
        public List<string> Category { get; set; } = new List<string>();
        public List<int> AssetState { get; set; } = new List<int>();
        public string? SortBy { get; set; }
        public bool Ascending { get; set; }
        public string LocationId { get; set; }
    }
}
