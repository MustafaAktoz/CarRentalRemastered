using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, EFCarRentalContext>, ICarDal
    {
        public CarDetailDTO GetDetail(Expression<Func<Car, bool>> filter)
        {
            using (var context = new EFCarRentalContext())
            {
                var result = from car in context.Cars.Where(filter)
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             select new CarDetailDTO
                             {
                                 Id = car.Id,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 Name = car.Name,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 FindeksPoint = car.FindeksPoint,
                                 CarImages = context.CarImages.Where(ci => ci.CarId == car.Id).ToList()
                             };
                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDTO> GetDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (var context = new EFCarRentalContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             select new CarDetailDTO { 
                                 Id = car.Id, 
                                 BrandName = brand.Name, 
                                 ColorName = color.Name, 
                                 Name = car.Name, 
                                 ModelYear = car.ModelYear, 
                                 DailyPrice = car.DailyPrice, 
                                 Description = car.Description, 
                                 FindeksPoint = car.FindeksPoint,
                                 CarImages = context.CarImages.Where(ci => ci.CarId == car.Id).ToList()
                             };
                return result.ToList();
            }
        }
    }
}
