using MicroServiceShop.Catalog.Dtos;
using MicroServiceShop.Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : CustomBaseController
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productImages = await _productImageService.GetAllAsync();
            return CreateActionResultInstance(productImages);
        }

        [HttpGet("getall/{productId}")]
        public async Task<IActionResult> GetAllByProductId(string productId)
        {
            var productImages = await _productImageService.GetAllByProductIdAsync(productId);
            return CreateActionResultInstance(productImages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var productImage = await _productImageService.GetByIdAsync(id);
            return CreateActionResultInstance(productImage);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductImageDto createProductImageDto)
        {
            var response = await _productImageService.CreateAsync(createProductImageDto);

            return CreateActionResultInstance(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductImageDto updateProductImageDto)
        {
            var response = await _productImageService.UpdateAsync(updateProductImageDto);

            return CreateActionResultInstance(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _productImageService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
