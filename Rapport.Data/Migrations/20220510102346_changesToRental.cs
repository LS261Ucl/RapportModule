using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rapport.Data.Migrations
{
    public partial class changesToRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalPeriodEnd",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "RentalPeriodStart",
                table: "Reports",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "LayoutId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LayoutId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reports",
                newName: "RentalPeriodStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalPeriodEnd",
                table: "Reports",
                type: "datetime2",
                nullable: true);
        }
    }
}
