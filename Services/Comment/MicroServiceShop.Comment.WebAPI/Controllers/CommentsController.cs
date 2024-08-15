using MicroServiceShop.Comment.WebAPI.Dtos;
using MicroServiceShop.Comment.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Comment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : CustomBaseController
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _commentService.GetAllAsync();
            return CreateActionResultInstance(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _commentService.GetByIdAsync(id);
            return CreateActionResultInstance(product);
        }

        [HttpGet("getallbyproductid/{productId}")]
        public async Task<IActionResult> GetAllByProductId(string productId)
        {
            var product = await _commentService.GetAllByProductIdAsync(productId);
            return CreateActionResultInstance(product);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommentDto createUserCommentDto)
        {
            var response = await _commentService.CreateAsync(createUserCommentDto);

            return CreateActionResultInstance(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommentDto updateUserCommentDto)
        {
            var response = await _commentService.UpdateAsync(updateUserCommentDto);

            return CreateActionResultInstance(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _commentService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
