using MediatR;


namespace MicroServiceShop.Order.Application.Commands
{
    public class DeleteOrderItemCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderItemCommand(int id)
        {
            Id = id;
        }
    }
}
