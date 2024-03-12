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
        IEnumerable<PlaceDTO> GetAll();
    }
}
