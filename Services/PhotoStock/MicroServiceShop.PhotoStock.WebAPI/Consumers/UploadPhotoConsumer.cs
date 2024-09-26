using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using MassTransit;
using MicroServiceShop.PhotoStock.WebAPI.Dtos;

namespace MicroServiceShop.PhotoStock.WebAPI.Consumers
{
    public class UploadPhotoConsumer : IConsumer<UploadPhotoMessage>
    {
        private readonly Cloudinary _cloudinary;
        private readonly ILogger<UploadPhotoConsumer> _logger;

        public UploadPhotoConsumer(Cloudinary cloudinary,ILogger<UploadPhotoConsumer> logger)
        {
            _cloudinary = cloudinary;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UploadPhotoMessage> context)
        {
            var fileData = context.Message.FileData;
            var fileName = context.Message.FileName;

            using var stream = new MemoryStream(fileData);

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, stream),
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                _logger.LogInformation("Resimler yüklenirken bir hata oluştu");
            }
            else
            {
                // Yükleme işlemi başarılı olduğunda yanıtı geri döneriz
                await context.RespondAsync(new UploadPhotoResult
                {
                    UploadedUrl = uploadResult.SecureUrl.ToString(),
                    PublicId = uploadResult.PublicId.ToString()
                });
            }
        }
    }

}
