using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class dgbgrr56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectRoleId",
                table: "users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_ProjectRoleId",
                table: "users",
                column: "ProjectRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roleProject_ProjectRoleId",
                table: "users",
                column: "ProjectRoleId",
                principalTable: "roleProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roleProject_ProjectRoleId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_ProjectRoleId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ProjectRoleId",
                table: "users");
        }
    }
}
