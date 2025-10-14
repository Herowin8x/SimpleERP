using Inventory.BLL.DTOs;
using Inventory.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MySample.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOnlyInventoryUIApp")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Generate token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO model)
        {
            var result = await _userService.Login(model);
            if (result == null)
                return NotFound("Incorrect username or password!");

            return Ok(result);
        }

        /// <summary>
        /// Get Current User
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("me")]
        public IActionResult Get()
        {
            return Ok(new
            {
                User.Identity.Name,
                Claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }
    }
}
