using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rapport.Data.Migrations
{
    public partial class Addons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ReportId",
                table: "Images",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Reports_ReportId",
                table: "Images",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Reports_ReportId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ReportId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Images");
        }
    }
}
