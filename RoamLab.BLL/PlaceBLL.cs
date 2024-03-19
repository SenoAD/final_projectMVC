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
        private readonly ILocation _locationDAL;
        public PlaceBLL()
        {
            _placeDAL = new PlaceDAL();
            _locationDAL = new LocationDAL();
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
                    Preview = place.Preview,                   
                }) ;
            }
            return listPlaceDto;
        }

        public IEnumerable<PlaceDTO> GetAllwithLocationID()
        {
            var locationList = new List<PlaceDTO>();
            var places = GetAll();
            foreach (var place in places)
            {
                Location locationBO = _locationDAL.GetLocationByID(place.LocationID);
                var locationDTO = new LocationDTO
                {
                    LocationID = locationBO.LocationID,
                    City = locationBO.City,
                    Country = locationBO.Country,
                    Region = locationBO.Region,
                    Latitude = locationBO.Latitude,
                    Longitude = locationBO.Longitude,
                };
                locationList.Add(new PlaceDTO
                {
                    PlaceID = place.PlaceID,
                    Name = place.Name,
                    Address = place.Address,
                    PhoneNumber = place.PhoneNumber,
                    LocationID = place.LocationID,
                    CategoryID = place.CategoryID,
                    Preview = place.Preview,
                    Location = locationDTO
                });
            }
            return locationList;
        }

        public PlaceDTO GetPlaceByID(int placeID)
        {
            var place = _placeDAL.GetPlaceByID(placeID);
            PlaceDTO placeDTO = new PlaceDTO
            {
                PlaceID = place.PlaceID,
                Name = place.Name,
                Address = place.Address,
                PhoneNumber = place.PhoneNumber,
                LocationID = place.LocationID,
                CategoryID = place.CategoryID,
                Preview= place.Preview,
            };

            return placeDTO;
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

        public void InsertPlaceAttraction(CreateAttractionPlaceDTO createAttractionPlaceDTO)
        {
            var place = new Place
            {
                Name = createAttractionPlaceDTO.Name,
                Address = createAttractionPlaceDTO.Address,
                PhoneNumber = createAttractionPlaceDTO.PhoneNumber,
                LocationID = createAttractionPlaceDTO.LocationID,
                CategoryID = createAttractionPlaceDTO.CategoryID,
                Attraction = new Attraction
                {
                    Type = createAttractionPlaceDTO.Type,
                    OpeningHours = createAttractionPlaceDTO.OpeningHours,
                    AdmissionFee = createAttractionPlaceDTO.AdmissionFee,
                } 
            };
            _placeDAL.InsertPlaceAttraction(place);
        }

        public void InsertPlaceHotel(CreateHotelPlaceDTO createHotelPlaceDTO)
        {
            var place = new Place
            {
                Name = createHotelPlaceDTO.Name,
                Address = createHotelPlaceDTO.Address,
                PhoneNumber = createHotelPlaceDTO.PhoneNumber,
                LocationID = createHotelPlaceDTO.LocationID,
                CategoryID = createHotelPlaceDTO.CategoryID,
                Hotel = new Hotel
                {
                   Facilitation = createHotelPlaceDTO.Facilitation
                }
            };
            _placeDAL.InsertPlaceHotel(place);
        }

        public void InsertPlaceRestaurant(CreateRestaurantPlaceDTO createRestaurantPlaceDTO)
        {
            var place = new Place
            {
                Name = createRestaurantPlaceDTO.Name,
                Address = createRestaurantPlaceDTO.Address,
                PhoneNumber = createRestaurantPlaceDTO.PhoneNumber,
                LocationID = createRestaurantPlaceDTO.LocationID,
                CategoryID = createRestaurantPlaceDTO.CategoryID,
                Restaurant = new Restaurant
                {
                    CuisineType = createRestaurantPlaceDTO.CuisineType,
                    PriceRange = createRestaurantPlaceDTO.PriceRange
                }
            };
            _placeDAL.InsertPlaceRestaurant(place);
        }
    }
}
