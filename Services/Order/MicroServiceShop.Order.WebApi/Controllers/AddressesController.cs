using MediatR;
using MicroServiceShop.Order.Application.Commands.AddressCommands;
using MicroServiceShop.Order.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var response = await _mediator.Send(new GetAddressQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var response = await _mediator.Send(new GetAddressByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Adres oluşturuldu.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _mediator.Send(new DeleteAddressCommand(id));
            return Ok("Adres silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Adres güncellendi");
        }
    }
}
