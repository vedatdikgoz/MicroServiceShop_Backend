
namespace MicroServiceShop.Order.Application.Results
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? AdressLine { get; set; }
        public string? ZipCode { get; set; }
    }
}
