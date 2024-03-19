using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BO;

namespace RoamLab.DAL.Interface
{
    public interface IRole : ICrud<RoleUserDAL>
    {
        IEnumerable<RoleUser> GetAllUserRolebyUserID(int UserID);  

    }
}
