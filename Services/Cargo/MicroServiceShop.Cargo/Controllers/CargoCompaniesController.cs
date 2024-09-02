using MicroServiceShop.Cargo.WebAPI.Dtos;
using MicroServiceShop.Cargo.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Cargo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : CustomBaseController
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargoCompany()
        {
            var result = await _cargoCompanyService.GetAllCargoCompanyAsync();
            return CreateActionResultInstance(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return Ok("Kargo şirketi oluşturuldu.");
        }




        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return Ok("Kargo şirketi silindi");
        }



        [HttpPut]
        public async Task<IActionResult> UpdateCargo(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return Ok("Kargo şirketi güncellendi");
        }



        [HttpGet("CargoCompany{id}")]
        public async Task<IActionResult> GetCargoCompanyById(int id)
        {
            var result = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return CreateActionResultInstance(result);
        }


    }
}
