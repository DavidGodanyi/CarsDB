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
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database1.mdf; Integrated Security=True; MultipleACtiveResultSets=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(car => car.Brand).WithMany(brand => brand.Cars).HasForeignKey(car => car.BrandID).OnDelete(DeleteBehavior.ClientSetNull);
            });

            //táblák feltöltése adatokkal
            Brand suzuki = new Brand() { Id = 1, Name = "Suzuki", Founded = 1909 };
            Brand nissan = new Brand() { Id = 2, Name = "Nissan", Founded = 1930 };
            Brand trabant = new Brand() { Id = 3, Name = "Trabant", Founded = 1957 };
            Brand porsche = new Brand() { Id = 4, Name = "Porsche", Founded = 1931 };
            Brand mazda = new Brand() { Id = 5, Name = "Mazda", Founded = 1920 };

            Car s1 = new Car() { Id = 1, BrandID = suzuki.Id, Type = "sx4", PriceInMillion = 4.6 };
            Car n1 = new Car() { Id = 2, BrandID = nissan.Id, Type = "nt500", PriceInMillion = 5.2 };
            Car t1 = new Car() { Id = 3, BrandID = trabant.Id, Type = "p70", PriceInMillion = 1.6 };
            Car t2 = new Car() { Id = 4, BrandID = trabant.Id, Type = "p50", PriceInMillion = 1.6 };
            Car p1 = new Car() { Id = 5, BrandID = porsche.Id, Type = "911", PriceInMillion = 8.2 };
            Car m1 = new Car() { Id = 6, BrandID = mazda.Id, Type = "2", PriceInMillion = 3.6 };
            Car m2 = new Car() { Id = 7, BrandID = mazda.Id, Type = "121", PriceInMillion = 2.6 };
            Car m3 = new Car() { Id = 8, BrandID = mazda.Id, Type = "5", PriceInMillion = 4.9 };
            Car p2 = new Car() { Id = 9, BrandID = porsche.Id, Type = "912", PriceInMillion = 8.5 };
            Car p3 = new Car() { Id = 10, BrandID = porsche.Id, Type = "914", PriceInMillion = 8.8 };

            modelBuilder.Entity<Brand>().HasData(suzuki, nissan, trabant, porsche, mazda);
            modelBuilder.Entity<Car>().HasData(s1, n1, t1, t2, p1, m1, m2, m3, p2, p3);
        }
    }
}
