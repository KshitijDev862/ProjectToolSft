using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class timelog1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "timelog");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "timelog");

            migrationBuilder.AddColumn<DateTime>(
                name: "Enddate",
                table: "timelog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Startdate",
                table: "timelog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enddate",
                table: "timelog");

            migrationBuilder.DropColumn(
                name: "Startdate",
                table: "timelog");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "timelog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "timelog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
