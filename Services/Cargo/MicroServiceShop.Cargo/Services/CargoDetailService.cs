using AutoMapper;
using MicroServiceShop.Cargo.WebAPI.DataAccess;
using MicroServiceShop.Cargo.WebAPI.Dtos;
using MicroServiceShop.Cargo.WebAPI.Entities;
using MicroServiceShop.Cargo.WebAPI.Services.Interfaces;
using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceShop.Cargo.WebAPI.Services
{
    public class CargoDetailService : ICargoDetailService
    {
        private readonly CargoContext _cargoContext;
        private readonly IMapper _mapper;
        public CargoDetailService(CargoContext cargoContext, IMapper mapper)
        {
            _cargoContext = cargoContext;
            _mapper = mapper;
        }

   
        public async Task<Response<NoContent>> CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto)
        {
            var newCargoDetail = _mapper.Map<CargoDetail>(createCargoDetailDto);
            _cargoContext.CargoDetails.Add(newCargoDetail);
            await _cargoContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }


        public async Task<Response<NoContent>> DeleteCargoDetailAsync(int id)
        {
            var value = await _cargoContext.CargoDetails.FindAsync(id);
            if (value != null)
            {
                _cargoContext.CargoDetails.Remove(value);
                await _cargoContext.SaveChangesAsync();
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Cargo Detail not found", 404);
            };
        }


        public async Task<Response<List<CargoDetailDto>>> GetAllCargoDetailAsync()
        {
            var values = await _cargoContext.CargoDetails.ToListAsync();
            return Response<List<CargoDetailDto>>.Success(_mapper.Map<List<CargoDetailDto>>(values), 200);
        }


        public async Task<Response<CargoDetailDto>> GetByIdCargoDetailAsync(int id)
        {
            var value = await _cargoContext.CargoDetails.FindAsync(id);
            if (value != null)
            {
                return Response<CargoDetailDto>.Success(_mapper.Map<CargoDetailDto>(value), 200);
            }
            else
            {
                return Response<CargoDetailDto>.Fail("Cargo Detail not found", 404);
            }
        }


        public async Task<Response<NoContent>> UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var updateCargoDetail = _mapper.Map<CargoDetail>(updateCargoDetailDto);
            var result = _cargoContext.CargoDetails.Update(updateCargoDetail);
            await _cargoContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }
    }
}
