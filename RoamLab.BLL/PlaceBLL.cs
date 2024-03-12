using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BLL.Interface;
using RoamLab.BO;
using RoamLab.DAL.Interface;
using RoamLab.DAL;
using RoamLab.BLL.DTO;

namespace RoamLab.BLL
{
    public class PlaceBLL : IPlaceBLL
    {
        private readonly IPlace _placeDAL;
        public PlaceBLL()
        {
            _placeDAL = new PlaceDAL();
        }

        public IEnumerable<PlaceDTO> GetAll()
        {
            List<PlaceDTO> listPlaceDto = new List<PlaceDTO>();
            var places = _placeDAL.GetAll();
            foreach (var place in places)
            {
                listPlaceDto.Add(new PlaceDTO
                {
                    PlaceID = place.PlaceID,
                    Name = place.Name,
                    Address = place.Address,
                    PhoneNumber = place.PhoneNumber,
                    LocationID = place.LocationID,
                    CategoryID = place.CategoryID,
                    Preview = place.Preview
                });
            }
            return listPlaceDto;
        }

        public IEnumerable<PlaceDTO> GetPlaceByLocationID(int locationID)
        {
            List<PlaceDTO> listPlaceDto = new List<PlaceDTO>();
            var places = _placeDAL.GetPlaceByLocationID(locationID);
            foreach (var place in places)
            {
                listPlaceDto.Add(new PlaceDTO
                {
                    PlaceID = place.PlaceID,
                    Name = place.Name,
                    Address = place.Address,
                    PhoneNumber = place.PhoneNumber,
                    LocationID = place.LocationID,
                    CategoryID = place.CategoryID,
                    Preview = place.Preview
                    
                });
            }
            return listPlaceDto;
        }
    }
}
