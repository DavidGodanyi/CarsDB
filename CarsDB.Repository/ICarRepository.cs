using CarsDB.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Repository
{
    public interface ICarRepository:IRepository<Car>
    {

        void ChangePrice(int id, double newPrice);
        void Inflation(double percent);

    }
}
