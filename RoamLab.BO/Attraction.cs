using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BO
{
    public class Attraction
    {
        public int AttractionID { get; set; }
        public int PlaceID { get; set; }
        public string Type { get; set; }
        public string OpeningHours { get; set; }
        public decimal AdmissionFee { get; set; }
    }

}
