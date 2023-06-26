using System;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Logic
{
    public interface IChanges
    {
        void Inflation(double percent);
        void ChangePrice(int id, double newPrice);
    }
}
