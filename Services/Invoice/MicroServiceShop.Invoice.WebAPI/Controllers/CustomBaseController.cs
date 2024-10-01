using MicroServiceShop.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceShop.Invoice.WebAPI.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
