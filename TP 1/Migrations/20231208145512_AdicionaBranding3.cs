using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_1.Migrations
{
    public partial class AdicionaBranding3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Branding_MarcaId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_MarcaId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "MarcasBrandingId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_MarcasBrandingId",
                table: "Produtos",
                column: "MarcasBrandingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Branding_MarcasBrandingId",
                table: "Produtos",
                column: "MarcasBrandingId",
                principalTable: "Branding",
                principalColumn: "BrandingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Branding_MarcasBrandingId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_MarcasBrandingId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "MarcasBrandingId",
                table: "Produtos");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_MarcaId",
                table: "Produtos",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Branding_MarcaId",
                table: "Produtos",
                column: "MarcaId",
                principalTable: "Branding",
                principalColumn: "BrandingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
