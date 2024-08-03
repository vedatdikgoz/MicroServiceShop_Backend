using MicroServiceShop.Catalog.Dtos;
using MicroServiceShop.Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : CustomBaseController
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productDetails = await _productDetailService.GetAllAsync();
            return CreateActionResultInstance(productDetails);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var productDetail = await _productDetailService.GetByIdAsync(id);
            return CreateActionResultInstance(productDetail);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDetailDto createProductDetailDto)
        {
            var response = await _productDetailService.CreateAsync(createProductDetailDto);

            return CreateActionResultInstance(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDetailDto updateProductDetailDto)
        {
            var response = await _productDetailService.UpdateAsync(updateProductDetailDto);

            return CreateActionResultInstance(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _productDetailService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
