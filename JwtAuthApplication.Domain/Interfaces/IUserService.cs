using JwtAuthApplication.Common.DTOs;

namespace JwtAuthApplication.Domain.Interfaces
{
    public interface IUserService
    {
        public UserResponseDTO? CreateUser(CreateUserRequestDTO userData, out string message);
        public UserResponseDTO? ValidateUser(LoginRequestDTO userData);
    }
}
