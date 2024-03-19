using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BLL.DTO;
using RoamLab.BO;

namespace RoamLab.BLL.Interface
{
    public interface IPlaceBLL
    {
        IEnumerable<PlaceDTO> GetPlaceByLocationID(int locationID);
        IEnumerable<PlaceDTO> GetAllwithLocationID();
        IEnumerable<PlaceDTO> GetAll();
        PlaceDTO GetPlaceByID(int placeID);
        void InsertPlaceHotel(CreateHotelPlaceDTO createHotelPlaceDTO);
        void InsertPlaceRestaurant(CreateRestaurantPlaceDTO createRestaurantPlaceDTO);
        void InsertPlaceAttraction(CreateAttractionPlaceDTO createAttractionPlaceDTO);
    }
}
