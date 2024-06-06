using BatDongSan.Models;
using BatDongSan.Services;
using DemoFramework_Core.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BatDongSan.Controllers
{
    [Route("realstate")]
    public class RealstateController : Controller
    {
        private RealestateService realestateService;
        private IWebHostEnvironment webHostEnvironment;
        private IConfiguration configuration;

        public RealstateController(RealestateService _realestateService, IWebHostEnvironment _webHostEnvironment, IConfiguration _configuration)
        {
            realestateService = _realestateService;
            webHostEnvironment = _webHostEnvironment;
            configuration = _configuration;
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

		[Produces("application/json")]
		[HttpGet("findAll2")]
		public IActionResult FindAll2()
		{
			try
			{
				return Ok(realestateService.findAll2());

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
                return Ok(realestateService.findById(id));

            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findByUserSellTrue/{id}")]
        public IActionResult FindByUserSell(int id)
        {
            try
            {
                return Ok(realestateService.findByUserSellTrue(id));

            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findByUserSellFalse/{id}")]
        public IActionResult FindByUserSellFalse(int id)
        {
            try
            {
                return Ok(realestateService.findByUserSellFalse(id));

            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findByCityRegion/{city}/{region}")]
        public IActionResult FindByCityRegion(string city , string region)
        {
            try
            {
                return Ok(realestateService.findByCityRegion(city, region));

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
                Debug.WriteLine(realestate.Title);
                Debug.WriteLine(realestate.Describe);
                Debug.WriteLine(realestate.Bathrooms);
                Debug.WriteLine(realestate.Bedrooms);
                Debug.WriteLine(realestate.Price);
                Debug.WriteLine(realestate.Type);
                Debug.WriteLine(realestate.Acreage);
                Debug.WriteLine(realestate.Status);
                Debug.WriteLine(realestate.CreatedAt);
                Debug.WriteLine(realestate.City);
                Debug.WriteLine(realestate.Region);
                Debug.WriteLine(realestate.Street);
                Debug.WriteLine(realestate.TransactionType);
                int productId = realestateService.create(realestate); // Tạo sản phẩm và lấy ID của sản phẩm
                Debug.WriteLine(productId);
                if (productId != -1)
                {
                    // Nếu thành công, trả về kết quả thành công và ID của sản phẩm
                    return Ok(new
                    {
                        Result = "Success",
                        ProductId = productId
                    });
                }
                else
                {
                    // Nếu thất bại, trả về kết quả thất bại
                    return Ok(new
                    {
                        Result = "Faid"
                    });
                }
            }
            catch
            {
                
                return BadRequest();
            }
        }

        [HttpPost("expire")]
        public IActionResult MarkExpired()
        {
            try
            {
                
                realestateService.MarkExpired();
                return Ok(new
                {
                    Result = "Success"
                });
            }
            catch
            {
                return BadRequest();
            }
        }

		[Produces("application/json")]
		[HttpPut("Update")]
		public IActionResult Update([FromBody] Realestate realestate)
		{
			try
			{
				return Ok(realestateService.update(realestate));

			}
			catch
			{
				return BadRequest();
			}
		}
	}
        [Produces("application/json")]
        [HttpGet("totalById/{id}")]
        public IActionResult toTalById(int id)
        {
            try
            {
                return Ok(realestateService.totalById(id));

            }
            catch
            {
                return BadRequest();
            }
        }
    }

}
