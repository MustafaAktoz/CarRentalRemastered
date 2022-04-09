using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getDetailById")]
        public IActionResult GetDetailById(int id)
        {
            var result = _carService.GetDetailById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getAllByBrandId")]
        public IActionResult GetAllByBrandId(int brandId)
        {
            var result = _carService.GetAllByBrandId(brandId);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getAllByColorId")]
        public IActionResult GetAllByColorId(int colorId)
        {
            var result = _carService.GetAllByColorId(colorId);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getDetails")]
        public IActionResult GetDetails()
        {
            var result = _carService.GetDetails();
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getDetailsByBrandId")]
        public IActionResult GetDetailsByBrandId(int brandId)
        {
            var result = _carService.GetDetailsByBrandId(brandId);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getDetailsByColorId")]
        public IActionResult GetDetailsByColorId(int colorId)
        {
            var result = _carService.GetDetailsByColorId(colorId);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

    }
}
