using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class dgbgrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assiginProject_roleProject_ProjectRoleId",
                table: "assiginProject");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roleProject_ProjectRoleId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_ProjectRoleId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_assiginProject_ProjectRoleId",
                table: "assiginProject");

            migrationBuilder.DropColumn(
                name: "ProjectRoleId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ProjectRoleId",
                table: "assiginProject");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "assiginProject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleId",
                table: "users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_assiginProject_RoleId",
                table: "assiginProject",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_assiginProject_roles_RoleId",
                table: "assiginProject",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_RoleId",
                table: "users",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assiginProject_roles_RoleId",
                table: "assiginProject");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_RoleId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_RoleId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_assiginProject_RoleId",
                table: "assiginProject");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "assiginProject");

            migrationBuilder.AddColumn<int>(
                name: "ProjectRoleId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectRoleId",
                table: "assiginProject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_ProjectRoleId",
                table: "users",
                column: "ProjectRoleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_users_roleProject_ProjectRoleId",
                table: "users",
                column: "ProjectRoleId",
                principalTable: "roleProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
