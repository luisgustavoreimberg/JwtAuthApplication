using JwtAuthApplication.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace JwtAuthApplication.Common.DTOs
{
    public class CreateUserRequestDTO
    {
        [Required]
        [MinLength(5)]
        public string UserName { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        [Required]
        public EUserType UserType { get; set; }
    }
}