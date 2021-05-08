using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class gh1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "assiginProject",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "assiginProject",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "assiginProject",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
