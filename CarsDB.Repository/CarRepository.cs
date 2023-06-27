using CarsDB.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsDB.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(DbContext db) : base(db)
        {
        }

        public void ChangePrice(int id, double newPrice)
        {
            var x = GetOne(id);
            if (x == null) throw new Exception("THE CAR IS NOT IN THE DATABASE");
            x.PriceInMillion = newPrice;
            db.SaveChanges();
        }

        public override Car GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public void Inflation(double percent)
        {
            var x = GetAll();
            foreach (var item in x)
            {
                item.PriceInMillion += item.PriceInMillion * percent / 100;
            }
            db.SaveChanges();
        }
    }
}
