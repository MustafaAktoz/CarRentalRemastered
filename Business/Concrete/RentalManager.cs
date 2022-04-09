using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result=BusinessRules.Run(CheckIfTheCarHasBeenDelivered(rental));
            if (!result.Success) return result;

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result, Messages.Listed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);
            return new SuccessDataResult<Rental>(result, Messages.Geted);
        }

        public IDataResult<List<RentalDetailDTO>> GetDetails()
        {
            var result = _rentalDal.GetDetails();
            return new SuccessDataResult<List<RentalDetailDTO>>(result,Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfTheCarHasBeenDelivered(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId&&r.ReturnDate==null);
            if (result != null)
                if (rental.ReturnDate == null || rental.ReturnDate > result.RentDate)
                    return new ErrorResult(Messages.TheCarHasNotBeenDeliveredYet);

            return new SuccessResult();
        }
    }
}
