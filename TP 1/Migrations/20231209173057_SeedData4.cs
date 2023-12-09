using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_1.Migrations
{
    public partial class SeedData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "MarcasData",
                newName: "MarcasDataNome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MarcasDataNome",
                table: "MarcasData",
                newName: "Nome");
        }
    }
}
