using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_1.Migrations.DBContextUserMigrations
{
    public partial class AdicionaCep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "AspNetUsers");
        }
    }
}
