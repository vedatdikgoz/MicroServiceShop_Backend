using MicroServiceShop.Catalog.WebAPI.Dtos;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroServiceShop.Catalog.WebAPI.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<Response<List<ProductImageDto>>> GetAllAsync();
        Task<Response<List<ProductImageDto>>> GetAllByProductIdAsync(string productId);
        Task<Response<ProductImageDto>> GetByIdAsync(string id);
        Task<Response<ProductImageDto>> CreateAsync(CreateProductImageDto createProductImageDto);
        Task<Response<NoContent>> UpdateAsync(UpdateProductImageDto updateProductImageDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
