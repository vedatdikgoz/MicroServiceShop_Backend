using MicroServiceShop.Invoice.WebAPI.Entities;

namespace MicroServiceShop.Invoice.WebAPI.Dtos
{
    public class CreateInvoiceDto
    {
        public string BuyerId { get; set; }
        public Guid InvoiceNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Country { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? AddressLine { get; set; }
        public string? ZipCode { get; set; }
        public List<CreateInvoiceOrderItemDto> OrderItems { get; set; } = new();
        public decimal TotalPrice { get; set; }
    }
}
