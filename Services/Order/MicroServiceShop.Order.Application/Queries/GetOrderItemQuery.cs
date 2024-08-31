using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Queries
{
    public class GetOrderItemQuery : IRequest<Response<List<OrderItemDto>>>
    {
    }
}
