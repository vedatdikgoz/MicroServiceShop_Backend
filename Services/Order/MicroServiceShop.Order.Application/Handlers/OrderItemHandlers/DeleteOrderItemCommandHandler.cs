using MediatR;
using MicroServiceShop.Order.Application.Commands;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Domain.Entities;


namespace MicroServiceShop.Order.Application.Handlers.OrderItemHandlers
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand>
    {
        private readonly IRepository<OrderItem> _repository;

        public DeleteOrderItemCommandHandler(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

      
        public async Task Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
