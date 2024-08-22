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
                Country = request.Country,
                District = request.District,
                Email = request.Email,
                ZipCode = request.ZipCode,
                UserId = request.UserId,
                Name = request.Name,
                Surname = request.Surname,
                Phone = request.Phone,
                Province = request.Province,
                AdressLine = request.AdressLine

            }); 
        }
    }
}



