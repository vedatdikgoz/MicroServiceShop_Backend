using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<Response<OrderDto>>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
