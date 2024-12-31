using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "password") // Replace with your authentication logic
            {
                var token = JwtHelper.GenerateJwtToken(
                    model.Username,
                    _configuration["Jwt:Key"],
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"]
                );

                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
