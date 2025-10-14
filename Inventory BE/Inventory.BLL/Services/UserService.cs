using Inventory.BLL.DTOs;
using Inventory.DLL.Repositories;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace Inventory.BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _config;

        public UserService(UserRepository userRepository, IConfiguration configuration) 
        {
            _userRepository = userRepository;
            _config = configuration;
        }

        public async Task<object?> Login(UserDTO userDTO)
        {
            var userEntity = await _userRepository.Read(userDTO.Username, userDTO.Password);
            if (userEntity != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, userDTO.Username),
                    new Claim(ClaimTypes.Role, userEntity.Role)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:secret"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["JWT:issuer"],
                    audience: _config["JWT:audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds);

                return new { token = new JwtSecurityTokenHandler().WriteToken(token) };
            }

            return null;
        }
    }
}
