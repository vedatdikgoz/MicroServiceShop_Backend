using MediatR;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Queries
{
    public class GetAddressByIdQuery : IRequest<AddressDto>
    {
        public int Id { get; set; }

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
