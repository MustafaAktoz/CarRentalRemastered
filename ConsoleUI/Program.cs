using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static ICarService _carService;
        static IBrandService _brandService;
        static IColorService _colorService;

        static Program()
        {
            _carService = new CarManager(new EFCarDal());
            _brandService = new BrandManager(new EFBrandDal());
            _colorService = new ColorManager(new EFColorDal());
        }

        static void Main(string[] args)
        {
            var car1 = new Car {BrandId = 1, ColorId = 1, Name = "Focus", ModelYear = "2010", DailyPrice = 300, Description = "Ford Focus" };
            var car2 = new Car {BrandId = 2, ColorId = 2, Name = "Ranger", ModelYear = "2018", DailyPrice = 500, Description = "Ford Ranger" };

            _carService.Add(car1);
            _carService.Add(car2);

            Console.WriteLine("Güncellenmeden Önce");
            WriteCarsToScreen();

            Console.WriteLine("Güncellenmeden Sonra");
            _carService.Update(new Car { Id = 1, BrandId = 2, ColorId = 2, Name = "Fiesta", ModelYear = "2011", DailyPrice = 400, Description = "Ford Fiesta" });
            WriteCarsToScreen();

            Console.WriteLine("Silinmeden Önce");
            WriteCarsToScreen();

            Console.WriteLine("Silindikten Sonra");
            _carService.Delete(car1);
            _carService.Delete(new Car { Id = car2.Id });
            WriteCarsToScreen();

            Console.WriteLine("Detayları Listele");
            WriteCarDetailsToScreen();
        }

        static void WriteCarsToScreen()
        {
            _carService.GetAll().Data.ForEach(currentCar => Console.WriteLine(currentCar.Name));

            Console.WriteLine("\n--------------------------------\n");
        }

        static void WriteCarDetailsToScreen()
        {
            _carService.GetDetails().Data.ForEach(currentCarDetail => Console.WriteLine($"Model:{currentCarDetail.Name}   Marka:{currentCarDetail.BrandName}   Renk:{currentCarDetail.ColorName}"));

            Console.WriteLine("\n--------------------------------\n");
        }
    }
}
