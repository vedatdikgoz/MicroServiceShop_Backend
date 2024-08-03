
namespace MicroServiceShop.Catalog.Dtos
{
    public class ProductImageDto
    {
        public string Id { get; set; } = null!;
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string ProductId { get; set; } = null!;
    }
}
