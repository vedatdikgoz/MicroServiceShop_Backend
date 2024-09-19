using MediatR;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Order.Application.Commands.OrderCommands;
using MicroServiceShop.Order.Application.Dtos;
using MicroServiceShop.Order.Domain.OrderAggregate;
using MicroServiceShop.Order.Infrastructure;

namespace MicroServiceShop.Order.Application.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderContext _context;

        public CreateOrderCommandHandler(OrderContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(
                request.Address.Country, 
                request.Address.Province, 
                request.Address.District, 
                request.Address.AdressLine, 
                request.Address.ZipCode
                );

            Domain.OrderAggregate.Order newOrder = new(request.BuyerId, newAddress);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(
                    x.ProductId, 
                    x.ProductName, 
                    x.Price, 
                    x.PictureUrl
                    );
            });

            await _context.Orders.AddAsync(newOrder);

            await _context.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);
        }
    }
}
