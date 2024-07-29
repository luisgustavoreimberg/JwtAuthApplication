using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthApplication.Infrastructure.Configurations
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int TokenExpirationInMinutes { get; set; }
    }
}