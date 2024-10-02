namespace MicroServiceShop.Invoice.WebAPI.Entities
{
    public class InvoiceOrderItem
    {
        public int Id { get; set; }
        public string ProductId { get; private set; } = null!;
        public string ProductName { get; private set; } = null!;
        public string? PictureUrl { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string InvoiceId { get; private set; } = null!;
        public Invoice Invoice { get; set; } = null!;

        public InvoiceOrderItem(string productId, string productName, decimal price, int quantity, string pictureUrl)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            PictureUrl = pictureUrl;
        }
    }
}
