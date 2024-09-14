using Business.Abstract;
using Entities.Dto;
using Entities.DTO.TravelDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController(IAboutService aboutService) : ControllerBase
    {
        private readonly IAboutService _aboutService = aboutService;

        [HttpPost("AddAbout")]
        public IActionResult Add(AboutDto aboutDto)
        {
            var result = _aboutService.Add(aboutDto);
            if (result.Success)
            {
                return Ok(aboutDto);
            }
            return BadRequest(aboutDto);
        }

        [HttpGet("GetByIdTravel")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = _aboutService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _aboutService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] int id, AboutDto aboutDto)
        {
            var result = _aboutService.Update(id, aboutDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _aboutService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
