using Microsoft.EntityFrameworkCore;
using Rapport.Entites.Identity;

namespace Rapport.Server.Data
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
