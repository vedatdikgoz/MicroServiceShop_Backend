﻿namespace MicroServiceShop.Catalog.WebAPI.Dtos
{
    public class UpdateCategoryDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
