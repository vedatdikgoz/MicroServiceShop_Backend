using MediatR;


namespace MicroServiceShop.Order.Application.Commands.AddressCommands
{
    public class CreateAddressCommand : IRequest
    {
        public string UserId { get; set; } = null!;

        public string? City { get; set; }
        public string? District { get; set; }

        public string? Street { get; set; }

        public string? ZipCode { get; set; }
    }
}
