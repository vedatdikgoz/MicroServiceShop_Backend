using MassTransit;
using MicroServiceShop.Core.Messages;
using MicroServiceShop.Order.Infrastructure;


namespace MicroServiceShop.Order.Application.Consumers
{
    public class CreateOrderMessageCommandConsumer : IConsumer<CreateOrderMessageCommand>
    {
        private readonly OrderContext _orderContext;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public CreateOrderMessageCommandConsumer(OrderContext orderContext, ISendEndpointProvider sendEndpointProvider)
        {
            _orderContext = orderContext;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
        {
            var newAddress = new Domain.OrderAggregate.Address( context.Message.Country,context.Message.Province, context.Message.District, context.Message.AddressLine, context.Message.ZipCode);

            Domain.OrderAggregate.Order order = new Domain.OrderAggregate.Order(context.Message.BuyerId, newAddress);

            context.Message.OrderItems.ForEach(x =>
            {
                order.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });

            await _orderContext.Orders.AddAsync(order);

            await _orderContext.SaveChangesAsync();

            var createInvoiceMessageCommand = new CreateInvoiceMessageCommand
            {
                BuyerId = order.BuyerId,
                Address = new AddressDto
                {
                    Country = newAddress.Country,
                    Province = newAddress.Province,
                    District = newAddress.District,
                    AddressLine = newAddress.AddressLine,
                    ZipCode = newAddress.ZipCode
                },
                OrderItems = order.OrderItems.Select(x => new OrderItemDto
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    PictureUrl = x.PictureUrl,
                    Price = x.Price,
                    Quantity = 1 
                }).ToList(),
                InvoiceNumber = Guid.NewGuid(),
                CreateDate = DateTime.UtcNow
            };

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-invoice-service"));
            await sendEndpoint.Send(createInvoiceMessageCommand);
        }
    }

}
