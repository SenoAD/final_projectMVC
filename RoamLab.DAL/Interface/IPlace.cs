using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BO;

namespace RoamLab.DAL.Interface
{
    public interface IPlace : ICrud<Place>
    {
        IEnumerable<Place> GetPlaceByLocationID(int locationID);
    }
}
