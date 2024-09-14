using Business.Abstract;
using Entities.Dto;
using Entities.Dto.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpPost("AddCategory")]
        public IActionResult Add(AddCategoryDto addCategoryDto)
        {
            var result = _categoryService.Add(addCategoryDto);
            if (result.Success)
            {
                return Ok(addCategoryDto);
            }
            return BadRequest(addCategoryDto);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = _categoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] int id, AddCategoryDto addCategoryDto)
        {
            var result = _categoryService.Update(id, addCategoryDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _categoryService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
