using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Classes
{
    public partial class CarDBContext : DbContext
    {
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Car> Car { get; set; }

        public CarDBContext()
        {
            this.Database.EnsureCreated();//táblák létrehozása, feltöltése adattal
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|Data Directory|\Database1.mdf; Integrated Security=True; MultipleACtiveResultSets=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(car => car.Brand).WithMany(brand => brand.Cars).HasForeignKey(car => car.BrandID).OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
