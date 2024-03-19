using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BLL.DTO
{
    public class PlaceDTO
    {
        public int PlaceID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int LocationID { get; set; }
        public int CategoryID { get; set; }
        public string Preview { get; set; }
        public LocationDTO Location { get; set; }
    }
}
