using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Riva.DataAccessLayer.Migrations
{
    public partial class mig13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description2",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Description3",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Title2",
                table: "Sliders");

            migrationBuilder.RenameColumn(
                name: "Title3",
                table: "Sliders",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Sliders",
                newName: "Title3");

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description3",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
