

namespace MicroServiceShop.Order.Application.Results
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
