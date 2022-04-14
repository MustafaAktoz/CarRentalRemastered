using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getDTOById")]
        public IActionResult GetDTOById(int id)
        {
            var result=_userService.GetDTOById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("updateFirstAndLastName")]
        public IActionResult UpdateFirstAndLastName(UpdateFirstAndLastNameDTO updateFirstAndLastNameDTO)
        {
            var result = _userService.UpdateFirstAndLastName(updateFirstAndLastNameDTO);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("updateEmail")]
        public IActionResult UpdateEmail(UpdateEmailDTO updateEmailDTO)
        {
            var result = _userService.UpdateEmail(updateEmailDTO);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}
