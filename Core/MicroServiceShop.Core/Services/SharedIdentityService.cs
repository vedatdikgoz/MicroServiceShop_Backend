using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MicroServiceShop.Core.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            //var userId = _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }

    }
}
