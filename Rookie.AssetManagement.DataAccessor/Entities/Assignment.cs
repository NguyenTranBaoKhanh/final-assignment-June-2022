using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public string? AssetCode { get; set; }
        public Asset Asset { get; set; }
        public int? AssignedToUserId { get; set; }
        public virtual User AssignedToUser { get; set; }
        public int? AssignedByUserId { get; set; }
        public virtual User AssignedByUser { get; set; }
        public DateTime AssignedDate { get; set; }
        public String Note { get; set; }
        public AssignmentState AssignmentState { get; set; }
        public Boolean IsDeleted { get; set; }
        public Request Request { get; set; }
    }
}
