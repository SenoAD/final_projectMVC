using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BLL.DTO
{
    public class LocationDTO
    {
        public int LocationID { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
