using MediatR;
using MicroServiceShop.Order.Application.Interfaces;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;
using MicroServiceShop.Order.Domain.Entities;

namespace MicroServiceShop.Order.Application.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, List<AddressDto>>
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

       
        public async Task<List<AddressDto>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new AddressDto
            {
                Id = x.Id,
                City = x.City,
                District = x.District,
                Street = x.Street,
                ZipCode = x.ZipCode,
                UserId = x.UserId,
            }).ToList();
        }
    }
}
