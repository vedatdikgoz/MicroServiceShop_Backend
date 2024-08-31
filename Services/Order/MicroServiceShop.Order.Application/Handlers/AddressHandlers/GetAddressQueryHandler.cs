using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;
using MicroServiceShop.Order.Domain.Entities;

namespace MicroServiceShop.Order.Application.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, Response<List<AddressDto>>>
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

       
        public async Task<Response<List<AddressDto>>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var address = values.Select(x => new AddressDto
            {
                Id = x.Id,
                Country = x.Country,
                District = x.District,
                Email = x.Email,
                ZipCode = x.ZipCode,
                UserId = x.UserId,
                Name = x.Name,
                Surname = x.Surname,
                Phone = x.Phone,
                Province = x.Province,
                AdressLine = x.AdressLine
            }).ToList();

            return Response<List<AddressDto>>.Success(address, 200);
        }
    }
}
