using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Queries
{
    public class GetOrderItemByIdQuery : IRequest<Response<OrderItemDto>>
    {
        public int Id { get; set; }

        public GetOrderItemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
