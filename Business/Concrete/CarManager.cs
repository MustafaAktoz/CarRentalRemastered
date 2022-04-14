using Business.Abstract;
using Business.BusinessAspect.Autofac.Security;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Validation.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [RemoveCashAspect("ICarService.Get")]
        [FluentValidationAspect(typeof(FVCarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperationAspect("admin")]
        [RemoveCashAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result, Messages.Listed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);
            return new SuccessDataResult<List<Car>>(result, Messages.Listed);
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId);
            return new SuccessDataResult<List<Car>>(result, Messages.Listed);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(c => c.Id == id);
            return new SuccessDataResult<Car>(result, Messages.Geted);
        }

        public IDataResult<CarDetailDTO> GetDetailById(int id)
        {
            var result = _carDal.GetDetail(c => c.Id == id);
            return new SuccessDataResult<CarDetailDTO>(result, Messages.Geted);
        }

        [PerformanceAspect(0.01)]
        public IDataResult<List<CarDetailDTO>> GetDetails()
        {
            var result = _carDal.GetDetails();
            return new SuccessDataResult<List<CarDetailDTO>>(result, Messages.Listed);
        }

        public IDataResult<List<CarDetailDTO>> GetDetailsByBrandId(int brandId)
        {
            var result = _carDal.GetDetails(c => c.BrandId == brandId);
            return new SuccessDataResult<List<CarDetailDTO>>(result, Messages.Listed);
        }

        public IDataResult<List<CarDetailDTO>> GetDetailsByColorId(int colorId)
        {
            var result = _carDal.GetDetails(c => c.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDTO>>(result, Messages.Listed);
        }

        [FluentValidationAspect(typeof(FVCarValidator))]
        [RemoveCashAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
