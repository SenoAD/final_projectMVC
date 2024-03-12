using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using RoamLab.BO;

namespace RoamLab.DAL.Interface
{
    public interface IVacationPlan : ICrud<VacationPlan>
    {
        void TransactionInsert(VacationPlan T);
        IEnumerable<VacationPlan> GetVacationPlanByUserID(int userID);
    }
}
