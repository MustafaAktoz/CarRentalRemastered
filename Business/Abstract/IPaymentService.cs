using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Pay(Payment payment);

        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(Payment payment);
        IDataResult<Payment> GetById(int id);
        IDataResult<List<Payment>> GetAll();
        IDataResult<List<Payment>> GetAllByCustomerId(int customerId);

        IResult CheckIfThisCardIsAlreadySavedForThisCustomer(Payment payment);
        
    }
}
