using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;


namespace MicroServiceShop.Order.Application.Handlers.OrderHandlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrderByUserIdQuery, Response<List<OrderDto>>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByUserIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<Response<List<OrderDto>>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderRepository.GetOrderByUserId(request.userId);

            if (values.Count == 0)
            {
                return Response<List<OrderDto>>.Success([], 200);
            }

            var ordersDto = values.Select(x => new OrderDto
            {
                Id = x.Id,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId,
            }).ToList();

            return Response<List<OrderDto>>.Success(ordersDto, 200);
        }
    }
}
