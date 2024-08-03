using MicroServiceShop.Discount.Dtos;

namespace MicroServiceShop.Discount.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<List<CouponDto>> GetAllDiscountCouponAsync();
        Task<CouponDto> GetDiscountCouponByIdAsync(int id);
        Task CreateDiscountCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);

    }
}
