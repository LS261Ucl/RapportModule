﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rapport.Data;

#nullable disable

namespace Rapport.Data.Migrations
{
    [DbContext(typeof(ReportDbContext))]
    partial class ReportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Rapport.Entites.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Rapport.Entites.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsReadOnly")
                        .HasColumnType("bit");

                    b.Property<int>("LayoutId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Rapport.Entites.ReportElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("Numbers")
                        .HasColumnType("float");

                    b.Property<string>("Options")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportGroupId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateElementId")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReportGroupId");

                    b.HasIndex("TemplateElementId");

                    b.ToTable("ReportElements");
                });

            modelBuilder.Entity("Rapport.Entites.ReportGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.HasIndex("TemplateGroupId");

                    b.ToTable("ReportGroups");
                });

            modelBuilder.Entity("Rapport.Entites.Template", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int?>("LayoutId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("Rapport.Entites.TemplateElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Datatype")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Options")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TemplateGroupId");

                    b.ToTable("TemplateElements");
                });

            modelBuilder.Entity("Rapport.Entites.TemplateGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateGroups");
                });

            modelBuilder.Entity("Rapport.Entites.Report", b =>
                {
                    b.HasOne("Rapport.Entites.Template", "Template")
                        .WithMany("Reports")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Rapport.Entites.ReportElement", b =>
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

            modelBuilder.Entity("Rapport.Entites.ReportGroup", b =>
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

            modelBuilder.Entity("Rapport.Entites.TemplateElement", b =>
                {
                    b.HasOne("Rapport.Entites.TemplateGroup", "TemplateGroup")
                        .WithMany("Elements")
                        .HasForeignKey("TemplateGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateGroup");
                });

            modelBuilder.Entity("Rapport.Entites.TemplateGroup", b =>
                {
                    b.HasOne("Rapport.Entites.Template", "Template")
                        .WithMany("TemplateGroups")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Rapport.Entites.Report", b =>
                {
                    b.Navigation("ReportGroups");
                });

            modelBuilder.Entity("Rapport.Entites.ReportGroup", b =>
                {
                    b.Navigation("Elements");
                });

            modelBuilder.Entity("Rapport.Entites.Template", b =>
                {
                    b.Navigation("Reports");

                    b.Navigation("TemplateGroups");
                });

            modelBuilder.Entity("Rapport.Entites.TemplateElement", b =>
                {
                    b.Navigation("ReportElements");
                });

            modelBuilder.Entity("Rapport.Entites.TemplateGroup", b =>
                {
                    b.Navigation("Elements");

                    b.Navigation("ReportGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
