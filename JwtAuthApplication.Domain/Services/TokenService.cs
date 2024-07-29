using JwtAuthApplication.Common.DTOs;
using JwtAuthApplication.Domain.Interfaces;
using JwtAuthApplication.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthApplication.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;

        public TokenService(IUserService userService, IOptions<JwtSettings> jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings.Value;
        }

        public TokenResponseDTO GetToken(LoginRequestDTO userData)
        {
            var response = new TokenResponseDTO();
            var user = _userService.ValidateUser(userData);

            if (user is null)
            {
                response.Valid = false;
                response.Token = string.Empty;
                response.Expires = null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityKey = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                var tokenProperties = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.UserType.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(securityKey),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenProperties);

                response.Valid = true;
                response.Token = tokenHandler.WriteToken(token);
                response.Expires = tokenProperties.Expires;
            }

            return response;
        }
    }
}