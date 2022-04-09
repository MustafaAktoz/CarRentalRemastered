using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getDetails")]
        public IActionResult GetDetails()
        {
            var result = _rentalService.GetDetails();
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}
