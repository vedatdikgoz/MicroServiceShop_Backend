using MediatR;
using MicroServiceShop.Order.Application.Commands.AddressCommands;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Domain.Entities;

namespace MicroServiceShop.Order.Application.Handlers.AddressHandlers
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public DeleteAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAddressCommand command, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
