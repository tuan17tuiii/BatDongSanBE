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
		[HttpPost("login")]
		public IActionResult login([FromBody] User user)
		{
			try
			{
				return Ok(new
				{
					Result = userService.Login(user.Username, user.Password)
				});

			}
			catch(Exception e)
			{
				return BadRequest(e.InnerException);
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


		[Produces("application/json")]
		[HttpGet("PasswordVerify/{password}/{username}")]
		public IActionResult PasswordVerify(string password, string username)
		{
			try
			{
				return Ok(userService.PasswordVerify(password, username));
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpGet("ChangePass/{password}/{username}")]
		public IActionResult ChangePass(string password, string username)
		{
			try
			{
				return Ok(userService.ChangePass(password, username));
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}

		[Produces("application/json")]
		[HttpGet("Exists/{username}/{email}")]
		public IActionResult Exists(string username, string email)
		{
			try
			{
				return Ok(userService.AccountExists(username, email));
			}
			catch (Exception ex)
			{
				return BadRequest("loi =>>>>>>>>>>>>>>>>>" + ex.Message);
			}
		}
	}
}
