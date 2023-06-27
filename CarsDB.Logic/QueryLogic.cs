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

        public string GetBrandStatistics()
        {
            string results = "Brand Statistics: \n";

            var q1 = from brand in brandRepo.GetAll()
                     select brand;            

            NewestBrandStatistics n = new NewestBrandStatistics();
            OldestBrandStatistics o = new OldestBrandStatistics();
            n.newestBrandYear= q1.Max(x => x.Founded);
            o.oldestBrandYear = q1.Min(x => x.Founded);

            var q2 = from brand in brandRepo.GetAll()
                     where brand.Founded == n.newestBrandYear
                     select brand.Name;
            foreach (var item in q2)
            {
                n.newestBrandName += item;
            }

            var q3 = from brand in brandRepo.GetAll()
                     where brand.Founded == o.oldestBrandYear
                     select brand.Name;
            foreach (var item in q3)
            {
                o.oldestBrandName += item;
            }

            return results + o + "\n" + n;
        }
    }
}
