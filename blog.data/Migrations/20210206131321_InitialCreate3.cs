using Microsoft.EntityFrameworkCore.Migrations;

namespace shopapp.data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Yeteneklers",
                table: "Yeteneklers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projes",
                table: "Projes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kisisels",
                table: "Kisisels");

            migrationBuilder.RenameTable(
                name: "Yeteneklers",
                newName: "Yetenekler");

            migrationBuilder.RenameTable(
                name: "Projes",
                newName: "Projeler");

            migrationBuilder.RenameTable(
                name: "Kisisels",
                newName: "Kisisel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yetenekler",
                table: "Yetenekler",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projeler",
                table: "Projeler",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kisisel",
                table: "Kisisel",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Yetenekler",
                table: "Yetenekler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projeler",
                table: "Projeler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kisisel",
                table: "Kisisel");

            migrationBuilder.RenameTable(
                name: "Yetenekler",
                newName: "Yeteneklers");

            migrationBuilder.RenameTable(
                name: "Projeler",
                newName: "Projes");

            migrationBuilder.RenameTable(
                name: "Kisisel",
                newName: "Kisisels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yeteneklers",
                table: "Yeteneklers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projes",
                table: "Projes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kisisels",
                table: "Kisisels",
                column: "id");
        }
    }
}
