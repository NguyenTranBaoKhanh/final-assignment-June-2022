using System;
namespace Rookie.AssetManagement.Contracts.Dtos.UserDtos
{
	public class UserInfoDto
	{
        public string StaffCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinedDate { get; set; }
        public string Gender { get; set; }
        public bool IsLogged { get; set; }
        public string LocationID { get; set; }
    }
}

