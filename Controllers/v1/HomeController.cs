using AuthApiBackend.DTOs;
using AuthApiBackend.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AuthApiBackend.Controllers.v1
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IUserService userService;
        private readonly IContactDetailsService contactService;
        private readonly IRoleService roleService;
        private readonly IUserRoleService userRoleService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="contactService"></param>
        /// <param name="roleService"></param>
        /// <param name="userRoleService"></param>
        public HomeController(IUserService userService, IContactDetailsService contactService, IRoleService roleService,
            IUserRoleService userRoleService)
        {
            
            this.contactService = contactService;
            this.userService = userService;
            this.roleService = roleService;
            this.userRoleService = userRoleService;

        }

     
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
