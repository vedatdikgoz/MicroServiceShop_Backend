
namespace MicroServiceShop.Core.Messages
{
    public class CreateInvoiceMessageCommand
    {
        public CreateInvoiceMessageCommand()
        {
            OrderItems = new List<InvoiceOrderItemDto>();
        }
        public Guid InvoiceNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string BuyerId { get; set; }
        public string? Country { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? AddressLine { get; set; }
        public string? ZipCode { get; set; }
        public List<InvoiceOrderItemDto> OrderItems { get; set; } 
    }


    public class InvoiceOrderItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
