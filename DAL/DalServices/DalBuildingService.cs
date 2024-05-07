using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class DalBuildingService
    {
        CoHousingContext _CoHousingData;
        public DalBuildingService(CoHousingContext coHousingData)
        {
            _CoHousingData = coHousingData;
        }

    }
}
