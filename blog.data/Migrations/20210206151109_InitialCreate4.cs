using Microsoft.EntityFrameworkCore.Migrations;

namespace shopapp.data.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img1",
                table: "Projeler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img2",
                table: "Projeler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img3",
                table: "Projeler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ozet",
                table: "Projeler",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img1",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "img2",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "img3",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "ozet",
                table: "Projeler");
        }
    }
}
