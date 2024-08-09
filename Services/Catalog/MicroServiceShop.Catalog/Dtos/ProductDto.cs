
namespace MicroServiceShop.Catalog.Dtos
{
    public class ProductDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public string CategoryId { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
    }
}
