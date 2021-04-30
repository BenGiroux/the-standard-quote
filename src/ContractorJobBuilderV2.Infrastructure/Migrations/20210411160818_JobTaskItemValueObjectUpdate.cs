using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractorJobBuilderV2.Infrastructure.Migrations
{
    public partial class JobTaskItemValueObjectUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobTaskItems");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "JobTaskItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems",
                column: "Summary");

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskItems_JobTaskId",
                table: "JobTaskItems",
                column: "JobTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems");

            migrationBuilder.DropIndex(
                name: "IX_JobTaskItems_JobTaskId",
                table: "JobTaskItems");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "JobTaskItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JobTaskItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems",
                columns: new[] { "JobTaskId", "Id" });
        }
    }
}
