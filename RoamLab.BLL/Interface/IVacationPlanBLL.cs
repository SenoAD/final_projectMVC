using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BLL.DTO;
using RoamLab.BO;

namespace RoamLab.BLL.Interface
{
    public interface IVacationPlanBLL
    {
        void Insert(InsertVacationPlanDTO Plan);
        IEnumerable<VacationPlanDTO> GetVacationPlanByUserID(int userID);
        GetEditVacationPlanDTO GetVacationPlanAndPlanItemByPlanID(int planID);
    }
}
