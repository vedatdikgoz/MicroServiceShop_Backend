using MicroServiceShop.Catalog.WebAPI.Dtos;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroServiceShop.Catalog.WebAPI.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<Response<List<ProductDetailDto>>> GetAllAsync();
        Task<Response<ProductDetailDto>> GetByIdAsync(string id);
        Task<Response<ProductDetailDto>> GetByProductIdAsync(string productId);
        Task<Response<ProductDetailDto>> CreateAsync(CreateProductDetailDto createProductDetailDto);
        Task<Response<NoContent>> UpdateAsync(UpdateProductDetailDto updateProductDetailDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
