using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation.FluentValidation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [FluentValidationAspect(typeof(FVCustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result, Messages.Listed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(c => c.Id == id);
            return new SuccessDataResult<Customer>(result, Messages.Geted);
        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            var result = _customerDal.Get(c => c.UserId == userId);
            return new SuccessDataResult<Customer>(result, Messages.Geted);
        }

        [FluentValidationAspect(typeof(FVCustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }

        public IResult FakeCustomerAdd(int userId)
        {
            _customerDal.Add(new Customer { UserId = userId, FindeksPoint = 1234, CompanyName = "Bilmem Ne LTD.ŞTİ" });
            return new SuccessResult(Messages.Added);
        }
    }
}
