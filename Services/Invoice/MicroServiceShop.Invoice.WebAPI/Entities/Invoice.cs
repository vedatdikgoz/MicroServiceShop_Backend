namespace MicroServiceShop.Invoice.WebAPI.Entities
{
    public class Invoice
    {
        public string Id { get; set; }
        public Guid InvoiceNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string BuyerId { get; set; }
        public string? Country { get; private set; }
        public string? Province { get; private set; }
        public string? District { get; private set; }
        public string? AddressLine { get; private set; }
        public string? ZipCode { get; private set; }
        public List<InvoiceOrderItem> OrderItems { get; private set; } = new();

        // TotalPrice property calculated based on OrderItems
        public decimal TotalPrice => OrderItems?.Sum(item => item.Quantity * item.Price) ?? 0;

        // Method to set address
        public void SetAddress(string country, string province, string district, string addressLine, string zipCode)
        {
            Country = country;
            Province = province;
            District = district;
            AddressLine = addressLine;
            ZipCode = zipCode;
        }

        // Method to add order items
        public void AddOrderItem(InvoiceOrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }
    }
}