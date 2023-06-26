using CarsDB.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsDB.Repository
{
    public class BrandRepository : Repository<Brand>
    {
        public BrandRepository(DbContext db) : base(db)
        {
        }

        public override Brand GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
