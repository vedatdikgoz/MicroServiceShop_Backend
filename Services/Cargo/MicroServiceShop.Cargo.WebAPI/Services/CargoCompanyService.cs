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
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly CargoContext _cargoContext;
        private readonly IMapper _mapper;
        public CargoCompanyService(CargoContext cargoContext, IMapper mapper)
        {
            _cargoContext = cargoContext;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var newCargoCompany = _mapper.Map<CargoCompany>(createCargoCompanyDto);
            _cargoContext.CargoCompanies.Add(newCargoCompany);
            await _cargoContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }


        public async Task<Response<NoContent>> DeleteCargoCompanyAsync(int id)
        {
            var value = await _cargoContext.CargoCompanies.FindAsync(id);
            if (value != null)
            {
                _cargoContext.CargoCompanies.Remove(value);
                await _cargoContext.SaveChangesAsync();
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Cargo company not found", 404);
            }
        }


        public async Task<Response<List<CargoCompanyDto>>> GetAllCargoCompanyAsync()
        {
            var values = await _cargoContext.CargoCompanies.ToListAsync();
            return Response<List<CargoCompanyDto>>.Success(_mapper.Map<List<CargoCompanyDto>>(values), 200);
        }


        public async Task<Response<CargoCompanyDto>> GetByIdCargoCompanyAsync(int id)
        {
            var value = await _cargoContext.CargoCompanies.FindAsync(id);
            if (value != null)
            {
                return Response<CargoCompanyDto>.Success(_mapper.Map<CargoCompanyDto>(value), 200);
            }
            else
            {
                return Response<CargoCompanyDto>.Fail("Cargo Company not found", 404);
            }
        }


        public async Task<Response<NoContent>> UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var updateCargoCompany = _mapper.Map<CargoCompany>(updateCargoCompanyDto);
            var result = _cargoContext.CargoCompanies.Update(updateCargoCompany);
            await _cargoContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }
    }
}
