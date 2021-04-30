using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractorJobBuilderV2.Infrastructure.Migrations
{
    public partial class JobTaskItemValueObjectKeyJSON : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTaskItems");

            migrationBuilder.AddColumn<string>(
                name: "JobTaskItems",
                table: "JobTasks",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobTaskItems",
                table: "JobTasks");

            migrationBuilder.CreateTable(
                name: "JobTaskItems",
                columns: table => new
                {
                    Summary = table.Column<string>(type: "TEXT", nullable: false),
                    JobTaskId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTaskItems", x => new { x.Summary, x.JobTaskId });
                    table.ForeignKey(
                        name: "FK_JobTaskItems_JobTasks_JobTaskId",
                        column: x => x.JobTaskId,
                        principalTable: "JobTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskItems_JobTaskId",
                table: "JobTaskItems",
                column: "JobTaskId");
        }
    }
}
