using MediatR;


namespace MicroServiceShop.Order.Application.Commands.AddressCommands
{
    public class DeleteAddressCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteAddressCommand(int id)
        {
            Id = id;
        }
    }
}
