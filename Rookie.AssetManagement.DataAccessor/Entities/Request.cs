using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public RequestState RequestState { get; set; }
        public int? RequestedUserId { get; set; }
        public virtual User RequestedUser { get; set; }
        public int? AcceptedUserId { get; set; }
        public virtual User AcceptedUser { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
