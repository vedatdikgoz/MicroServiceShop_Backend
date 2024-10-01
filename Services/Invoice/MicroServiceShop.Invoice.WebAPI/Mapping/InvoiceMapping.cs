using AutoMapper;
using MicroServiceShop.Core.Messages;
using MicroServiceShop.Invoice.WebAPI.Dtos;

namespace MicroServiceShop.Invoice.WebAPI.Mapping
{
    public class InvoiceMapping : Profile
    {
        public InvoiceMapping()
        {
            CreateMap<Entities.Invoice, InvoiceDto>().ReverseMap();
            CreateMap<Entities.Invoice, CreateInvoiceDto>().ReverseMap();
            CreateMap<Entities.Invoice, UpdateInvoiceDto>().ReverseMap();

            CreateMap<CreateInvoiceMessageCommand, CreateInvoiceDto>();
        }
    }
}
