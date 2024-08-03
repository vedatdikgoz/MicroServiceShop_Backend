using MediatR;


namespace MicroServiceShop.Order.Application.Commands.OrderCommands
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
