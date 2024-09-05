using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Discount.WebAPI.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroServiceShop.Discount.WebAPI.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<Response<List<CouponDto>>> GetAllDiscountCouponAsync();
        Task<Response<CouponDto>> GetDiscountCouponByIdAsync(int id);
        Task<Response<NoContent>> CreateDiscountCouponAsync(CreateCouponDto createCouponDto);
        Task<Response<NoContent>> UpdateDiscountCouponAsync(UpdateCouponDto updateCouponDto);
        Task<Response<NoContent>> DeleteDiscountCouponAsync(int id);
        Task<Response<CouponDto>> GetByCodeAndUserId(string code);

    }
}
