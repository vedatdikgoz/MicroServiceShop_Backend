using MediatR;
using MicroServiceShop.Order.Application.Commands.OrderCommands;
using MicroServiceShop.Order.Application.Queries;
using MicroServiceShop.Order.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var response = await _mediator.Send(new GetOrderQuery());
            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _mediator.Send(new GetOrderByIdQuery(id));
            return CreateActionResultInstance(response);
        }

        [HttpGet("user={userId}")]
        public async Task<IActionResult> GetOrderByUserId(string userId)
        {
            var response = await _mediator.Send(new GetOrderByUserIdQuery(userId));
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş oluşturuldu.");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return Ok("Sipariş silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş güncellendi");
        }
    }
}
