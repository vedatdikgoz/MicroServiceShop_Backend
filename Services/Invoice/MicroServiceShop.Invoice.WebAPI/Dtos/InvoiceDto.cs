using MicroServiceShop.Invoice.WebAPI.Entities;

namespace MicroServiceShop.Invoice.WebAPI.Dtos
{
    public class InvoiceDto
    {
        public string Id { get; set; }
        public Guid InvoiceNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string? BuyerId { get; set; }
        public string? Country { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? AddressLine { get; set; }
        public string? ZipCode { get; set; }
        public string? InvoiceId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
