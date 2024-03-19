using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BO;

namespace RoamLab.BLL.DTO
{
    public class GetEditVacationPlanDTO
    {
        public int PlanID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<EditPlanItemDTO> PlanItems { get; set; }
        public int IsPublic { get; set; }
    }
}
