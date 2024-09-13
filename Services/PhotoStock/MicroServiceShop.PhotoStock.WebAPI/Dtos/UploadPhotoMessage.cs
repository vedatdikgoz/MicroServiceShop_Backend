namespace MicroServiceShop.PhotoStock.WebAPI.Dtos
{
    public class UploadPhotoMessage
    {
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
    }
}
