using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static ICarService _carService;

        static Program()
        {
            _carService = new CarManager(new IMCarDal());
        }

        static void Main(string[] args)
        {
            var car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, Name = "Focus", ModelYear = "2010", DailyPrice = 300, Description = "Ford Focus" };
            var car2 = new Car { Id = 2, BrandId = 2, ColorId = 2, Name = "Ranger", ModelYear = "2018", DailyPrice = 500, Description = "Ford Ranger" };
            
            _carService.Add(car1);
            _carService.Add(car2);
            var cars = _carService.GetAll();
            Console.WriteLine("Güncellenmeden Önce");
            cars.ForEach(currentCar => Console.WriteLine(currentCar.Name));

            Console.WriteLine("\n--------------------------------\n");

            Console.WriteLine("Güncellenmeden Sonra");
            _carService.Update(new Car { Id = 1, BrandId = 2, ColorId = 3, Name = "Fiesta", ModelYear = "2011", DailyPrice = 400, Description = "Ford Fiesta" });
            cars.ForEach(currentCar => Console.WriteLine(currentCar.Name));

            Console.WriteLine("\n--------------------------------\n");

            Console.WriteLine("Silinmeden Önce");
            cars.ForEach(currentCar => Console.WriteLine(currentCar.Name));

            Console.WriteLine("\n--------------------------------\n");

            Console.WriteLine("Silindikten Sonra");
            _carService.Delete(new Car { Id = 3 });
            cars.ForEach(currentCar => Console.WriteLine(currentCar.Name));

            Console.WriteLine("\n--------------------------------\n");

        }
    }
}
