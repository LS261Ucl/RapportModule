using Microsoft.EntityFrameworkCore;
using Rapport.Entites;
using Rapport.Entites.Identity;

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
        public DbSet<Image>? Images { get; set; }
        public DbSet<FinalReport>? FinalReports { get; set; }
        public DbSet<AppUser>? AppUsers { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity("Rapport.Entites.Report", b =>
            {
                b.HasOne("Rapport.Entites.Template", "Template")
                    .WithMany("Reports")
                    .HasForeignKey("TemplateId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.Navigation("Template");
            });

            modelbuilder.Entity("Rapport.Entites.ReportElement", b =>
            {
                b.HasOne("Rapport.Entites.ReportGroup", "ReportGroup")
                    .WithMany("Elements")
                    .HasForeignKey("ReportGroupId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Rapport.Entites.TemplateElement", "TemplateElement")
                    .WithMany("ReportElements")
                    .HasForeignKey("TemplateElementId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.Navigation("ReportGroup");

                b.Navigation("TemplateElement");
            });

            modelbuilder.Entity("Rapport.Entites.ReportGroup", b =>
            {
                b.HasOne("Rapport.Entites.Report", "Report")
                    .WithMany("ReportGroups")
                    .HasForeignKey("ReportId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Rapport.Entites.TemplateGroup", null)
                    .WithMany("ReportGroups")
                    .HasForeignKey("TemplateGroupId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.Navigation("Report");
            });
       
        }
    }
}
