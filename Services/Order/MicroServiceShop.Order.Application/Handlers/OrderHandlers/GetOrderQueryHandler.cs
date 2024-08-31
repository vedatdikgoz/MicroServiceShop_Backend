using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Handlers.OrderHandlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Response<List<OrderDto>>>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;

        public GetOrderQueryHandler(IRepository<Domain.Entities.Order> repository)
        {
            _repository = repository;
        }

        public async Task<Response<List<OrderDto>>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var orders = values.Select(x => new OrderDto 
            { 
                Id = x.Id,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId,
            }).ToList();

            return Response<List<OrderDto>>.Success(orders, 200);
        }
    }
}
