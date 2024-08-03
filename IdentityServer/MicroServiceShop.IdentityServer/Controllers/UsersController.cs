using IdentityServer4;
using MicroServiceShop.IdentityServer.Dtos;
using MicroServiceShop.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace MicroServiceShop.IdentityServer.Controllers
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser
            {
                UserName = signUpDto.Username,
                Email = signUpDto.Email,
                Name = signUpDto.Name,
                Surname = signUpDto.Surname,
            };
            var result = await _userManager.CreateAsync(user, signUpDto.Password);
            if (!result.Succeeded)
            {
                return Ok("Bir hata oluştu");
            }

            return Ok("Kullanıcı başarı ile eklendi.");
        }

    }
}
