using JwtAuthApplication.Common.Data;
using JwtAuthApplication.Common.DTOs;
using JwtAuthApplication.Common.Enums;
using JwtAuthApplication.Common.Interfaces;
using JwtAuthApplication.Common.Models;
using JwtAuthApplication.Domain.Interfaces;

namespace JwtAuthApplication.Domain.Services
{
    public class UserService : IUserService
    {
        private IPasswordService _passwordService;
        private IUserRepository _userRepository;

        public UserService(IPasswordService passwordService, IUserRepository userRepository)
        {
            _passwordService = passwordService;
            _userRepository = userRepository;

            CreateUser(new CreateUserRequestDTO()
            {
                UserName = "Admin",
                Password = "Admin01",
                UserType = EUserType.Administrator
            }, out string msg);
            CreateUser(new CreateUserRequestDTO()
            {
                UserName = "User",
                Password = "User01",
                UserType = EUserType.Administrator
            }, out msg);
        }

        public UserResponseDTO? CreateUser(CreateUserRequestDTO userData, out string message)
        {
            message = string.Empty;

            if (_userRepository.GetUserByName(userData.UserName) != null)
            {
                message = "User already exists";
                return null;
            }
            else
            {
                var user = _passwordService.CreateUser(userData);
                var createdUser = _userRepository.AddUser(user);

                if (createdUser != null)
                {
                    return new UserResponseDTO()
                    {
                        Id = createdUser.Id,
                        UserName = createdUser.UserName,
                        UserType = createdUser.UserType
                    };
                }
                else
                {
                    message = "Could not create user";
                    return null;
                }
            }
        }
        public UserResponseDTO? ValidateUser(LoginRequestDTO loginData)
        {
            var user = _userRepository.GetUserByName(loginData.UserName);
            if (user != null && _passwordService.ValidatePassword(user, loginData.Password))
            {
                return new UserResponseDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    UserType = user.UserType
                };
            }

            return null;
        }
    }
}
