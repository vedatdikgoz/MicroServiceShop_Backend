using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Message.WebAPI.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroServiceShop.Message.WebAPI.Services.Interfaces
{
    public interface IUserMessageService
    {
        Task<Response<List<UserMessageDto>>> GetAllUserMessageAsync();
        Task<Response<UserMessageDto>> GetByIdUserMessageAsync(int id);
        Task<Response<List<UserMessageDto>>> GetInboxUserMessageAsync(string id);
        Task<Response<List<UserMessageDto>>> GetSendboxUserMessageAsync(string id);
        Task<Response<NoContent>> CreateUserMessageAsync(CreateUserMessageDto createUserMessageDto);
        Task<Response<NoContent>> UpdateUserMessageAsync(UpdateUserMessageDto updateUserMessageDto);
        Task<Response<NoContent>> DeleteUserMessageAsync(int id);
    }
}
