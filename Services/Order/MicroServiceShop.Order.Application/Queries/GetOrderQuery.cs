using MediatR;
using MicroServiceShop.Order.Application.Results;


namespace MicroServiceShop.Order.Application.Queries
{
    public class GetOrderQuery : IRequest<List<OrderDto>>
    {
    }
}
