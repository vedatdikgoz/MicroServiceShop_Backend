using MediatR;
using MicroServiceShop.Order.Application.Commands.AddressCommands;
using MicroServiceShop.Order.Application.Commands.OrderCommands;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Domain.Entities;

namespace MicroServiceShop.Order.Application.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

      
        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.Street = request.Street;
            value.City = request.City;
            value.District = request.District;
            value.ZipCode = request.ZipCode;
            value.UserId = request.UserId;
            await _repository.UpdateAsync(value);
        }
    }
}
