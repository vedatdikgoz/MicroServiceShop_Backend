using MicroServiceShop.Message.WebAPI.Dtos;
using MicroServiceShop.Message.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Message.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : CustomBaseController
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var result = await _userMessageService.GetAllUserMessageAsync();
            return CreateActionResultInstance(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserMessage(CreateUserMessageDto createUserMessageDto)
        {
            await _userMessageService.CreateUserMessageAsync(createUserMessageDto);
            return Ok("Mesaj oluşturuldu.");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUserMessage(int id)
        {
            await _userMessageService.DeleteUserMessageAsync(id);
            return Ok("Mesaj silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserMessage(UpdateUserMessageDto updateUserMessageDto)
        {
            await _userMessageService.UpdateUserMessageAsync(updateUserMessageDto);
            return Ok("Mesaj güncellendi");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMessageById(int id)
        {
            var result = await _userMessageService.GetByIdUserMessageAsync(id);
            return CreateActionResultInstance(result);
        }

        [HttpGet("GetMessageSendbox")]
        public async Task<IActionResult> GetMessageSendbox(string id)
        {
            var result = await _userMessageService.GetSendboxUserMessageAsync(id);
            return CreateActionResultInstance(result);
        }

        [HttpGet("GetMessageInbox")]
        public async Task<IActionResult> GetMessageInbox(string id)
        {
            var result = await _userMessageService.GetInboxUserMessageAsync(id);
            return CreateActionResultInstance(result);
        }
    }
}
