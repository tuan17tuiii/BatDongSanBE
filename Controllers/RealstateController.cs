using BatDongSan.Models;
using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;

namespace BatDongSan.Controllers
{
    [Route("realstate")]
    public class RealstateController : Controller
    {
        private RealestateService realestateService;
        public RealstateController(RealestateService _realestateService)
        {
            realestateService = _realestateService;
        }
        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(realestateService.findAll());

            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Realestate realestate)
        {
            try
            {
                return Ok(new
                {
                    Result = realestateService.create(realestate)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
