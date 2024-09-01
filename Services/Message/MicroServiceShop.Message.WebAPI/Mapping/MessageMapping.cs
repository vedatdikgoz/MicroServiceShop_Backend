using AutoMapper;
using MicroServiceShop.Message.WebAPI.DataAccess.Entities;
using MicroServiceShop.Message.WebAPI.Dtos;

namespace MicroServiceShop.Message.WebAPI.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<UserMessage, UserMessageDto>().ReverseMap();
            CreateMap<UserMessage, CreateUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, UpdateUserMessageDto>().ReverseMap();
        }
    }
}
