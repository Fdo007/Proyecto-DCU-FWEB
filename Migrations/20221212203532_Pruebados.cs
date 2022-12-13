using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_DCU_FWEB.Migrations
{
    public partial class Pruebados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenPATH",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenPATH",
                table: "AspNetUsers");
        }
    }
}
