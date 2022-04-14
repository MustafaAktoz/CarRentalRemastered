using Business.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var result = _authService.Login(loginDTO);
            if (!result.Success) return BadRequest(result);

            var createAccessTokenResult = _authService.CreateAccessToken(result.Data);
            if (!result.Success) return BadRequest(result);

            var newSuccessDataResult = new SuccessDataResult<AccessToken>(createAccessTokenResult.Data, result.Message);
            return Ok(newSuccessDataResult);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            var result = _authService.Register(registerDTO);
            if (!result.Success) return BadRequest(result);

            var createAccessTokenResult = _authService.CreateAccessToken(result.Data);
            if (!result.Success) return BadRequest(result);

            var newSuccessDataResult = new SuccessDataResult<AccessToken>(createAccessTokenResult.Data, result.Message);
            return Ok(newSuccessDataResult);
        }

        [HttpPost("updatePassword")]
        public IActionResult UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
        {
            var result = _authService.UpdatePassword(updatePasswordDTO);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}
