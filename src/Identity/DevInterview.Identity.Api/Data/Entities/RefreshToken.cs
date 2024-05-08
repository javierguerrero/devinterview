using Microsoft.AspNetCore.Identity;

namespace DevInterview.Identity.Api.Data.Entities
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public string RefreshTokenValue { get; set; }
        public bool Active { get; set; }
        public DateTime Expiration { get; set; }
        public bool Used { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
    }
}
