using MassTransit;
using MicroServiceShop.Core.Messages;
using MicroServiceShop.Order.Infrastructure;


namespace MicroServiceShop.Order.Application.Consumers
{
    public class CreateOrderMessageCommandConsumer : IConsumer<CreateOrderMessageCommand>
    {
        private readonly OrderContext _orderContext;

        public CreateOrderMessageCommandConsumer(OrderContext orderContext)
        {
            _orderContext = orderContext;
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
        }
    }

}
