using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BLL.DTO;
using RoamLab.BLL.Interface;
using RoamLab.BO;
using RoamLab.DAL;
using RoamLab.DAL.Interface;

namespace RoamLab.BLL
{
    public class LocationBLL : ILocationBLL
    {
        private readonly ILocation _locationDAL;
        public LocationBLL()
        {
            _locationDAL = new LocationDAL();
        }
        public IEnumerable<LocationDTO> GetAll()
        {
            List<LocationDTO> listLocationDto = new List<LocationDTO>();
            var locations = _locationDAL.GetAll();
            foreach (var location in locations)
            {
                listLocationDto.Add(new LocationDTO
                {   
                    LocationID = location.LocationID,
                    City = location.City,
                    Country = location.Country,
                    Region = location.Region,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                });
            }
            return listLocationDto;
        }
    }
}
