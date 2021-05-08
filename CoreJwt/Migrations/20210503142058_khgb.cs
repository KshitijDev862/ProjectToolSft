using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class khgb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectRoleId",
                table: "assiginProject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_assiginProject_ProjectRoleId",
                table: "assiginProject",
                column: "ProjectRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_assiginProject_roleProject_ProjectRoleId",
                table: "assiginProject",
                column: "ProjectRoleId",
                principalTable: "roleProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assiginProject_roleProject_ProjectRoleId",
                table: "assiginProject");

            migrationBuilder.DropIndex(
                name: "IX_assiginProject_ProjectRoleId",
                table: "assiginProject");

            migrationBuilder.DropColumn(
                name: "ProjectRoleId",
                table: "assiginProject");
        }
    }
}
