using MicroServiceShop.Cargo.WebAPI.Dtos;
using MicroServiceShop.Cargo.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Cargo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : CustomBaseController
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

   

        [HttpGet]
        public async Task<IActionResult> GetAllCargoDetail()
        {
            var result = await _cargoDetailService.GetAllCargoDetailAsync();
            return CreateActionResultInstance(result);
        }




        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            await _cargoDetailService.CreateCargoDetailAsync(createCargoDetailDto);
            return Ok("Kargo detayı oluşturuldu.");
        }


     

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            await _cargoDetailService.DeleteCargoDetailAsync(id);
            return Ok("Kargo detayı silindi");
        }

     

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            await _cargoDetailService.UpdateCargoDetailAsync(updateCargoDetailDto);
            return Ok("Kargo detayı güncellendi");
        }


   

        [HttpGet("CargoDetail{id}")]
        public async Task<IActionResult> GetCargoDetailById(int id)
        {
            var result = await _cargoDetailService.GetByIdCargoDetailAsync(id);
            return CreateActionResultInstance(result);
        }
    }
}
