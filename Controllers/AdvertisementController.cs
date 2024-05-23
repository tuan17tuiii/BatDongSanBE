using BatDongSan.Models;
using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;

namespace BatDongSan.Controllers
{
    [Route("advertisement")]
    public class AdvertisementController : Controller
    {
        private AdvertisementService advertisementService; 
        public AdvertisementController(AdvertisementService _advertisementService)
        {
            advertisementService = _advertisementService;
        }
        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(advertisementService.findAll());

            }
            catch
            {
                return BadRequest();
            }
        }

		[Produces("application/json")]
		[HttpGet("findByID/{id}")]
		public IActionResult findByID(int id)
		{
			try
			{
				return Ok(advertisementService.findById(id));

			}
			catch
			{
				return BadRequest();
			}
		}

		[Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Advertisement advertisement)
        {
            try
            {
                return Ok(new
                {
                    Result = advertisementService.create(advertisement)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("update")]
        public IActionResult Update([FromBody] Advertisement advertisement)
        {
            try
            {
                return Ok(new
                {
                    Result = advertisementService.update(advertisement)
                });

            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    Result = advertisementService.delete(id)
                });

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
