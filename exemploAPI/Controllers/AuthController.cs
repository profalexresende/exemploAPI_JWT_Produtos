using Microsoft.AspNetCore.Mvc;

using exemploAPI.Services;

namespace exemploAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Aqui, você deve validar o usuário (por exemplo, consultando um banco de dados)
            // Para simplicidade, vou validar se o nome de usuário é 'usuario' e a senha é 'senha123'
            if (login.Username == "usuario" && login.Password == "senha123")
            {
                var token = _tokenService.GenerateToken(login.Username);
                return Ok(new { token });
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

