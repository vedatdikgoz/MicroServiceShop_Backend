using MediatR;


namespace MicroServiceShop.Order.Application.Commands
{
    public class CreateOrderItemCommand : IRequest
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderId { get; set; }
    }
}
