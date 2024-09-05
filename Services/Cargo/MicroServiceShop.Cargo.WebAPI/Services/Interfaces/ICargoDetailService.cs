using MicroServiceShop.Cargo.WebAPI.Dtos;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroServiceShop.Cargo.WebAPI.Services.Interfaces
{
    public interface ICargoDetailService
    {
        Task<Response<List<CargoDetailDto>>> GetAllCargoDetailAsync();
        Task<Response<CargoDetailDto>> GetByIdCargoDetailAsync(int id);
        Task<Response<NoContent>> CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto);
        Task<Response<NoContent>> UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto);
        Task<Response<NoContent>> DeleteCargoDetailAsync(int id);
    }
}
