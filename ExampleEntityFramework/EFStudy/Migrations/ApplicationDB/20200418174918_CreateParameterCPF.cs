using Microsoft.EntityFrameworkCore.Migrations;

namespace EFStudy.Migrations.ApplicationDB
{
    public partial class CreateParameterCPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Funcionarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Funcionarios");
        }
    }
}
