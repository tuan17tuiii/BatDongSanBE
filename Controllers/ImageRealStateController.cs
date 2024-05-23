using BatDongSan.Models;
using BatDongSan.Services;
using DemoFramework_Core.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace BatDongSan.Controllers
{
    [Route("image")]
    public class ImageRealStateController : Controller
    {

        private ImageRealestateService imageRealestateService;
        private IWebHostEnvironment webHostEnvironment;
        private IConfiguration configuration;

        public ImageRealStateController(ImageRealestateService _imageRealestateService, IWebHostEnvironment _webHostEnvironment, IConfiguration _configuration)
        {
            imageRealestateService =    _imageRealestateService;
            webHostEnvironment = _webHostEnvironment;
            configuration = _configuration;
        }
        private bool IsImage(IFormFile file)
        {
            // Kiểm tra phần mở rộng của tệp có phải là một hình ảnh không
            string[] allowedImageExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            return allowedImageExtensions.Contains(fileExtension);
        }
        [Produces("application/json")]
        [HttpPost("select")]
        public IActionResult Select(IFormFile[] files, int id)//nhan tung gia tri rieng le
        {
            if (files.Length > 4)
            {
                return BadRequest();
            }
            try
            {
                var fileNames = new List<string>();
                foreach (var file in files)
                {
                    if (!IsImage(file))
                    {
                        return BadRequest(new { message = "Tệp không phải là một hình ảnh hợp lệ." });
                    }
                    var fileName = FileHelpers.GenerateFileName(file.FileName);
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    fileNames.Add(configuration["ImageUrl"] + fileName);
                }
                return Ok(new
                {
                    FileNames = fileNames
                });

            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpPost("uploads")]
        public IActionResult Uploads(IFormFile[] files , int id , List<string> fileNames)
        {
            try
            {

               
                foreach (var fileName in fileNames)
                {
                    if (fileName == "null")
                    {
                        Debug.WriteLine("fileName: " + fileName);
                        var imageRealState = new ImageRealestate();
                        imageRealState.RealestateId = id;
                        imageRealState.UrlImage = "no-image1.PNG";
                        Create(imageRealState);
                    }
                    else
                    {
                        Debug.WriteLine("fileName: " + fileName);
                        var imageRealState = new ImageRealestate();
                        imageRealState.RealestateId = id;
                        var imagePath = fileName.Substring(fileName.IndexOf("images/") + "images/".Length);
                        imageRealState.UrlImage = imagePath;
                        Create(imageRealState);
                    }
                        
                    
                }
                return Ok(new
                {
                    FileNames = fileNames
                });

            }
            catch
            {
                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] ImageRealestate imageRealestate)
        {
            try
            {
                return Ok(new
                {
                    Result = imageRealestateService.create(imageRealestate)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {   
                return Ok(imageRealestateService.findAll());

            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findByRealstateId/{id}")]
        public IActionResult findByRealstateId(int id)
        {
            try
            {
                return Ok(imageRealestateService.findByRealstateId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
