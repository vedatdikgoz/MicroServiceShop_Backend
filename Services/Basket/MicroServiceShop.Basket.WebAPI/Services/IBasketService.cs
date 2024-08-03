using MicroServiceShop.Basket.WebAPI.Dtos;
using MicroServiceShop.Core.Dtos;

namespace MicroServiceShop.Basket.WebAPI.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
