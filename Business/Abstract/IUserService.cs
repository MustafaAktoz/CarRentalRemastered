using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> GetById(int id);
        IDataResult<UserDTO> GetDTOById(int id);
        IDataResult<User> GetByEmail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<List<OperationClaim>> GetClaims(User user);

        IResult UpdateFirstAndLastName(UpdateFirstAndLastNameDTO updateFirstAndLastNameDTO);
        IResult UpdateEmail(UpdateEmailDTO updateFirstAndLastNameDTO);
    }
}
