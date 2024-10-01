using MicroServiceShop.Invoice.WebAPI.Entities;

namespace MicroServiceShop.Invoice.WebAPI.Dtos
{
    public class InvoiceDto
    {
        public string Id { get; set; } = null!;
        public Guid InvoiceNumber { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string BuyerId { get; set; }
        public Address Address { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal TotalPrice => OrderItems.Sum(item => item.Quantity * item.Price);
    }
}
