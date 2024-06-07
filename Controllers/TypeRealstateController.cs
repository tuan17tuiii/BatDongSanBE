using BatDongSan.Models;
using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;

namespace BatDongSan.Controllers
{
    [Route("typerealstate")]
    public class TypeRealstateController : Controller
    {   private TypeRealestateService typeRealestateService;
        public TypeRealstateController(TypeRealestateService _typeRealestateService)
        {
            typeRealestateService = _typeRealestateService;
        }
        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult findAll()
        {
            try
            {
                return Ok(typeRealestateService.findAll());
            }
            catch
            {
                return BadRequest();
            }
        }

		[Consumes("application/json")]
		[Produces("application/json")]
		[HttpPost("Create")]
		public IActionResult Create([FromBody] TypeRealestate typeRealestate)
		{
			try
			{
				return Ok(typeRealestateService.create(typeRealestate));
			}
			catch
			{
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			try
			{
				return Ok(typeRealestateService.delete(id));
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
