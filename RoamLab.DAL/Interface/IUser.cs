using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BO;

namespace RoamLab.DAL.Interface
{
    public interface IUser : ICrud<User>
    {
        User GetByUserID(int userID);
        User Login(string username, string password);
        //void ChangePassword(string username, string newPassword);
    }
}
