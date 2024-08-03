using MediatR;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;
using MicroServiceShop.Order.Domain.Entities;

namespace MicroServiceShop.Order.Application.Handlers.OrderItemHandlers
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItemDto>
    {
        private readonly IRepository<OrderItem> _repository;

        public GetOrderItemByIdQueryHandler(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

      
        public async Task<OrderItemDto> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new OrderItemDto
            {
                Id = value.Id,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductAmount = value.ProductAmount,
                ProductPrice = value.ProductPrice,
                ProductTotalPrice = value.ProductTotalPrice,
                OrderId = value.OrderId
            };
        }
    }
}
