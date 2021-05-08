using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class gh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "assiginProject",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_assiginProject_ProjectId",
                table: "assiginProject",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_assiginProject_projects_ProjectId",
                table: "assiginProject",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assiginProject_projects_ProjectId",
                table: "assiginProject");

            migrationBuilder.DropIndex(
                name: "IX_assiginProject_ProjectId",
                table: "assiginProject");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "assiginProject");
        }
    }
}
