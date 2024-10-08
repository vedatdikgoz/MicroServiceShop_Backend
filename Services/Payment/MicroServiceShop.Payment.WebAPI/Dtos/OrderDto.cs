﻿namespace MicroServiceShop.Payment.WebAPI.Dtos
{
   
        public class OrderDto
        {
            public OrderDto()
            {
                OrderItems = new List<OrderItemDto>();
            }

            public string BuyerId { get; set; }

            public List<OrderItemDto> OrderItems { get; set; }

            public AddressDto Address { get; set; }
        }

        public class OrderItemDto
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public string PictureUrl { get; set; }
            public Decimal Price { get; set; }
        }

        public class AddressDto
        {
            public string Country { get; set; }
            public string Province { get; set; }

            public string District { get; set; }

            public string AddressLine { get; set; }

            public string ZipCode { get; set; }


        }
}
