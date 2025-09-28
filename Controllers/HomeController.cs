using AuthApiBackend.DTOs;
using AuthApiBackend.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IUserService userService;
        private readonly IContactDetailsService contactService;

        public HomeController(IUserService userService, IContactDetailsService contactService)
        {
            
            this.contactService = contactService;
            this.userService = userService;

        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto user, CancellationToken cancellationToken)
        {
            string userId = await userService.CreateUserAsync(user, cancellationToken);

            await contactService.CreateUserContactDetails(userId ,user.Email, cancellationToken);

            return Created();

        }

    }

}
