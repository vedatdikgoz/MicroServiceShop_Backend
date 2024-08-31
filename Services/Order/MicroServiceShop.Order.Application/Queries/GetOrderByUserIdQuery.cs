using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Results;


namespace MicroServiceShop.Order.Application.Queries
{
    public class GetOrderByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string userId { get; set; }

        public GetOrderByUserIdQuery(string userid)
        {
            userId = userid;
        }
    }
}
