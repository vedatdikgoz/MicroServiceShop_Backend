﻿namespace MicroServiceShop.Catalog.WebAPI.Dtos
{
    public class CreateProductImageDto
    {
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string ProductId { get; set; } = null!;
    }
}
