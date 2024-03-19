using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BO;

namespace RoamLab.DAL.Interface
{
    public interface IPlace : ICrud<Place>
    {
        IEnumerable<Place> GetPlaceByLocationID(int locationID);
        Place GetPlaceByID(int placeID);
        void InsertPlaceHotel(Place place);
        void InsertPlaceAttraction(Place place);
        void InsertPlaceRestaurant(Place place);
    }
}
