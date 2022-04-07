using Business.Abstract;
using Business.Constants;
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
            return new SuccessDataResult<List<Customer>>(result,Messages.Listed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(c=>c.Id==id);
            return new SuccessDataResult<Customer>(result, Messages.Geted);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
