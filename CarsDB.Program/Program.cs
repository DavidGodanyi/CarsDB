using CarsDB.Classes;
using CarsDB.Logic;
using CarsDB.Repository;
using ConsoleTools;
using System;

namespace CarsDB.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            CarDBContext db = new CarDBContext();
            CarRepository carRepo = new CarRepository(db);
            BrandRepository brandRepo = new BrandRepository(db);
            Changes chLogic = new Changes(carRepo);
            Read rLogic = new Read(carRepo,brandRepo);
            QueryLogic qLogic = new QueryLogic(carRepo,brandRepo);

            var Menu = new ConsoleMenu().
                Add("Average price for every brand", () => AvgBrandPrices(qLogic)).
                Add("Other Brand Statistics", () => ShowBrandStatistics(qLogic)).
                Add("ALL CARS", () => ShowAllCars(rLogic)).
                Add("ALL BRANDS", () => ShowAllBrands(rLogic)).
                Add("Inflation", () => SetInflation(chLogic, rLogic)).
                Add("Change a car price", () => SetNewPrice(chLogic, rLogic)).
                Add("Close", ConsoleMenu.Close);

            Menu.Show();
        }
        private static void AvgBrandPrices(QueryLogic qlogic)
        {
            foreach (var item in qlogic.GetAvgPrices())
            {
                Console.WriteLine(item);                
            }
            Console.ReadLine();
        }
        private static void ShowBrandStatistics(QueryLogic qlogic)
        {
            Console.WriteLine(qlogic.GetBrandStatistics().ToString());
            Console.ReadLine();
        }

        private static void ShowAllCars(Read rlogic)
        {
            foreach (var item in rlogic.GetAllCars())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        private static void ShowAllBrands(Read rlogic)
        {
            foreach (var item in rlogic.GetAllBrands())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        private static void SetInflation(Changes chlogic, Read rlogic)
        {
            Console.WriteLine("Inflation % ?");
            try
            {                
                double percent = Convert.ToDouble(Console.ReadLine());
                chlogic.Inflation(percent);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ShowAllCars(rlogic);
            }
        }
        private static void SetNewPrice(Changes chlogic, Read rlogic)
        {
            Console.Write("Car id:   ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("New price:   ");
                double newPrice = Convert.ToDouble(Console.ReadLine());
                chlogic.ChangePrice(id,newPrice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ShowAllCars(rlogic);
            }
        }
    }
}
