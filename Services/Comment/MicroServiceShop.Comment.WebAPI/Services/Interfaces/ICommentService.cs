using MicroServiceShop.Comment.WebAPI.Dtos;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroServiceShop.Comment.WebAPI.Services.Interfaces
{
    public interface ICommentService
    {
        Task<Response<List<UserCommentDto>>> GetAllAsync();
        Task<Response<UserCommentDto>> GetByIdAsync(string id);
        Task<Response<UserCommentDto>> CreateAsync(CreateUserCommentDto createCommentDto);
        Task<Response<NoContent>> UpdateAsync(UpdateUserCommentDto updateCommentDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
