using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_1.Migrations
{
    public partial class SeedData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MarcasData",
                columns: new[] { "MarcasDataId", "Nome" },
                values: new object[] { 2, "Adidas" });

            migrationBuilder.InsertData(
                table: "MarcasData",
                columns: new[] { "MarcasDataId", "Nome" },
                values: new object[] { 3, "Puma" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MarcasData",
                keyColumn: "MarcasDataId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MarcasData",
                keyColumn: "MarcasDataId",
                keyValue: 3);
        }
    }
}
