using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.JWT.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateAccessToken(user, operationClaims.Data);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.TokenCreated);
        }

        public IDataResult<User> Login(LoginDTO loginDTO)
        {
            var userResult = _userService.GetByEmail(loginDTO.Email);
            if (userResult.Data == null) return new ErrorDataResult<User>(Messages.EmailNotFound);

            var passwordVerificationResult = HashingHelper.VerifyPasswordHash(loginDTO.Password, userResult.Data.PasswordHash, userResult.Data.PasswordSalt);
            if (!passwordVerificationResult) return new ErrorDataResult<User>(Messages.PasswordIsIncorrect);

            return new SuccessDataResult<User>(userResult.Data, Messages.LoginSuccessful);
        }

        public IDataResult<User> Register(RegisterDTO registerDTO)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerDTO.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            var addUserResult = _userService.Add(user);
            if (!addUserResult.Success) return new ErrorDataResult<User>(addUserResult.Message);

            return new SuccessDataResult<User>(user, Messages.RegistrationSuccessful);
        }

        public IResult UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
        {
            var result = BusinessRules.Run(CheckIfPasswordsMatch(updatePasswordDTO.NewPassword,updatePasswordDTO.NewPasswordAgain));
            if (!result.Success) return result;

            var userResult = _userService.GetById(updatePasswordDTO.Id);

            var passwordVerificationResult = HashingHelper.VerifyPasswordHash(updatePasswordDTO.Password,userResult.Data.PasswordHash,userResult.Data.PasswordSalt);
            if (!passwordVerificationResult) return new ErrorResult(Messages.PasswordIsIncorrect);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(updatePasswordDTO.NewPassword,out passwordHash,out passwordSalt);

            userResult.Data.PasswordHash = passwordHash;
            userResult.Data.PasswordSalt = passwordSalt;

            var updateResult = _userService.Update(userResult.Data);
            if (!updateResult.Success) return updateResult;

            return new SuccessResult(Messages.PasswordUpdated);
        }

        private IResult CheckIfPasswordsMatch(string newPassword, string newPasswordAgain)
        {
            if (newPassword != newPasswordAgain)
                return new ErrorResult(Messages.PasswordsDoNotMatch);

            return new SuccessResult();
        }
    }
}
