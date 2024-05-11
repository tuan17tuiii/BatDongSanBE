using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;

namespace BatDongSan.Controllers
{
    [Route("city")]
    public class CityController : Controller
    {
        private CityService cityService; 
        public CityController(CityService _cityService)
        {
            this.cityService = _cityService;
        }
        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(cityService.findAll());

            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findById/{id}")]
        public IActionResult FindById(int id)
        {
            try
            {
                return Ok(cityService.findById(id));

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
