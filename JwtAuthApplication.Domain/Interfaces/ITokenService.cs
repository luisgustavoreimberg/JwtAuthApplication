using JwtAuthApplication.Common.DTOs;

namespace JwtAuthApplication.Domain.Interfaces
{
    public interface ITokenService
    {
        public TokenResponseDTO GetToken(LoginRequestDTO userData);
    }
}