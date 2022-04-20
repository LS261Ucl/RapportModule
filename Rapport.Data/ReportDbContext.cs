using Microsoft.EntityFrameworkCore;
using Rapport.Entites;

namespace Rapport.Data
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {
        }

        
        public DbSet<Template>? Templates{ get; set; }
        public DbSet<TemplateGroup>? TemplateGroups { get; set; }
        public DbSet<TemplateElement>? TemplateElements { get; set; }
        public DbSet<Report>? Reports { get; set; }
        public DbSet<ReportGroup>? ReportGroups { get; set; }
        public DbSet<ReportElement>? ReportElements { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
        }
    }
}
