using System;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Logic
{
    public class NewestBrandStatistics
    {
        public string newestBrandName { get; set; }
        public int newestBrandYear { get; set; }        

        public override string ToString()
        {
            return "At the very latest founded brand is " + newestBrandName + ", founded in " + newestBrandYear + ".";
        }
        public override bool Equals(object obj)
        {
            if (obj is NewestBrandStatistics)
            {
                NewestBrandStatistics other = obj as NewestBrandStatistics;
                return this.newestBrandName == other.newestBrandName && this.newestBrandYear == other.newestBrandYear;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return newestBrandName.GetHashCode() + newestBrandYear * 2;
        }
    }
}
