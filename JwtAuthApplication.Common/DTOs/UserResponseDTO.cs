using JwtAuthApplication.Common.Enums;

namespace JwtAuthApplication.Common.DTOs
{
    public class UserResponseDTO
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public EUserType UserType { get; set; }
    }
}