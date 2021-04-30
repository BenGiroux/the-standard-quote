using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractorJobBuilderV2.Infrastructure.Migrations
{
    public partial class JobTaskItemValueObjectKeyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems",
                columns: new[] { "Summary", "JobTaskId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems",
                column: "Summary");
        }
    }
}
