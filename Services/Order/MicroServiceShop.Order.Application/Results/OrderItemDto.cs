﻿
namespace MicroServiceShop.Order.Application.Results
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderId { get; set; }
    }
}
