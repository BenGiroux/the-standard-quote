using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractorJobBuilderV2.Infrastructure.Migrations
{
    public partial class AddingSmartEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Jobs",
                newName: "TitleAndDescription_Description");

            migrationBuilder.RenameColumn(
                name: "IndustryType",
                table: "Jobs",
                newName: "IndustryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitleAndDescription_Description",
                table: "Jobs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "IndustryId",
                table: "Jobs",
                newName: "IndustryType");
        }
    }
}
