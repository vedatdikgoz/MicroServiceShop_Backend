using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace MicroServiceShop.PhotoStock.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        private readonly Cloudinary _cloudinary;

        public PhotosController(IConfiguration config)
        {
            var cloudinaryAccount = new Account(
                config["CloudinarySettings:CloudName"],
                config["CloudinarySettings:ApiKey"],
                config["CloudinarySettings:ApiSecret"]);

            _cloudinary = new Cloudinary(cloudinaryAccount);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file provided");

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
                return BadRequest(uploadResult.Error.Message);
            
            var response = new Response<object>
            {
                Data = new { Url = uploadResult.SecureUrl.ToString(), PublicId = uploadResult.PublicId.ToString() },
                StatusCode = 200,
                IsSuccessful = true
            };

            return CreateActionResultInstance(response);
        }

        [HttpPost("upload-multiple")]
        public async Task<IActionResult> UploadMultiplePhotos(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return BadRequest("No files provided");

            var uploadResults = new List<object>();

            foreach (var file in files)
            {
                // Dosyanın geçerli olup olmadığını kontrol edin
                if (file.Length == 0)
                    continue; // Boş dosyaları atla

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                    return BadRequest(uploadResult.Error.Message);

                uploadResults.Add(new
                {
                    Url = uploadResult.SecureUrl.ToString(),
                    PublicId = uploadResult.PublicId.ToString()
                });
            }

            if (uploadResults.Count == 0)
                return BadRequest("No valid files were uploaded");

            var response = new Response<List<object>>
            {
                Data = uploadResults,
                StatusCode = 200,
                IsSuccessful = true
            };

            return CreateActionResultInstance(response);
        }

    }
}
