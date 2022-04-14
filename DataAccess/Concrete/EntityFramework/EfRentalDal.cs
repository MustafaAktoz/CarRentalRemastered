using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EFEntityRepositoryBase<Rental, EFCarRentalContext>, IRentalDal
    {
        public List<RentalDetailDTO> GetDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (var context = new EFCarRentalContext())
            {
                var result = from rental in filter==null?context.Rentals:context.Rentals.Where(filter)
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDTO { Id = rental.Id, BrandName = brand.Name, FullName = $"{user.FirstName} {user.LastName}", RentDate = rental.RentDate, ReturnDate = rental.ReturnDate };
                return result.ToList();
            }
        }
    }
}
