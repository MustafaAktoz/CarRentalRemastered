using Core.DataAccess.Concrete.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class IMCarDal : IMEntityRepositoryBase<Car>, ICarDal
    {
        IBrandDal _brandDal;
        IColorDal _colorDal;
        public IMCarDal(IBrandDal brandDal, IColorDal colorDal)
        {
            _brandDal = brandDal;
            _colorDal = colorDal;
        }

        public CarDetailDTO GetDetail(Expression<Func<Car, bool>> filter)
        {
            var result = from car in _entities.AsQueryable().Where(filter).ToList()
                         join brand in _brandDal.GetAll()
                         on car.BrandId equals brand.Id
                         join color in _colorDal.GetAll()
                         on car.ColorId equals color.Id
                         select new CarDetailDTO { Id = car.Id, Name = car.Name, BrandName = brand.Name, ColorName = color.Name, ModelYear = car.ModelYear, DailyPrice = car.DailyPrice, Description = car.Description };
            return result.SingleOrDefault();
        }

        public List<CarDetailDTO> GetDetails(Expression<Func<Car, bool>> filter = null)
        {
            var result = from car in filter == null ? _entities : _entities.AsQueryable().Where(filter).ToList()
                         join brand in _brandDal.GetAll()
                         on car.BrandId equals brand.Id
                         join color in _colorDal.GetAll()
                         on car.ColorId equals color.Id
                         select new CarDetailDTO { Id = car.Id, Name = car.Name, BrandName = brand.Name, ColorName = color.Name, ModelYear = car.ModelYear, DailyPrice = car.DailyPrice, Description = car.Description };
            return result.ToList();
        }
    }
}
