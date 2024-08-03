using MediatR;
using MicroServiceShop.Order.Application.Commands;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Domain.Entities;


namespace MicroServiceShop.Order.Application.Handlers.OrderItemHandlers
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand>
    {
        private readonly IRepository<OrderItem> _repository;

        public CreateOrderItemCommandHandler(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

      
        public async Task Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new OrderItem
            {
                ProductAmount = request.ProductAmount,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductTotalPrice = request.ProductTotalPrice,
                OrderId = request.OrderId,
            });
        }
    }
}
