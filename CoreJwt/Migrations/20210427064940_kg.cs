using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class kg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectRoleId",
                table: "assiginProject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjectRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assiginProject_ProjectRoleId",
                table: "assiginProject",
                column: "ProjectRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_assiginProject_ProjectRole_ProjectRoleId",
                table: "assiginProject",
                column: "ProjectRoleId",
                principalTable: "ProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assiginProject_ProjectRole_ProjectRoleId",
                table: "assiginProject");

            migrationBuilder.DropTable(
                name: "ProjectRole");

            migrationBuilder.DropIndex(
                name: "IX_assiginProject_ProjectRoleId",
                table: "assiginProject");

            migrationBuilder.DropColumn(
                name: "ProjectRoleId",
                table: "assiginProject");
        }
    }
}
