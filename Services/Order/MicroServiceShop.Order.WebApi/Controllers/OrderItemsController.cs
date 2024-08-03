using MediatR;
using MicroServiceShop.Order.Application.Commands;
using MicroServiceShop.Order.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderItemList()
        {
            var response = await _mediator.Send(new GetOrderItemQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(int id)
        {
            var response = await _mediator.Send(new GetOrderItemByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(CreateOrderItemCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş oluşturuldu.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            await _mediator.Send(new DeleteOrderItemCommand(id));
            return Ok("Sipariş silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem(UpdateOrderItemCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş güncellendi");
        }
    }
}
