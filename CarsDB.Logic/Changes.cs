using CarsDB.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Logic
{
    public class Changes : IChanges
    {
        ICarRepository carRepo;
        public Changes(ICarRepository carRepo)
        {
            this.carRepo = carRepo;
        }
        public void ChangePrice(int id, double newPrice)
        {
            carRepo.ChangePrice(id, newPrice);
        }

        public void Inflation(double percent)
        {
            carRepo.Inflation(percent);
        }
    }
}
