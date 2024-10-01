using MicroServiceShop.Core.Dtos;
using MicroServiceShop.Invoice.WebAPI.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MicroServiceShop.Invoice.WebAPI.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<Response<List<InvoiceDto>>> GetAllAsync();
        Task<Response<InvoiceDto>> GetByIdAsync(string id);
        Task<Response<InvoiceDto>> CreateAsync(CreateInvoiceDto createInvoiceDto);
        Task<Response<NoContent>> UpdateAsync(UpdateInvoiceDto updateInvoiceDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
