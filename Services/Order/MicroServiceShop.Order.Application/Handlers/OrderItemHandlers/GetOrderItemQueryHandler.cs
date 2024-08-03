using MediatR;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;
using MicroServiceShop.Order.Domain.Entities;

namespace MicroServiceShop.Order.Application.Handlers.OrderItemHandlers
{
    public class GetOrderItemQueryHandler : IRequestHandler<GetOrderItemQuery, List<OrderItemDto>>
    {
        private readonly IRepository<OrderItem> _repository;

        public GetOrderItemQueryHandler(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

      
        public async Task<List<OrderItemDto>> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new OrderItemDto
            {
                Id = x.Id,
                ProductAmount = x.ProductAmount,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice,
                ProductId = x.ProductId,
                OrderId = x.OrderId,
            }).ToList();
        }
    }
}
