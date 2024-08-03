using MediatR;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Queries
{
    public class GetOrderItemByIdQuery : IRequest<OrderItemDto>
    {
        public int Id { get; set; }

        public GetOrderItemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
