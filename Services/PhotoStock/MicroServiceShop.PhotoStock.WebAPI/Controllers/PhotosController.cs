using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MassTransit;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.PhotoStock.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace MicroServiceShop.PhotoStock.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        private readonly Cloudinary _cloudinary;
        private readonly IRequestClient<UploadPhotoMessage> _requestClient;
        private readonly ILogger<PhotosController> _logger;

        public PhotosController(IConfiguration config, IRequestClient<UploadPhotoMessage> requestClient, ILogger<PhotosController> logger)
        {
            var cloudinaryAccount = new Account(
                config["CloudinarySettings:CloudName"],
                config["CloudinarySettings:ApiKey"],
                config["CloudinarySettings:ApiSecret"]);

            _cloudinary = new Cloudinary(cloudinaryAccount);

            _requestClient = requestClient;
            _logger = logger;
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
            
            var response = new Core.Dtos.Response<object>
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
                if (file.Length == 0)
                    continue;

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var fileData = memoryStream.ToArray();

                var message = new UploadPhotoMessage
                {
                    FileName = file.FileName,
                    FileData = fileData
                };

                // RequestClient ile Consumer'a istek gönderip sonucu bekliyoruz
                var response = await _requestClient.GetResponse<UploadPhotoResult>(message);

                if (response.Message.UploadedUrl != null)
                {
                    _logger.LogInformation("resim cloudinary e eklendi");
                    uploadResults.Add(new
                    {
                        Url = response.Message.UploadedUrl,
                        PublicId = response.Message.PublicId
                    });
                }
            }

            if (uploadResults.Count == 0)
                return BadRequest("No valid files were uploaded");

            var responseObject = new Core.Dtos.Response<List<object>>
            {
                Data = uploadResults,
                StatusCode = 200,
                IsSuccessful = true
            };

            return CreateActionResultInstance(responseObject);
        }

    }
}
