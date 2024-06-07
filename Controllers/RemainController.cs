using BatDongSan.Models;
using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;

namespace BatDongSan.Controllers
{
    [Route("remain")]
    public class RemainController : Controller
    {
        private RemainService remainService;
        public RemainController(RemainService _remainService)
        {
            remainService = _remainService;
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Remain remain)
        {
            try
            {
                return Ok(
                   remainService.create(remain)
                );
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult findAll()
        {
            try
            {
                return Ok(remainService.findAll());

            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("update")]
        public IActionResult Update([FromBody] Remain remain)
        {
            try
            {
                return Ok(remainService.update(remain));

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
                return Ok(remainService.findById(id));

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
