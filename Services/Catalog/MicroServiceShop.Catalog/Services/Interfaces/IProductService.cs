using MicroServiceShop.Catalog.Dtos;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroServiceShop.Catalog.Services.Interfaces
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();
        Task<Response<ProductDto>> GetByIdAsync(string id);
        Task<Response<ProductDto>> CreateAsync(CreateProductDto createProductDto);
        Task<Response<NoContent>> UpdateAsync(UpdateProductDto updateProductDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
