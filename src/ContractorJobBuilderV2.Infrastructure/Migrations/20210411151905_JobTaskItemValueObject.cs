using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractorJobBuilderV2.Infrastructure.Migrations
{
    public partial class JobTaskItemValueObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTaskItems_JobTasks_JobTaskId",
                table: "JobTaskItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems");

            migrationBuilder.DropIndex(
                name: "IX_JobTaskItems_JobTaskId",
                table: "JobTaskItems");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "JobTaskItems",
                newName: "Summary");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobTaskId",
                table: "JobTaskItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "JobTaskItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems",
                columns: new[] { "JobTaskId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobTaskItems_JobTasks_JobTaskId",
                table: "JobTaskItems",
                column: "JobTaskId",
                principalTable: "JobTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTaskItems_JobTasks_JobTaskId",
                table: "JobTaskItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "JobTaskItems",
                newName: "Description");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "JobTaskItems",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobTaskId",
                table: "JobTaskItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskItems_JobTaskId",
                table: "JobTaskItems",
                column: "JobTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTaskItems_JobTasks_JobTaskId",
                table: "JobTaskItems",
                column: "JobTaskId",
                principalTable: "JobTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
