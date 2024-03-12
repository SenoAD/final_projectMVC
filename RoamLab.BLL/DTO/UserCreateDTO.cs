using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BLL.DTO
{
    public class UserCreateDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
    }
}
