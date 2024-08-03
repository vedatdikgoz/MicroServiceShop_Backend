using MicroServiceShop.Catalog.Dtos;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroServiceShop.Catalog.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<CategoryDto>> CreateAsync(CreateCategoryDto createCategoryDto);
        Task<Response<NoContent>> UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
