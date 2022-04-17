using Business.Abstract;
using Business.Constants;
using Core.Aspect.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        ICustomerService _customerService;

        public UserManager(IUserDal userDal, ICustomerService customerService)
        {
            _userDal = userDal;
            _customerService = customerService;
        }

        [TransactionScopeAspect]
        public IResult Add(User user)
        {
            var result = BusinessRules.Run(CheckIfEmailIsAlreadyRegistered(user.Email));
            if (!result.Success) return result;

            _userDal.Add(user);
            _customerService.FakeCustomerAdd(user.Id);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result, Messages.Listed);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result, Messages.Geted);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            return new SuccessDataResult<User>(result, Messages.Geted);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result, Messages.Listed);
        }

        public IDataResult<UserDTO> GetDTOById(int id)
        {
            var result = _userDal.GetDTO(u => u.Id == id);
            return new SuccessDataResult<UserDTO>(result, Messages.Geted);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        public IResult UpdateEmail(UpdateEmailDTO updateEmailDTO)
        {
            var rulesResult = BusinessRules.Run(CheckIfEmailIsAlreadyRegistered(updateEmailDTO.Email));
            if (!rulesResult.Success) return rulesResult;

            var result = _userDal.Get(u => u.Id == updateEmailDTO.Id);
            result.Email = updateEmailDTO.Email;
            _userDal.Update(result);
            return new SuccessResult(Messages.EmailUpdated);
        }

        public IResult UpdateFirstAndLastName(UpdateFirstAndLastNameDTO updateFirstAndLastNameDTO)
        {
            var result = _userDal.Get(u => u.Id == updateFirstAndLastNameDTO.Id);
            result.FirstName = updateFirstAndLastNameDTO.FirstName;
            result.LastName = updateFirstAndLastNameDTO.LastName;
            _userDal.Update(result);
            return new SuccessResult(Messages.FirstAndLastNameUpdated);
        }

        private IResult CheckIfEmailIsAlreadyRegistered(string email)
        {
            var userResult = _userDal.Get(u => u.Email == email);
            if (userResult != null) return new ErrorResult(Messages.EmailIsAlreadyRegistered);

            return new SuccessResult();
        }
    }
}
