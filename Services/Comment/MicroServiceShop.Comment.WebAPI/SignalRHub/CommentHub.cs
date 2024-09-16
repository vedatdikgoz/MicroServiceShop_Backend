using MicroServiceShop.Comment.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;


namespace MicroServiceShop.Comment.WebAPI.SignalRHub
{
    public class CommentHub : Hub
    {
        private readonly ICommentService _commentService;
        public CommentHub(ICommentService commentService)
        {
                _commentService = commentService;
        }
        public async Task SendCommentCount()
        {
            var commentCount = await _commentService.GetCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", commentCount);
        }
    }
}
