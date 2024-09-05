using AutoMapper;
using MicroServiceShop.Discount.WebAPI.Dtos;
using MicroServiceShop.Discount.WebAPI.Entities;

namespace MicroServiceShop.Discount.WebAPI.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<Coupon, CreateCouponDto>().ReverseMap();
            CreateMap<Coupon, UpdateCouponDto>().ReverseMap();
        }
    }
}
