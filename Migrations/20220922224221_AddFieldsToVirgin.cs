using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Virgins.Migrations
{
    public partial class AddFieldsToVirgin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Virgins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Virgins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsVirgin",
                table: "Virgins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Virgins");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Virgins");

            migrationBuilder.DropColumn(
                name: "IsVirgin",
                table: "Virgins");
        }
    }
}
