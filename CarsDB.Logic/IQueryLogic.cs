using System;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Logic
{
    public interface IQueryLogic
    {
        string GetBrandStatistics();
        List<AvgPrice> GetAvgPrices();
    }
}
