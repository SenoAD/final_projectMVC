using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BLL.DTO;
using RoamLab.BO;


namespace RoamLab.BLL.Interface
{
    public interface IUserBLL
    {
        void Insert(UserCreateDTO entity);
        LoginUserDTO Login(string username, string password);
    }
}
