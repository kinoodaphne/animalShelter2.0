using Microsoft.EntityFrameworkCore.Migrations;

namespace Shelter.MVC.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Animals",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Declawed",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Barker",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Animals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Declawed",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Barker",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Animals");
        }
    }
}
