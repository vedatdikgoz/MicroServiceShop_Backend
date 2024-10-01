
namespace MicroServiceShop.Core.Messages
{
    public class CreateInvoiceMessageCommand
    {
        public Guid InvoiceNumber { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string BuyerId { get; set; }
        public AddressDto Address { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal TotalPrice => OrderItems.Sum(item => item.Quantity * item.Price);
    }

    public class AddressDto
    {
        public string? Country { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? AddressLine { get; set; }
        public string? ZipCode { get; set; }
    }

    public class OrderItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

}
