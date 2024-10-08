﻿using Business.Abstract;
using Entities.Concrete;
using Entities.DTO.TravelDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController(ITravelService travelService) : ControllerBase
    {
        private readonly ITravelService _travelService = travelService;

        [HttpPost("AddTravel")]
        public IActionResult Add(TravelDto travelDto)
        {
            if (travelDto == null)
            {
                return BadRequest();
            }
            var result = _travelService.Add(travelDto);
            if (result.Success)
            {
                return Ok(travelDto);
            }
            return BadRequest(travelDto);
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
        [HttpGet("GetTravelWithDetail")]
        public IActionResult GetTravelWithDetail([FromQuery] int id)
        {
            var result = _travelService.GetTravelWithDetail(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] int id, TravelDto travel)
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
