namespace MicroServiceShop.Basket.WebAPI.Dtos
{
    public class BasketDto
    {
        public string UserId { get; set; } = null!;
        public string? DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDto>? BasketItems { get; set; }
        public decimal? TotalPrice => BasketItems?.Sum(x => x.Price * x.Quantity);

    }
}
