using JwtAuthApplication.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthApplication.Common.Interfaces
{
    public interface IUserRepository
    {
        public User? GetUserByName(string userName);
        public User? AddUser(User user);
    }
}