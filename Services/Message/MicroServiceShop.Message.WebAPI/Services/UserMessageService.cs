using AutoMapper;
using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Message.WebAPI.DataAccess.Context;
using MicroServiceShop.Message.WebAPI.DataAccess.Entities;
using MicroServiceShop.Message.WebAPI.Dtos;
using MicroServiceShop.Message.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceShop.Message.WebAPI.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public UserMessageService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateUserMessageAsync(CreateUserMessageDto createUserMessageDto)
        {
            var newMessage = _mapper.Map<UserMessage>(createUserMessageDto);
            _dataContext.UserMessages.Add(newMessage);
            await _dataContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }


        public async Task<Response<NoContent>> DeleteUserMessageAsync(int id)
        {
            var value = await _dataContext.UserMessages.FindAsync(id);
            if (value != null)
            {
                _dataContext.UserMessages.Remove(value);
                await _dataContext.SaveChangesAsync();
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Message not found", 404);
            }

        }


        public async Task<Response<List<UserMessageDto>>> GetAllUserMessageAsync()
        {
            var values = await _dataContext.UserMessages.ToListAsync();
            return Response<List<UserMessageDto>>.Success(_mapper.Map<List<UserMessageDto>>(values), 200);
        }


        public async Task<Response<UserMessageDto>> GetByIdUserMessageAsync(int id)
        {
            var value = await _dataContext.UserMessages.FindAsync(id);
            if (value != null)
            {
                return Response<UserMessageDto>.Success(_mapper.Map<UserMessageDto>(value), 200);
            }
            else
            {
                return Response<UserMessageDto>.Fail("Usermessage not found", 404);
            }
            
        }


        public async Task<Response<List<UserMessageDto>>> GetInboxUserMessageAsync(string id)
        {
            var values = await _dataContext.UserMessages.Where( x => x.RecieverId == id ).ToListAsync();
            return Response<List<UserMessageDto>>.Success(_mapper.Map<List<UserMessageDto>>(values), 200);
        }


        public async Task<Response<List<UserMessageDto>>> GetSendboxUserMessageAsync(string id)
        {
            var values = await _dataContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return Response<List<UserMessageDto>>.Success(_mapper.Map<List<UserMessageDto>>(values), 200);
        }


        public async Task<Response<NoContent>> UpdateUserMessageAsync(UpdateUserMessageDto updateUserMessageDto)
        {
            var updateMessage = _mapper.Map<UserMessage>(updateUserMessageDto);
            var result =  _dataContext.UserMessages.Update(updateMessage);
            await _dataContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }
    }
}
