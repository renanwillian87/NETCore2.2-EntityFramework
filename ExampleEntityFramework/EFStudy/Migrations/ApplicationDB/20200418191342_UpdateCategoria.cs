using Microsoft.EntityFrameworkCore.Migrations;

namespace EFStudy.Migrations.ApplicationDB
{
    public partial class UpdateCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "Categorias",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
