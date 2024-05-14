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
    }
}
