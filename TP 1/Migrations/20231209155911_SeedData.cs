using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_1.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MarcasData",
                columns: new[] { "MarcasDataId", "Nome" },
                values: new object[] { 2, "Nike" });

            migrationBuilder.InsertData(
                table: "ProdutosData",
                columns: new[] { "Id", "DataLancamento", "Descricao", "Disponivel", "ImagemPath", "Nome", "Preco" },
                values: new object[] { 1, new DateTime(1985, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Um clássico do basquete", false, "/wwwroot/airjordan1.jpg", "Air Jordan 1", 1999.99 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MarcasData",
                keyColumn: "MarcasDataId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProdutosData",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
