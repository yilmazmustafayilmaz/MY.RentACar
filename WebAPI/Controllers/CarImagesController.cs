using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _carImageService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId(int imageId)
        {
            var result = _carImageService.GetByImageId(imageId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

