﻿namespace MicroServiceShop.Catalog.Dtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
