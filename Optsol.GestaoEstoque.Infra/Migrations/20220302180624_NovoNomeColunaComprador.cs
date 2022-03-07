using Microsoft.EntityFrameworkCore.Migrations;

namespace Optsol.GestaoEstoque.Infra.Migrations
{
    public partial class NovoNomeColunaComprador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comprador",
                table: "PRODUTO",
                newName: "Compradorrrrr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Compradorrrrr",
                table: "PRODUTO",
                newName: "Comprador");
        }
    }
}
