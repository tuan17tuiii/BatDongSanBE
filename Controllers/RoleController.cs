using BatDongSan.Models;
using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;

namespace BatDongSan.Controllers
{
    [Route("role")]
    public class RoleController : Controller
    {
        private RoleService roleService;
        public RoleController(RoleService _roleService)
        {
            roleService = _roleService;
        }


        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Role role)
        {
            try
            {
                return Ok(new
                {
                    Result = roleService.create(role)
                });
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
                return Ok(roleService.findAll());

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
