﻿namespace MicroServiceShop.Basket.WebAPI.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
