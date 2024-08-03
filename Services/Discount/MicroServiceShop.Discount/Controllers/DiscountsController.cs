using MicroServiceShop.Discount.Dtos;
using MicroServiceShop.Discount.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var result = await _discountService.GetAllDiscountCouponAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var result = await _discountService.GetDiscountCouponByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("DiscountCoupon oluşturuldu.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("DiscountCoupon silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("DiscountCoupon güncellendi");
        }
    }
}
