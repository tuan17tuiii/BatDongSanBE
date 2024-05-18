using BatDongSan.Models;
using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;

namespace BatDongSan.Controllers
{
	[Route("account")]
	public class AccountController : Controller
	{
		private UserService userService;
		public AccountController(UserService _userService)
		{
			this.userService = _userService;
		}

		[Consumes("application/json")]
		[Produces("application/json")]
		[HttpPost("register")]
		public IActionResult register([FromBody] User user)
		{
			try
			{
				return Ok(userService.create(user));

			}
			catch
			{
				return BadRequest();
			}
		}

		[Consumes("application/json")]
		[Produces("application/json")]
		[HttpPost("login")]
		public IActionResult login([FromBody] User user)
		{
			try
			{
				return Ok(userService.Login(user.Username, user.Password));

			}
			catch
			{
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpGet("findByUsername/{username}")]
		public IActionResult findByUsername(string username)
		{
			try
			{
				return Ok(userService.findByUsername(username));

			}
			catch
			{
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpGet("Verify/{code}/{username}")]
		public IActionResult Verify(string code,string username)
		{
			try
			{
				return Ok(userService.Verify(code, username));

			}
			catch
			{
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpPut("Update")]
		public IActionResult Update([FromBody] User user)
		{
			try
			{
				return Ok(userService.update(user));

			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
