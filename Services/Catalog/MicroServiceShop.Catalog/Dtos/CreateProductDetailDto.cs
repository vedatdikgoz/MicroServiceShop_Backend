
namespace MicroServiceShop.Catalog.Dtos
{
    public class CreateProductDetailDto
    {
        public string? Description { get; set; }
        public string? ProductInfo { get; set; }
        public string ProductId { get; set; } = null!;
    }
}
