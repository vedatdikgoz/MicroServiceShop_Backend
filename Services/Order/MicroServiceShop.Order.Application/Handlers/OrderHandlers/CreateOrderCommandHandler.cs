using MediatR;
using MicroServiceShop.Order.Application.Commands.OrderCommands;
using MicroServiceShop.Order.Application.Interfaces;

namespace MicroServiceShop.Order.Application.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;

        public CreateOrderCommandHandler(IRepository<Domain.Entities.Order> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Domain.Entities.Order
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
            });
        }
    }
}
