using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BO
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string Location { get; set;}
        public string Bio { get; set; }
        public DateTime LastLoginDate { get; set; }

    }
}
