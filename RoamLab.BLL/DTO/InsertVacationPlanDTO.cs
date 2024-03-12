using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BO;

namespace RoamLab.BLL.DTO
{
    public class InsertVacationPlanDTO
    {
        public int PlanID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DestinationLocationID { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<InsertPlanItemDTO> PlanItems { get; set; }
    }
}
