using AutoMapper;
using MicroServiceShop.Comment.WebAPI.Dtos;
using MicroServiceShop.Comment.WebAPI.Entities;
using MicroServiceShop.Comment.WebAPI.Services.Interfaces;
using MicroServiceShop.Comment.WebAPI.Settings;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;

namespace MicroServiceShop.Comment.WebAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMongoCollection<UserComment> _userCommentCollection;
        private readonly IMapper _mapper;
        public CommentService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _userCommentCollection = database.GetCollection<UserComment>(databaseSettings.CommentCollectionName);
            _mapper = mapper;
        }

        public async Task<int> GetCommentCount()
        {
            var result = await _userCommentCollection.CountDocumentsAsync(FilterDefinition<UserComment>.Empty);
            int commentCount = (int)result;
            return commentCount;
        }

        public async Task<Response<UserCommentDto>> CreateAsync(CreateUserCommentDto createCommentDto)
        {
            var newComment = _mapper.Map<UserComment>(createCommentDto);
            await _userCommentCollection.InsertOneAsync(newComment);
            return Response<UserCommentDto>.Success(_mapper.Map<UserCommentDto>(newComment), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _userCommentCollection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Comment not found", 404);
            }
        }

        public async Task<Response<List<UserCommentDto>>> GetAllAsync()
        {
            var comments = await _userCommentCollection.Find(comment => true).ToListAsync();

            if (comments.Count != 0)
            {
                return Response<List<UserCommentDto>>.Success(_mapper.Map<List<UserCommentDto>>(comments), 200);
            }

            return Response<List<UserCommentDto>>.Fail("Comment not found", 404);
        }

        public async Task<Response<List<UserCommentDto>>> GetAllByProductIdAsync(string productId)
        {
            var comments = await _userCommentCollection.Find(x => x.ProductId == productId).ToListAsync();

            if (comments.Count != 0)
            {
                return Response<List<UserCommentDto>>.Success(_mapper.Map<List<UserCommentDto>>(comments), 200);
            }

            return Response<List<UserCommentDto>>.Fail("Comment not found", 404);
        }

        public async Task<Response<UserCommentDto>> GetByIdAsync(string id)
        {
            var comment = await _userCommentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (comment == null)
            {
                return Response<UserCommentDto>.Fail("Comment not found", 404);
            }
            return Response<UserCommentDto>.Success(_mapper.Map<UserCommentDto>(comment), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateUserCommentDto updateCommentDto)
        {
            var updateUserComment = _mapper.Map<UserComment>(updateCommentDto);
            var result = await _userCommentCollection.FindOneAndReplaceAsync(x => x.Id == updateCommentDto.Id, updateUserComment);
            if (result == null)
            {
                return Response<NoContent>.Fail("Comment not found", 404);
            }
            return Response<NoContent>.Success(204);
        }
    }
}
