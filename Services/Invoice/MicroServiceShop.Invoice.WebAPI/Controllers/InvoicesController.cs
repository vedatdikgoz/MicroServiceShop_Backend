using MicroServiceShop.Invoice.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Invoice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : CustomBaseController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _invoiceService.GetAllAsync();
            return CreateActionResultInstance(invoices);
        }
    }
}
