using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_1.Migrations
{
    public partial class SeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProdutosData",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagemPath",
                value: "airjordan1.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProdutosData",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagemPath",
                value: "/wwwroot/airjordan1.jpg");
        }
    }
}
