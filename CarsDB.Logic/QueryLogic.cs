using CarsDB.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarsDB.Classes;

namespace CarsDB.Logic
{
    public class QueryLogic : IQueryLogic
    {
        ICarRepository carRepo;
        IRepository<Brand> brandRepo;

        public QueryLogic(ICarRepository carRepo, IRepository<Brand> brandRepo)
        {
            this.carRepo = carRepo;
            this.brandRepo = brandRepo;
        }
        public List<AvgPrice> GetAvgPrices()
        {
            var q = from car in carRepo.GetAll()
                    group car by new { car.Brand.Id, car.Brand.Name} into grp
                    select new AvgPrice() { brand = grp.Key.Name, avgPrice = grp.Average(x => x.PriceInMillion) };
            return q.ToList();
        }

        public BrandStatistics GetBrandStatistics()
        {
            var q = from brand in brandRepo.GetAll()
                    group brand by brand.Name into grp
                    select new BrandStatistics() { newestBrandName = grp.Key, newestBrandYear = grp.Max(x => x.Founded) };
            var q2 = from brand in brandRepo.GetAll()
                    group brand by brand.Name into grp
                    select new BrandStatistics() { oldestBrandName = grp.Key, oldestBrandYear = grp.Max(x => x.Founded) };

            List<string> list = new List<string>();
            BrandStatistics bs = new BrandStatistics();
            foreach (var item in q)
            {
                list.Add(item.ToString());
            }
            foreach (var item in q2)
            {
                list.Add(item.ToString());
            }
            bs.newestBrandName = list[0];
            bs.newestBrandYear = Convert.ToInt32(list[1]);
            bs.oldestBrandName = list[2];
            bs.oldestBrandYear = Convert.ToInt32(list[3]);

            return bs;
        }
    }
}
