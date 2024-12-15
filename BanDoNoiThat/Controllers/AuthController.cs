using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BanDoNoiThat.Models.ViewModels;
using BanDoNoiThat.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BanDoNoiThat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IConfiguration _configuration;

        private readonly AuthService _authService;

        public AuthController(IConfiguration configuration, AuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            // Sử dụng service để xác thực người dùng
            var account = _authService.Authenticate(model.Username, model.Password);
            if (account == null)
            {
                return Unauthorized("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            var role = _authService.FindRoleName(Convert.ToInt32(account.role_id));
            // Tạo token JWT
            var token = GenerateJwtToken(model.Username, role.roleName.ToString());
            // Trả về thông tin người dùng cùng với token
            return Ok(new
            {
                FullName = account.FullName,
                role_id = account.role_id,
                role = role,
                Token = token
            });
        }

        private string GenerateJwtToken(string username, string RoleName)
        {
            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("roleName", RoleName.ToString()) //xác thực quyền truy cập vào endpoint
                 };

            var key = _configuration.GetValue<string>("Jwt:Key");
            if (string.IsNullOrEmpty(key))
            {
                throw new InvalidOperationException("Khóa bảo mật không được cấu hình trong appsettings.json");
            }
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var creds = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
