using AutoMapper;
using MicroServiceShop.Comment.WebAPI.Dtos;
using MicroServiceShop.Comment.WebAPI.Entities;

namespace MicroServiceShop.Comment.WebAPI.Mapping
{
    public class CommentMapping : Profile
    {
        public CommentMapping() 
        {
            CreateMap<UserComment, UserCommentDto>().ReverseMap();
            CreateMap<UserComment, CreateUserCommentDto>().ReverseMap();
            CreateMap<UserComment, UpdateUserCommentDto>().ReverseMap();
        }
    }
}
