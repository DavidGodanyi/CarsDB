using System;

namespace CarsDB.Logic
{
    public class AvgPrice
    {
        public string brand { get; set; }
        public double avgPrice { get; set; }

        public override string ToString()
        {
            return brand + "Average car price: " + avgPrice;
        }

        public override bool Equals(object obj)
        {
            if (obj is AvgPrice)
            {
                AvgPrice other = obj as AvgPrice;
                return this.brand == other.brand && this.avgPrice == other.avgPrice;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return brand.GetHashCode() + Convert.ToInt32(avgPrice) + Convert.ToInt32(Math.Pow(avgPrice, 2));
        }
    }
}
