using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BO
{
    public class Place
    {
        public int PlaceID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int LocationID { get; set; }
        public int CategoryID { get; set; }
        public string Preview { get; set; }
        public Hotel Hotel { get; set; }
        public Restaurant Restaurant { get; set; }
        public Attraction Attraction { get; set; }
    }
}
