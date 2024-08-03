using MediatR;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Queries
{
    public class GetAddressQuery : IRequest<List<AddressDto>>
    {
    }
}
