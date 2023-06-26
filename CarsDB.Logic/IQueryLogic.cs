using System;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Logic
{
    public interface IQueryLogic
    {
        BrandStatistics GetBrandStatistics();
        List<AvgPrice> GetAvgPrices();
    }
}
