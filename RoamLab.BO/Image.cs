using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BO
{
    public class Image
    {
        public int ImageID { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int ReviewID { get; set; }
        public int PlaceID { get; set; }
    }

}
