using MicroServiceShop.Cargo.WebAPI.Dtos;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroServiceShop.Cargo.WebAPI.Services.Interfaces
{
    public interface ICargoCompanyService
    {
        Task<Response<List<CargoCompanyDto>>> GetAllCargoCompanyAsync();
        Task<Response<CargoCompanyDto>> GetByIdCargoCompanyAsync(int id);
        Task<Response<NoContent>> CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
        Task<Response<NoContent>> UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
        Task<Response<NoContent>> DeleteCargoCompanyAsync(int id);
    }
}
