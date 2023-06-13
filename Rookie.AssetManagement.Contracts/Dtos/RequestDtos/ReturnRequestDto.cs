using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.RequestDtos
{
    public class ReturnRequestDto : BaseQueryCriteria
    {
        public string? Keyword { get; set; }
        public List<int> State { get; set; } = new List<int>();
        public DateTime AssignedDate { get; set; }
        public string? SortBy { get; set; }
        public bool Ascending { get; set; }
        public string LocationId { get; set; }

    }
}
