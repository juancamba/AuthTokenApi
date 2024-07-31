
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using ConsumerApi.Dto;
using ConsumerApi.Services;
namespace ConsumerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly AuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }



        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto.Username, loginDto.Password);


            return Ok(result);
        }

        [HttpGet("obtener1")]
        public async Task<ActionResult<String>> Obtener1()
        {
              _logger.LogInformation("obtener 1");
            return Ok("Obtener1");
        }

        [HttpGet("obtener2")]
        [Authorize]
        public async Task<ActionResult<String>> Obtener2()
        {
            return Ok("Obtener2");
        }

        [HttpGet("obtener3")]
        public async Task<ActionResult<String>> Obtener3()
        {
            
            _logger.LogCritical("Error chungo");
            return Ok ("Obtener 3");
        }

    }


}
