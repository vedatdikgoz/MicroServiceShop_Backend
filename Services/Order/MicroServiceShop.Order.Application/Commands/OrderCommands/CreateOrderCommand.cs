using MediatR;



namespace MicroServiceShop.Order.Application.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest
    {
        public string UserId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
