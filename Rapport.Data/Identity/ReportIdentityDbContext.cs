using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rapport.Entites.Identity;

namespace Rapport.Data.Identity
{
    public class ReportIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public ReportIdentityDbContext(DbContextOptions<ReportIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        
    }
}
