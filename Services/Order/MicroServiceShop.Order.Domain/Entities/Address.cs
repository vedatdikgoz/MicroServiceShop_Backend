
namespace MicroServiceShop.Order.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;

        public string? City { get; set; }
        public string? District { get; set; }

        public string? Street { get; set; }

        public string? ZipCode { get; set; }

    }
}
