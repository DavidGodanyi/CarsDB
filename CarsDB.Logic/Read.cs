using CarsDB.Classes;
using CarsDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsDB.Logic
{
    public class Read : IRead
    {
        ICarRepository carRepo;
        IRepository<Brand> brandRepo;
        public Read(ICarRepository carRepo, IRepository<Brand> brandRepo)
        {
            this.carRepo = carRepo;
            this.brandRepo = brandRepo;
        }
        public List<Brand> GetAllBrands()
        {
            return brandRepo.GetAll().ToList();
        }

        public List<Car> GetAllCars()
        {
            return carRepo.GetAll().ToList();
        }

        public Brand GetOneBrand(int id)
        {
            return brandRepo.GetOne(id);
        }

        public Car GetOneCar(int id)
        {
            return carRepo.GetOne(id);
        }
    }
}
