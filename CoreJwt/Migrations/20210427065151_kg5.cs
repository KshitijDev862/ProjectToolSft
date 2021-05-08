using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class kg5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assiginProject_ProjectRole_ProjectRoleId",
                table: "assiginProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectRole",
                table: "ProjectRole");

            migrationBuilder.RenameTable(
                name: "ProjectRole",
                newName: "roleProject");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roleProject",
                table: "roleProject",
                column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_roleProject",
                table: "roleProject");

            migrationBuilder.RenameTable(
                name: "roleProject",
                newName: "ProjectRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectRole",
                table: "ProjectRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assiginProject_ProjectRole_ProjectRoleId",
                table: "assiginProject",
                column: "ProjectRoleId",
                principalTable: "ProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
