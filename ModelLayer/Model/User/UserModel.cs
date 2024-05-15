using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model.User
{
    public class UserModel : IUserModel
    {
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Nickname { get; set; }
        public string AccountType { get; set; }
        public string ProfilePath { get; set; }
        public string Department { get; set; }
        

    }
}
