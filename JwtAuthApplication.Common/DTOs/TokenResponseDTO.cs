namespace JwtAuthApplication.Common.DTOs
{
    public class TokenResponseDTO
    {
        public bool Valid { get; set; }
        public string Token { get; set; }
        public DateTime? Expires { get; set; }
    }
}