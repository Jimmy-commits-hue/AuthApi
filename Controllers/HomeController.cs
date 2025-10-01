using AuthApiBackend.DTOs;
using AuthApiBackend.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AuthApiBackend.Controllers
{

    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]

    public class HomeController : ControllerBase
    {

        private readonly IUserService userService;
        private readonly IContactDetailsService contactService;
        private readonly IRoleService roleService;
        private readonly IUserRoleService userRoleService;

        public HomeController(IUserService userService, IContactDetailsService contactService, IRoleService roleService,
            IUserRoleService userRoleService)
        {
            
            this.contactService = contactService;
            this.userService = userService;
            this.roleService = roleService;
            this.userRoleService = userRoleService;

        }

        /// <summary>
        /// registration point
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto user, CancellationToken cancellationToken)
        {
            string userId = await userService.CreateUserAsync(user, cancellationToken);

            await contactService.CreateUserContactDetails(userId ,user.Email, cancellationToken);

            int role = await roleService.GetRoleAsync("User", cancellationToken);

            await userRoleService.CreateUserRoleAsync(role, userId, cancellationToken);

            return Created();

        }

    }

}
