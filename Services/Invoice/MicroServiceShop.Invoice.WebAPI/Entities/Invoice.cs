namespace MicroServiceShop.Invoice.WebAPI.Entities
{
    public class Invoice
    {
        public string Id { get; set; } = null!;
        public Guid InvoiceNumber { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string BuyerId { get; set; }
        public Address Address { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice => OrderItems.Sum(item => item.Quantity * item.Price);
    }

    
    public class Address
    {
        public string? Country { get; private set; }
        public string? Province { get; private set; }
        public string? District { get; private set; }
        public string? AddressLine { get; private set; }
        public string? ZipCode { get; private set; }
    }

    public class OrderItem
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUrl { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
    }   
}
