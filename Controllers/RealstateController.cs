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
              
                
                int productId = realestateService.create(realestate); // Tạo sản phẩm và lấy ID của sản phẩm
                Debug.WriteLine("Bedrooms: " + realestate.Bedrooms);

                Debug.WriteLine("Bathrooms: " + realestate.Bathrooms);
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


    }
}
