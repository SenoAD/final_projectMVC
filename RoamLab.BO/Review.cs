using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BO
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int UserID { get; set; }
        public int PlaceID { get; set; }
    }
}
