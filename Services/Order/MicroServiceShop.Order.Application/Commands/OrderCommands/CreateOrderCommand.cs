using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Dtos;
using MicroServiceShop.Order.Application.Results;



namespace MicroServiceShop.Order.Application.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
    {
        public string? BuyerId { get; set; }

        public List<OrderItemDto>? OrderItems { get; set; }

        public AddressDto? Address { get; set; }
    }
}
