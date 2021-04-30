using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractorJobBuilderV2.Infrastructure.Migrations
{
    public partial class ValueObjectAsIdentity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_JobTaskItems_JobTaskId1",
                table: "JobTaskItems");

            migrationBuilder.DropColumn(
                name: "JobId1",
                table: "JobTasks");

            migrationBuilder.DropColumn(
                name: "JobTaskId1",
                table: "JobTaskItems");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_JobId",
                table: "JobTasks",
                column: "JobId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Jobs_JobId",
                table: "JobTasks",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTaskItems_JobTasks_JobTaskId",
                table: "JobTaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Jobs_JobId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_JobId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTaskItems_JobTaskId",
                table: "JobTaskItems");

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
    }
}
