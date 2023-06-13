using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.User
{
    public class UserLoginResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string StaffCode { get; set; }
        public string Location { get; set; }
        public bool IsLogged { get; set; }
    }
}
