using JwtAuthApplication.Common.DTOs;
using JwtAuthApplication.Common.Models;

namespace JwtAuthApplication.Domain.Interfaces
{
    public interface IPasswordService
    {
        public User CreateUser(CreateUserRequestDTO userData);
        public bool ValidatePassword(User userData, string password);
    }
}
