using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(LoginDTO loginDTO);
        IDataResult<User> Register(RegisterDTO registerDTO);
        IDataResult<AccessToken> CreateAccessToken(User user);

        IResult UpdatePassword(UpdatePasswordDTO updatePasswordDTO);
    }
}
