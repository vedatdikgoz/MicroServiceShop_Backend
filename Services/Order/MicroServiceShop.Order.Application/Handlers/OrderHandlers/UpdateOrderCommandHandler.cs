using MediatR;
using MicroServiceShop.Order.Application.Commands.OrderCommands;
using MicroServiceShop.Order.Application.Interfaces;

namespace MicroServiceShop.Order.Application.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IRepository<Domain.Entities.Order> _repository;

        public UpdateOrderCommandHandler(IRepository<Domain.Entities.Order> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.OrderDate = request.OrderDate;
            value.UserId = request.UserId;  
            value.TotalPrice = request.TotalPrice;
            await _repository.UpdateAsync(value);
        }
    }
}
