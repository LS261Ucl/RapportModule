using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rapport.Data.Migrations
{
    public partial class changetoReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "FinalReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "FinalReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinalReports_ReportId",
                table: "FinalReports",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinalReports_Reports_ReportId",
                table: "FinalReports",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinalReports_Reports_ReportId",
                table: "FinalReports");

            migrationBuilder.DropIndex(
                name: "IX_FinalReports_ReportId",
                table: "FinalReports");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "FinalReports");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                table: "FinalReports",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
