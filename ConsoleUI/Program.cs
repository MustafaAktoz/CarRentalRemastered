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
        static IRentalService _rentalService;
        static ICustomerService _customerService;
        static IUserService _userService;

        static Program()
        {
            _carService = new CarManager(new EFCarDal());
            _brandService = new BrandManager(new EFBrandDal());
            _colorService = new ColorManager(new EFColorDal());
            _customerService = new CustomerManager(new EFCustomerDal());
            _rentalService = new RentalManager(new EFRentalDal(), _carService, _customerService);
            _userService = new UserManager(new EFUserDal(), _customerService);
        }

        static void Main(string[] args)
        {
            CarOperationsTest();
            BrandOperationsTest();
            ColorOperationsTest();
            RentalOperationsTest();
            CustomerOperationsTest();
        }

        private static void CustomerOperationsTest()
        {
            Console.WriteLine("-Müşteri");
            var users = _userService.GetAll().Data;
            var customer1 = new Customer { UserId = users[users.Count - 1].Id, CompanyName = "Auicky" };
            var customer2 = new Customer { UserId = users[users.Count - 1].Id, CompanyName = "Vestel" };

            _customerService.Add(customer1);
            _customerService.Add(customer2);

            Console.WriteLine("Güncellenmeden Önce");
            WriteCustomersToScreen();

            Console.WriteLine("Güncellenmeden Sonra");
            _customerService.Update(new Customer { Id = customer1.Id, UserId = customer1.UserId, CompanyName = "Arçelik" });
            customer2.CompanyName = "Bosh";
            _customerService.Update(customer2);
            WriteCustomersToScreen();

            Console.WriteLine("Silinmeden Önce");
            WriteCustomersToScreen();

            Console.WriteLine("Silindikten Sonra");
            _customerService.Delete(customer1);
            _customerService.Delete(new Customer { Id = customer2.Id });
            WriteCustomersToScreen();
        }

        private static void RentalOperationsTest()
        {
            Console.WriteLine("-Kiralama");
            var cars = _carService.GetAll().Data;
            var customers = _customerService.GetAll().Data;
            var rental1 = new Rental { CarId = cars[cars.Count - 1].Id, CustomerId = customers[customers.Count - 1].Id, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1) };
            var rental2 = new Rental { CarId = cars[cars.Count - 2].Id, CustomerId = customers[customers.Count - 1].Id, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1) };

            var addResult1=_rentalService.Add(rental1);
            if (!addResult1.Success) throw new Exception(addResult1.Message);

            var addResult2 = _rentalService.Add(rental2);
            if (!addResult2.Success) throw new Exception(addResult2.Message);

            Console.WriteLine("Güncellenmeden Önce");
            WriteRentalsToScreen();

            Console.WriteLine("Güncellenmeden Sonra");
            _rentalService.Update(new Rental { Id = rental1.Id, CarId = rental2.CarId, CustomerId = rental1.CustomerId, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(1) });
            rental2.CarId = rental1.CarId;
            _rentalService.Update(rental2);
            WriteRentalsToScreen();

            Console.WriteLine("Silinmeden Önce");
            WriteRentalsToScreen();

            Console.WriteLine("Silindikten Sonra");
            _rentalService.Delete(rental1);
            _rentalService.Delete(new Rental { Id = rental2.Id });
            WriteRentalsToScreen();
        }

        private static void ColorOperationsTest()
        {
            Console.WriteLine("-Renkler");
            var color1 = new Color { Name = "Siyah" };
            var color2 = new Color { Name = "Gri" };

            _colorService.Add(color1);
            _colorService.Add(color2);

            Console.WriteLine("Güncellenmeden Önce");
            WriteColorsToScreen();

            Console.WriteLine("Güncellenmeden Sonra");
            _colorService.Update(new Color { Id = color1.Id, Name = "Sarı" });
            color2.Name = "Kahverengi";
            _colorService.Update(color2);
            WriteColorsToScreen();

            Console.WriteLine("Silinmeden Önce");
            WriteColorsToScreen();

            Console.WriteLine("Silindikten Sonra");
            _colorService.Delete(color1);
            _colorService.Delete(new Color { Id = color2.Id });
            WriteColorsToScreen();
        }

        private static void BrandOperationsTest()
        {
            Console.WriteLine("-Markalar");
            var brand1 = new Brand { Name = "Honda" };
            var brand2 = new Brand { Name = "Audi" };

            _brandService.Add(brand1);
            _brandService.Add(brand2);

            Console.WriteLine("Güncellenmeden Önce");
            WriteBrandsToScreen();

            Console.WriteLine("Güncellenmeden Sonra");
            _brandService.Update(new Brand { Id = brand1.Id, Name = "Hundai" });
            brand2.Name = "BMW";
            _brandService.Update(brand2);
            WriteBrandsToScreen();

            Console.WriteLine("Silinmeden Önce");
            WriteBrandsToScreen();

            Console.WriteLine("Silindikten Sonra");
            _brandService.Delete(brand1);
            _brandService.Delete(new Brand { Id = brand2.Id });
            WriteBrandsToScreen();
        }

        private static void CarOperationsTest()
        {
            Console.WriteLine("-Arabalar");
            var brands = _brandService.GetAll().Data;
            var colors = _colorService.GetAll().Data;
            var car1 = new Car { BrandId = brands[brands.Count - 1].Id, ColorId = colors[colors.Count - 1].Id, Name = "Focus", ModelYear = 2010, DailyPrice = 300, Description = "Ford Focus" };
            var car2 = new Car { BrandId = brands[brands.Count - 1].Id, ColorId = colors[colors.Count - 1].Id, Name = "Ranger", ModelYear = 2018, DailyPrice = 500, Description = "Ford Ranger" };

            _carService.Add(car1);
            _carService.Add(car2);

            Console.WriteLine("Güncellenmeden Önce");
            WriteCarsToScreen();

            Console.WriteLine("Güncellenmeden Sonra");
            _carService.Update(new Car { Id = car1.Id, BrandId = car1.BrandId, ColorId = car1.ColorId, Name = "Fiesta", ModelYear = 2011, DailyPrice = 400, Description = "Ford Fiesta" });
            car2.Name = "Ecosport";
            _carService.Update(car2);
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

        static void WriteBrandsToScreen()
        {
            _brandService.GetAll().Data.ForEach(currentBrand => Console.WriteLine(currentBrand.Name));

            Console.WriteLine("\n--------------------------------\n");
        }

        static void WriteColorsToScreen()
        {
            _colorService.GetAll().Data.ForEach(currentColor => Console.WriteLine(currentColor.Name));

            Console.WriteLine("\n--------------------------------\n");
        }

        static void WriteRentalsToScreen()
        {
            _rentalService.GetAll().Data.ForEach(currentRental => Console.WriteLine(currentRental.CarId));

            Console.WriteLine("\n--------------------------------\n");
        }

        static void WriteCustomersToScreen()
        {
            _customerService.GetAll().Data.ForEach(currentCustomer => Console.WriteLine(currentCustomer.CompanyName));

            Console.WriteLine("\n--------------------------------\n");
        }
    }
}
