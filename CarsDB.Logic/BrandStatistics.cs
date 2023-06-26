using System;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Logic
{
    public class BrandStatistics
    {
        public string newestBrandName { get; set; }
        public int newestBrandYear { get; set; }
        public string oldestBrandName { get; set; }
        public int oldestBrandYear { get; set; }

        public override string ToString()
        {
            return "The newest brand is " + newestBrandName + ", founded in " + newestBrandYear + ".\nThe oldest brand is " + oldestBrandName + ", founded in " + oldestBrandYear + ".";
        }
        public override bool Equals(object obj)
        {
            if (obj is BrandStatistics)
            {
                BrandStatistics other = obj as BrandStatistics;
                return this.oldestBrandName == other.oldestBrandName && this.oldestBrandYear == other.oldestBrandYear && this.newestBrandName == other.newestBrandName && this.newestBrandYear == other.newestBrandYear;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return oldestBrandName.GetHashCode() + newestBrandName.GetHashCode() + oldestBrandYear * 3 + newestBrandYear * 5;
        }
    }
}
