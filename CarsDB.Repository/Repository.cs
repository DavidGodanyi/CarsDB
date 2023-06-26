using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CarsDB.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected DbContext db;
        public Repository(DbContext db)
        {
            this.db = db;
        }
        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public abstract T GetOne(int id);

        public void Insert(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            db.Remove(id);
            db.SaveChanges();
        }
    }
}
