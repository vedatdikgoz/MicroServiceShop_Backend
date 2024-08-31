using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Response<OrderDto>>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;

        public GetOrderByIdQueryHandler(IRepository<Domain.Entities.Order> repository)
        {
            _repository = repository;
        }
        public async Task<Response<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var order = new OrderDto
            {
                Id = value.Id,
                OrderDate = value.OrderDate,
                TotalPrice = value.TotalPrice,
                UserId = value.UserId,
            };

            return Response<OrderDto>.Success(order, 200);
        }
    }
}
