namespace MicroServiceShop.Catalog.Dtos
{
    public class UpdateProductDetailDto
    {
        public string Id { get; set; } = null!;
        public string? Description { get; set; }
        public string? ProductInfo { get; set; }
        public string ProductId { get; set; } = null!;
    }
}
