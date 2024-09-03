using Business.Abstract;
using Business.BusinessAspect.Autofac.Secured;
using Core.Helpers.IoC;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController() : ControllerBase
    {
        private readonly ITravelService _travelService = ServiceTool.ServiceProvider.GetService<ITravelService>();

        [SecuredAspect("Admin,moderator")]
        //[ValidationAspect]
        [HttpPost("AddTravel")]
        public IActionResult Add(Travel travel)
        {
            var result = _travelService.Add(travel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByIdTravel")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = _travelService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _travelService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] int id, [FromBody] Travel travel)
        {
            var result = _travelService.Update(id, travel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _travelService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
