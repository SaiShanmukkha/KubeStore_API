using KubeStore.API.DTO;
using KubeStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KubeStore.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IKubeAuthService _userService;

        public AuthController(IKubeAuthService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("No Data Received.");
            }

            var result = await _userService.RegisterUserAsync(model);

            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Errors);

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("No Data Received.");
            }

            var result = await _userService.LoginUserAsync(model);

            if (result.IsSuccess)
            { 
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

      
    }
}
