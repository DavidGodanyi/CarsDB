using CarsDB.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Logic
{
    public interface IRead
    {
        Car GetOneCar(int id);
        Brand GetOneBrand(int id);
        List<Car> GetAllCars();
        List<Brand> GetAllBrands();
    }
}
