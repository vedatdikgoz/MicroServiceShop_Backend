using MicroServiceShop.Order.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceShop.Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }
        public async Task<List<Domain.Entities.Order>> GetOrderByUserId(string userId)
        {
            var orders = await _context.Orders.Include(od => od.OrderItems).Where(x => x.UserId == userId).ToListAsync();
            return orders;
        }
    }
}
