
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

        public AuthController(AuthService authService)
        {
            _authService = authService;
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
            return Ok("Obtener1");
        }

        [HttpGet("obtener2")]
        [Authorize]
        public async Task<ActionResult<String>> Obtener2()
        {
            return Ok("Obtener2");
        }
    }


}
