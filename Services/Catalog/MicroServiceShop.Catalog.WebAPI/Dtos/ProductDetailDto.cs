
namespace MicroServiceShop.Catalog.WebAPI.Dtos
{
    public class ProductDetailDto
    {
        public string Id { get; set; } = null!;
        public string? Description { get; set; }
        public string? ProductInfo { get; set; }
        public string ProductId { get; set; } = null!;
    }
}
