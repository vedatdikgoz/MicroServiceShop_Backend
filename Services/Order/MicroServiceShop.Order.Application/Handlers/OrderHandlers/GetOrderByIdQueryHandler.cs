using MediatR;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;

        public GetOrderByIdQueryHandler(IRepository<Domain.Entities.Order> repository)
        {
            _repository = repository;
        }
        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new OrderDto
            {
                Id = values.Id,
                OrderDate = values.OrderDate,
                TotalPrice = values.TotalPrice,
                UserId = values.UserId,
            };
        }
    }
}
