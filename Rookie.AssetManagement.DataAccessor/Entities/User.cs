using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rookie.AssetManagement.DataAccessor.Entities
{
    public class User : IdentityUser<int>
    {
        public string StaffCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinedDate { get; set; }
        public string Gender { get; set; }
        public bool IsLogged { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string LocationID { get; set; }
        public virtual Location Location { get; set; }
        public virtual List<Assignment> AssignedBys { get; set; }
        public virtual List<Assignment> AssignedTos { get; set; }
        public virtual List<Request> CreatedRequests { get; set; }
        public virtual List<Request> AcceptedRequests { get; set; }
    }
}
