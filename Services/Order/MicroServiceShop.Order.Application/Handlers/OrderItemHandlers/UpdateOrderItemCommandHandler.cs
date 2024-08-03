using MediatR;
using MicroServiceShop.Order.Application.Commands;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Domain.Entities;


namespace MicroServiceShop.Order.Application.Handlers.OrderItemHandlers
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand>
    {
        private readonly IRepository<OrderItem> _repository;

        public UpdateOrderItemCommandHandler(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

      

        public async Task Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.ProductId = request.ProductId;
            value.OrderId = request.OrderId;
            value.ProductPrice = request.ProductPrice;
            value.ProductName = request.ProductName;
            value.ProductTotalPrice = request.ProductTotalPrice;
            value.ProductAmount = request.ProductAmount;
            await _repository.UpdateAsync(value);
        }
    }
}
