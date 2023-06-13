using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.Assignment
{
    public class AssignmentRequestDto : BaseQueryCriteria
    {
        public string? Keyword { get; set; }
        public List<int> State { get; set; } = new List<int>();
        public DateTime AssignDate { get; set; }
        public string? SortBy { get; set; }
        public bool Ascending { get; set; }
        public string LocationId { get; set; }
    }
}
