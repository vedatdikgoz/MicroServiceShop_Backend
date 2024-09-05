using AutoMapper;
using MicroServiceShop.Cargo.WebAPI.Dtos;
using MicroServiceShop.Cargo.WebAPI.Entities;

namespace MicroServiceShop.Cargo.WebAPI.Mapping
{
    public class CargoMapping : Profile
    {
        public CargoMapping()
        {
            CreateMap<CargoCompany, CargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();

            CreateMap<CargoDetail, CargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();
        }
    }
}
