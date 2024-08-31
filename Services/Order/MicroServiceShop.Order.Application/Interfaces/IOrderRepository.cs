

namespace MicroServiceShop.Order.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Domain.Entities.Order>> GetOrderByUserId(string userId);
    }
}
