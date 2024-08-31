using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;
using MicroServiceShop.Order.Domain.Entities;
using System.Net;

namespace MicroServiceShop.Order.Application.Handlers.OrderItemHandlers
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, Response<OrderItemDto>>
    {
        private readonly IRepository<OrderItem> _repository;

        public GetOrderItemByIdQueryHandler(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

      
        public async Task<Response<OrderItemDto>> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var orderItem = new OrderItemDto
            {
                Id = value.Id,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductAmount = value.ProductAmount,
                ProductPrice = value.ProductPrice,
                ProductTotalPrice = value.ProductTotalPrice,
                OrderId = value.OrderId
            };

            return Response<OrderItemDto>.Success(orderItem, 200);
        }
    }
}
