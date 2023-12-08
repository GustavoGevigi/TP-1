using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_1.Migrations
{
    public partial class AddRelDependencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "ProdutosData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosData_MarcaId",
                table: "ProdutosData",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosData_MarcasData_MarcaId",
                table: "ProdutosData",
                column: "MarcaId",
                principalTable: "MarcasData",
                principalColumn: "MarcasDataId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosData_MarcasData_MarcaId",
                table: "ProdutosData");

            migrationBuilder.DropIndex(
                name: "IX_ProdutosData_MarcaId",
                table: "ProdutosData");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "ProdutosData");
        }
    }
}
