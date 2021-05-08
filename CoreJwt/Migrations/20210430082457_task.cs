using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class task : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskType = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    TaskTypeId = table.Column<int>(nullable: false),
                    PriorityId = table.Column<int>(nullable: false),
                    TaskGroupId = table.Column<int>(nullable: false),
                    RelatedToId = table.Column<int>(nullable: false),
                    ProStatusId = table.Column<int>(nullable: false),
                    IndustryId = table.Column<int>(nullable: false),
                    StartDate = table.Column<string>(nullable: true),
                    DueDate = table.Column<string>(nullable: true),
                    EstimateHr = table.Column<string>(nullable: true),
                    BreakTime = table.Column<string>(nullable: true),
                    SpendTime = table.Column<string>(nullable: true),
                    TimeLog1 = table.Column<string>(nullable: true),
                    TimeLog2 = table.Column<string>(nullable: true),
                    checklist = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");
        }
    }
}
