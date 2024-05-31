using BatDongSan.Models;
using BatDongSan.Services;
using DemoFramework_Core.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;

namespace BatDongSan.Controllers
{
	[Route("news")]
	public class NewsController : Controller
	{
		private NewsService NewsService;
		private IWebHostEnvironment webHostEnvironment;
		private IConfiguration configuration;

		public NewsController(NewsService _newsService, IWebHostEnvironment _webHostEnvironment, IConfiguration _configuration)
		{
			NewsService = _newsService;
			webHostEnvironment = _webHostEnvironment;
			configuration = _configuration;
		}
		[Produces("application/json")]
		[HttpGet("findallNews")]
		public IActionResult FindAll()
		{
			try
			{
				return Ok(NewsService.findAll());

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
				return Ok(new
				{
					rs = NewsService.findById(id)
				}
				);

			}
			catch
			{
				return BadRequest();
			}
		}
		[Consumes("application/json")]
		[Produces("application/json")]
		[HttpPost("create")]
		public IActionResult Create([FromBody] News news)
		{
			try
			{
				Debug.WriteLine(news.Content+"day la contemmmmmmmm");
				int productId = NewsService.create(news); // Tạo sản phẩm và lấy ID của sản phẩm
				Debug.WriteLine(productId+"day la i ddddddd");
				if (productId != -1)
				{
					// Nếu thành công, trả về kết quả thành công và ID của sản phẩm
					return Ok(new
					{
						Result = "Success",
						News_id = productId
					});
				}
				return BadRequest();
			}
			catch
			{
				return BadRequest();
			}
		}


	}
}
