using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Results;

namespace MicroServiceShop.Order.Application.Queries
{
    public class GetAddressQuery : IRequest<Response<List<AddressDto>>>
    {
    }
}
