using MediatR;


namespace MicroServiceShop.Order.Application.Commands.OrderCommands
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
