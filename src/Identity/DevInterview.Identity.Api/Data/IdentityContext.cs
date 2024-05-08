using DevInterview.Identity.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DevInterview.Identity.Api.Data
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
