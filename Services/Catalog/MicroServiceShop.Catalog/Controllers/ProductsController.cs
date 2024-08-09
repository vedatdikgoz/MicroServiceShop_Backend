using MicroServiceShop.Catalog.Dtos;
using MicroServiceShop.Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return CreateActionResultInstance(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _productService.GetByIdAsync(id);
            return CreateActionResultInstance(product);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            var response = await _productService.CreateAsync(createProductDto);

            return CreateActionResultInstance(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var response = await _productService.UpdateAsync(updateProductDto);

            return CreateActionResultInstance(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _productService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }


        [HttpGet("productwithcategory")]
        public async Task<IActionResult> ProductWithCategory(string categoryId)
        {
            var response = await _productService.GetProductsByCategory(categoryId);
            return CreateActionResultInstance(response);
        }
    }
}
