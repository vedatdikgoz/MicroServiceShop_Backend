using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;
using MicroServiceShop.Order.Domain.Entities;
using System.Net;

namespace MicroServiceShop.Order.Application.Handlers.OrderItemHandlers
{
    public class GetOrderItemQueryHandler : IRequestHandler<GetOrderItemQuery, Response<List<OrderItemDto>>>
    {
        private readonly IRepository<OrderItem> _repository;

        public GetOrderItemQueryHandler(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

      
        public async Task<Response<List<OrderItemDto>>> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var orderItems = values.Select(x => new OrderItemDto
            {
                Id = x.Id,
                ProductAmount = x.ProductAmount,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice,
                ProductId = x.ProductId,
                OrderId = x.OrderId,
            }).ToList();

            return Response<List<OrderItemDto>>.Success(orderItems, 200);
        }
    }
}
