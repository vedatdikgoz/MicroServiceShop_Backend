using MediatR;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Handlers.OrderHandlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<OrderDto>>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;

        public GetOrderQueryHandler(IRepository<Domain.Entities.Order> repository)
        {
            _repository = repository;
        }

        public async Task<List<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new OrderDto 
            { 
                Id = x.Id,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId,
            }).ToList();
        }
    }
}
