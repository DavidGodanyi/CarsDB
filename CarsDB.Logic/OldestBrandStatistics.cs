using System;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Logic
{
    class OldestBrandStatistics
    {
        public string oldestBrandName { get; set; }
        public int oldestBrandYear { get; set; }

        public override string ToString()
        {
            return "The earliest founded brand is " + oldestBrandName + ", founded in " + oldestBrandYear + ".";
        }
        public override bool Equals(object obj)
        {
            if (obj is OldestBrandStatistics)
            {
                OldestBrandStatistics other = obj as OldestBrandStatistics;
                return this.oldestBrandName == other.oldestBrandName && this.oldestBrandYear == other.oldestBrandYear;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return oldestBrandName.GetHashCode() + oldestBrandYear * 3;
        }
    }
}
