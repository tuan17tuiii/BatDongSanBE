using BatDongSan.Models;
using BatDongSan.Services;
using DemoFramework_Core.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BatDongSan.Controllers
{
	[Route("account")]
	public class AccountController : Controller
	{
		private UserService userService;
		private IWebHostEnvironment webHostEnvironment;
		private IConfiguration configuration;
		public AccountController(UserService _userService, IWebHostEnvironment _webHostEnvironment, IConfiguration _configuration)
		{
			this.userService = _userService;
			this.webHostEnvironment = _webHostEnvironment;
			this.configuration = _configuration;
		}

		[Produces("application/json")]
		[HttpGet("findAll")]
		public IActionResult findAll()
		{
			try
			{
				return Ok(userService.findAll());

			}
			catch (Exception e)
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
				return Ok(userService.findAllUser());

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
			catch (Exception e)
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
			catch (Exception ex)
			{
				return BadRequest("loi ->>>>>>>>>>>>>>>>" + ex.Message);
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
		public IActionResult Verify(string code, string username)
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
		public IActionResult Update([FromBody] User user, IFormFile file)
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
		[HttpPost("Upload")]
		public IActionResult Upload(IFormFile file)
		{
			try
			{
				var fileName = FileHelpers.GenerateFileName(file.FileName);
				var path = Path.Combine(webHostEnvironment.WebRootPath, "Images", fileName);
				using (var filestream = new FileStream(path, FileMode.Create))
				{
					file.CopyTo(filestream);
				}

				return Ok(new
				{
					Url = configuration["ImageUrl"] + fileName
				});
			}
			catch
			{
				return BadRequest(); // tra ve ma 400
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
