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
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var result = _paymentDal.GetAll();
            return new SuccessDataResult<List<Payment>>(result);
        }

        public IDataResult<List<Payment>> GetAllByUserId(int userId)
        {
            var result = _paymentDal.GetAll(p=>p.UserId==userId);
            return new SuccessDataResult<List<Payment>>(result);
        }

        public IDataResult<Payment> GetById(int id)
        {
            var result = _paymentDal.Get(p=>p.Id==id);
            return new SuccessDataResult<Payment>(result,Messages.Geted);
        }

        public IResult Pay(Payment payment)
        {
            return new SuccessResult(Messages.PaymentSuccessful);
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.Added);
        }
    }
}
