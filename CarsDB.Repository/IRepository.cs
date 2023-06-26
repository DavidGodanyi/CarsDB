using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsDB.Repository
{
    public interface IRepository<T> where T:class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();

        void Insert(T entity);
        void Remove(int id);
    }
}
