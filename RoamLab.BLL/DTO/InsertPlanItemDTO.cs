using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BLL.DTO
{
    public class InsertPlanItemDTO
    {
        public int ItemID { get; set; }
        public int PlanID { get; set; }
        public int PlaceID { get; set; }
        public string DatePlace { get; set; }
    }
}
