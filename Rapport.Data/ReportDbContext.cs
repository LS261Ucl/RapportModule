using Microsoft.EntityFrameworkCore;
using Rapport.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Employee>? Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
           

           

            modelbuilder.Entity("Danline.Report.Data.ReportData", b =>
            {
                b.HasOne("Rapport.Entities.Template", "Template")
                    .WithMany("Reports")
                    .HasForeignKey("TemplateId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.Navigation("Template");

                b.HasOne("Rapport.Entities.Customer")
                .WithMany("Reports")
                .HasForeignKey("Customerid")
                .OnDelete(DeleteBehavior.NoAction);

             
                
            });

            modelbuilder.Entity("Rappport.Entities.ReportElement", b =>
            {
                b.HasOne("Rapport.Entities.ReportGroup", "ReportGroup")
                    .WithMany("ReportFields")
                    .HasForeignKey("ReportGroupId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Rapport.Entities.TemplateElement", "TemplateElement")
                    .WithOne("ReportField")
                    .HasForeignKey("Rapport.Entities.ReportElement", "TemplateElementId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.Navigation("ReportGroup");

                b.Navigation("TemplateElement");
            });

            modelbuilder.Entity("Rapport.Entities.ReportGroup", b =>
            {
                b.HasOne("Rapport.Entites.ReportData", "ReportData")
                    .WithMany("ReportGroups")
                    .HasForeignKey("ReportDataId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Rapport.Entities.TemplateGroup", "TemplateGroup")
                    .WithOne("ReportGroup")
                    .HasForeignKey("Rapport.Entities.ReportGroup", "TemplateGroupId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.Navigation("ReportData");

                b.Navigation("TemplateGroup");
            });

            modelbuilder.Entity("Rapport.Entities.TemplateElement", b =>
            {
                b.HasOne("Rapport.Entities.TemplateGroup", "TemplateGroup")
                    .WithMany("Fields")
                    .HasForeignKey("TemplateGroupId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("TemplateGroup");
            });

            modelbuilder.Entity("Rapport.Entities.TemplateGroup", b =>
            {
                b.HasOne("Rapport.Entities.Template", "Template")
                    .WithMany("Groups")
                    .HasForeignKey("TemplateId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Template");
            });
        }
    }
}
