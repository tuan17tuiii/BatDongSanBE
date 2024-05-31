using BatDongSan.Models;
using BatDongSan.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

		[Produces("application/json")]
		[HttpGet("findAll")]
		public IActionResult findAll()
		{
			try
			{
				return Ok(userService.findAll());

			}
			catch(Exception e)
			{
				Debug.WriteLine(e.Message);
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpGet("findAllAdmin")]
		public IActionResult findAllAdmin()
		{
			try
			{
				return Ok(userService.findAllAdmin());

			}
			catch
			{
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpGet("findAllUser")]
		public IActionResult findAllUser()
		{
			try
			{
				return Ok(userService.findAllUser ());

			}
			catch
			{
				return BadRequest();
			}
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
		[HttpPost("loginAdmin")]
		public IActionResult loginAdmin([FromBody] User user)
		{
			try
			{
				return Ok(new{ 
					Result = userService.LoginAdmin(user.Username, user.Password) 
				});

			}
			catch
			{
				return BadRequest();
			}
		}

		[Consumes("application/json")]
		[Produces("application/json")]
		[HttpPost("loginUser")]
		public IActionResult loginUser([FromBody] User user)
		{
			try
			{
				return Ok(new
				{
					Result = userService.LoginUser(user.Username, user.Password)
				});

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
		[HttpGet("findById/{id}")]
		public IActionResult findById(int id)
		{
			try
			{
				return Ok(userService.findById(id));

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

		[Produces("application/json")]
		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			try
			{
				return Ok(userService.delete(id));
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}
	}
}
