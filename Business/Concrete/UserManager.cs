using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
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

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
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
            return new SuccessDataResult<List<User>>(result,Messages.Listed);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u=>u.Id==id);
            return new SuccessDataResult<User>(result, Messages.Geted);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
