using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using MassTransit;
using MicroServiceShop.PhotoStock.WebAPI.Dtos;

namespace MicroServiceShop.PhotoStock.WebAPI.Consumers
{
    public class UploadPhotoConsumer : IConsumer<UploadPhotoMessage>
    {
        private readonly Cloudinary _cloudinary;

        public UploadPhotoConsumer(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
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
                // Hata yönetimi yapılabilir
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
