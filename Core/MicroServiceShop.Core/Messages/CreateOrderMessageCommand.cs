

namespace MicroServiceShop.Core.Messages
{
    public class CreateOrderMessageCommand
    {
        public CreateOrderMessageCommand()
        {
            OrderItems = new List<OrderItem>();
        }

        public string BuyerId { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string District { get; set; }

        public string AddressLine { get; set; }

        public string ZipCode { get; set; }

        
    }

    public class OrderItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public Decimal Price { get; set; }
    }
}

