using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class taskFileff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Task_PriorityId",
                table: "Task",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserId",
                table: "Task",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_priority_PriorityId",
                table: "Task",
                column: "PriorityId",
                principalTable: "priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_users_UserId",
                table: "Task",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_priority_PriorityId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_users_UserId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_PriorityId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_UserId",
                table: "Task");
        }
    }
}
