using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractorJobBuilderV2.Infrastructure.Migrations
{
    public partial class ValueObjectAsIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTaskItem_JobTasks_JobTaskId",
                table: "JobTaskItem");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Jobs_JobId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_JobId",
                table: "JobTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTaskItem",
                table: "JobTaskItem");

            migrationBuilder.DropIndex(
                name: "IX_JobTaskItem_JobTaskId",
                table: "JobTaskItem");

            migrationBuilder.RenameTable(
                name: "JobTaskItem",
                newName: "JobTaskItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobId",
                table: "JobTasks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "JobId1",
                table: "JobTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobTaskId1",
                table: "JobTaskItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_JobId1",
                table: "JobTasks",
                column: "JobId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskItems_JobTaskId1",
                table: "JobTaskItems",
                column: "JobTaskId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTaskItems_JobTasks_JobTaskId1",
                table: "JobTaskItems",
                column: "JobTaskId1",
                principalTable: "JobTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Jobs_JobId1",
                table: "JobTasks",
                column: "JobId1",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTaskItems_JobTasks_JobTaskId1",
                table: "JobTaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Jobs_JobId1",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_JobId1",
                table: "JobTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTaskItems",
                table: "JobTaskItems");

            migrationBuilder.DropIndex(
                name: "IX_JobTaskItems_JobTaskId1",
                table: "JobTaskItems");

            migrationBuilder.DropColumn(
                name: "JobId1",
                table: "JobTasks");

            migrationBuilder.DropColumn(
                name: "JobTaskId1",
                table: "JobTaskItems");

            migrationBuilder.RenameTable(
                name: "JobTaskItems",
                newName: "JobTaskItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobId",
                table: "JobTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTaskItem",
                table: "JobTaskItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_JobId",
                table: "JobTasks",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskItem_JobTaskId",
                table: "JobTaskItem",
                column: "JobTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTaskItem_JobTasks_JobTaskId",
                table: "JobTaskItem",
                column: "JobTaskId",
                principalTable: "JobTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Jobs_JobId",
                table: "JobTasks",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
