using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BO;

namespace RoamLab.DAL.Interface
{
    public interface ILocation : ICrud<Location>
    {
        Location GetLocationByID(int id);
    }
}
