using MediatR;
using MicroServiceShop.Order.Application.Commands.AddressCommands;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Domain.Entities;


namespace MicroServiceShop.Order.Application.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Address
            {
                City = request.City,
                District = request.District,
                Street = request.Street,
                ZipCode = request.ZipCode,
                UserId = request.UserId,
            }); ;
        }
    }
}
