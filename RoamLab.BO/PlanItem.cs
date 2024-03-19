using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BO
{
    public class PlanItem
    {
        public int ItemID { get; set; }
        public int PlanID { get; set; }
        public int PlaceID { get; set; }
        public string DatePlace { get; set; }
        public Place PlacebyID { get; set; }
    }

}
