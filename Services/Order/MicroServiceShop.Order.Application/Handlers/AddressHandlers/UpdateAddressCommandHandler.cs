using MediatR;
using MicroServiceShop.Order.Application.Commands.AddressCommands;
using MicroServiceShop.Order.Application.Commands.OrderCommands;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Domain.Entities;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Emit;
using System.Xml.Linq;

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
            value.Country = request.Country;
            value.District = request.District;
            value.Email = request.Email;
            value.ZipCode = request.ZipCode;
            value.UserId = request.UserId;
            value.Name = request.Name;
            value.Surname = request.Surname;
            value.Phone = request.Phone;
            value.Province = request.Province;
            value.AdressLine = request.AdressLine;
            await _repository.UpdateAsync(value);
        }
    }
}
