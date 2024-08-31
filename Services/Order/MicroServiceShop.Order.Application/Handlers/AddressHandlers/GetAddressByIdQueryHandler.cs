using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;
using MicroServiceShop.Order.Domain.Entities;


namespace MicroServiceShop.Order.Application.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Response<AddressDto>>
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

       

        public async Task<Response<AddressDto>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var address = new AddressDto
            {
                Id = value.Id,
                Country = value.Country,
                District = value.District,
                Email = value.Email,
                ZipCode = value.ZipCode,
                UserId = value.UserId,
                Name = value.Name,
                Surname = value.Surname,
                Phone = value.Phone,
                Province = value.Province,
                AdressLine = value.AdressLine
            };
            return Response<AddressDto>.Success(address, 200);
        }
    }
}
