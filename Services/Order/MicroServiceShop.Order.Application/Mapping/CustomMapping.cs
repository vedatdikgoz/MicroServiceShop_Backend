using AutoMapper;
using MicroServiceShop.Order.Application.Results;
using MicroServiceShop.Order.Domain.OrderAggregate;

namespace MicroServiceShop.Order.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
