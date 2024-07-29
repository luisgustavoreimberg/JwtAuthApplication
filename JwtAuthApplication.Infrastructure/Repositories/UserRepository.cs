using JwtAuthApplication.Common.Data;
using JwtAuthApplication.Common.Interfaces;
using JwtAuthApplication.Common.Models;

namespace JwtAuthApplication.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User? AddUser(User user)
        {
            UserList.users.Add(user);
            return GetUserByName(user.UserName);
        }

        public User? GetUserByName(string userName)
        {
            return UserList.users.FirstOrDefault(user => user.UserName.Equals(userName));
        }
    }
}