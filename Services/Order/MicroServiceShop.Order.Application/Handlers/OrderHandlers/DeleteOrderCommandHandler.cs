using MediatR;
using MicroServiceShop.Order.Application.Commands.OrderCommands;
using MicroServiceShop.Order.Application.Interfaces;

namespace MicroServiceShop.Order.Application.Handlers.OrderHandlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;

        public DeleteOrderCommandHandler(IRepository<Domain.Entities.Order> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
