namespace WEBAPI.Models.Users
{
    public class TokenResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
