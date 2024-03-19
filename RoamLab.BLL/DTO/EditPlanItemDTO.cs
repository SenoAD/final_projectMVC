using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BO;

namespace RoamLab.BLL.DTO
{
    public class EditPlanItemDTO
    {
        public int PlanID { get; set; }
        public int PlaceID { get; set; }
        public string DatePlace { get; set; }
        public PlaceDTO PlacebyID { get; set; }
    }
}
