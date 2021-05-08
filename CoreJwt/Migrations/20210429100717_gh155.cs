using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class gh155 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "assiginProject");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "assiginProject");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "assiginProject");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "assiginProject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "assiginProject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "assiginProject",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
