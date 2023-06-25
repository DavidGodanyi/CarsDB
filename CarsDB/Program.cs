using CarsDB.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

//Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|Data Directory|\Database1.mdf;
//Integrated Security=True; MultipleACtiveResultSets=true
namespace CarsDB
{
    class Program
    {
        static void Main(string[] args)
        {
            CarDBContext db1 = new CarDBContext();
            db1.Brand.Select(x => x.Name).ToConsole("Available Brands");
            db1.Car.Select(x => x.Brand.Name + " " +  x.Type).ToConsole("All");

            var L1 = from car in db1.Car
                     group car by car.BrandID into grp
                     select new { Brand = grp.Key, AvgPrice = grp.Average(x => x.PriceInMillion) };

            var L1S = from grp in L1
                      join brand in db1.Brand on grp.Brand equals brand.Id
                      select new { Brand = grp.Brand, AvgPrice = grp.AvgPrice };
            L1S.ToConsole("Avg price for every brand");
        }
    }
}
