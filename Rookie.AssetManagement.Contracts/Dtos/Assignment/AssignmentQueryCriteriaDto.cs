using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.Assignment
{
    public class AssignmentQueryCriteriaDto : BaseQueryCriteria
    {
        public int[] State { get; set; }
        public int Id { get; set; }
    }
}
