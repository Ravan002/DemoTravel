using Business.Abstract;
using Entities.Dto;
using Entities.Dto.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController(IFAQService fAQService) : ControllerBase
    {
        private readonly IFAQService _facService = fAQService;

        [HttpPost("AddFAQ")]
        public IActionResult Add(FAQDto addFaq)
        {
            var result = _facService.Add(addFaq);
            if (result.Success)
            {
                return Ok(addFaq);
            }
            return BadRequest(addFaq);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = _facService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _facService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] int id, FAQDto faqDto)
        {
            var result = _facService.Update(id, faqDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _facService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
