using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation.FluentValidation;
using Core.Utilities.Business;
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

        [FluentValidationAspect(typeof(FVPaymentValidator))]
        public IResult Add(Payment payment)
        {
            var result = BusinessRules.Run(CheckIfThisCardIsAlreadySavedForThisCustomer(payment));
            if (!result.Success) return result;

            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentInformationSuccessfullySaved);
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var result = _paymentDal.GetAll();
            return new SuccessDataResult<List<Payment>>(result, Messages.Listed);
        }

        public IDataResult<List<Payment>> GetAllByCustomerId(int customerId)
        {
            var result = _paymentDal.GetAll(p => p.CustomerId == customerId);
            return new SuccessDataResult<List<Payment>>(result, Messages.Listed);
        }

        public IDataResult<Payment> GetById(int id)
        {
            var result = _paymentDal.Get(p => p.Id == id);
            return new SuccessDataResult<Payment>(result, Messages.Geted);
        }

        public IResult CheckIfThisCardIsAlreadySavedForThisCustomer(Payment payment)
        {
            var result = _paymentDal.Get(p => p.CustomerId == payment.CustomerId && p.CardNumber == payment.CardNumber);
            if (result != null) return new ErrorResult(Messages.ThisCardIsAlreadyRegisteredForThisCustomer);

            return new SuccessResult();
        }

        [FluentValidationAspect(typeof(FVPaymentValidator))]
        public IResult Pay(Payment payment)
        {
            return new SuccessResult(Messages.PaymentSuccessful);
        }

        [FluentValidationAspect(typeof(FVPaymentValidator))]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.Updated);
        }
    }
}
