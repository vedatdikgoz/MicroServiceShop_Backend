namespace MicroServiceShop.Invoice.WebAPI.Dtos
{
    public class CreateInvoiceOrderItemDto
    {
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
