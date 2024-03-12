using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BLL.DTO;
using RoamLab.BLL.Interface;
using RoamLab.DAL.Interface;
using RoamLab.DAL;
using RoamLab.BO;

namespace RoamLab.BLL
{
    public class VacationPlanBLL : IVacationPlanBLL
    {
        private readonly IVacationPlan vacationPlanDAL;
        public VacationPlanBLL()
        {
            vacationPlanDAL = new VacationPlanDAL();
        }

        public IEnumerable<VacationPlanDTO> GetVacationPlanByUserID(int userID)
        {
            List<VacationPlanDTO> vacationPlanDto = new List<VacationPlanDTO>();
            var plans = vacationPlanDAL.GetVacationPlanByUserID(userID);
            foreach (var plan in plans)
            {
                vacationPlanDto.Add(new VacationPlanDTO
                {
                    PlanID = plan.PlanID,
                    Name = plan.Name,
                    UserID  = plan.UserID,
                    Description = plan.Description,
                    DestinationLocationID = plan.DestinationLocationID,
                    CreatedDate = plan.CreatedDate
                });
            }
            return vacationPlanDto;
        }

        public void Insert(InsertVacationPlanDTO Plan)
        {
            var newPlanList = new List<PlanItem>();
            var planItem = new PlanItem();
            foreach (InsertPlanItemDTO item in Plan.PlanItems) 
            { 
                planItem.PlaceID = item.PlaceID;
                planItem.DatePlace = item.DatePlace;
                newPlanList.Add(planItem);
            }

            var newVacationPlan = new VacationPlan
            {
                UserID = Plan.UserID,
                Name = Plan.Name,
                Description = Plan.Description,
                DestinationLocationID = Plan.DestinationLocationID,
                PlanItems = newPlanList
            };
            vacationPlanDAL.TransactionInsert(newVacationPlan);
        }
    }
}
