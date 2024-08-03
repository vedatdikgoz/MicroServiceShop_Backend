

namespace MicroServiceShop.Order.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }
}
