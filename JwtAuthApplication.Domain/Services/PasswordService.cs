using JwtAuthApplication.Common.DTOs;
using JwtAuthApplication.Common.Models;
using JwtAuthApplication.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace JwtAuthApplication.Domain.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public PasswordService()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public User CreateUser(CreateUserRequestDTO userData)
        {
            var responseUser = new User()
            {
                UserName = userData.UserName,
                UserType = userData.UserType
            };

            responseUser.Password = _passwordHasher.HashPassword(responseUser, userData.Password);

            return responseUser;
        }
        public bool ValidatePassword(User userData, string password)
        {
            var validationResult = _passwordHasher.VerifyHashedPassword(userData, userData.Password, password);
            return validationResult.Equals(PasswordVerificationResult.Success);
        }
    }
}
