using MediatR;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
