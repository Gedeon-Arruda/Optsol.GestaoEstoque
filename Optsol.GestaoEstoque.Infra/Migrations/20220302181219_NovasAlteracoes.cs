using Microsoft.EntityFrameworkCore.Migrations;

namespace Optsol.GestaoEstoque.Infra.Migrations
{
    public partial class NovasAlteracoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodigoVenda",
                table: "PRODUTO",
                newName: "CODIGOVENDA");

            migrationBuilder.RenameColumn(
                name: "Compradorrrrr",
                table: "PRODUTO",
                newName: "COMPRADOR");

            migrationBuilder.AlterColumn<string>(
                name: "CODIGOVENDA",
                table: "PRODUTO",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                defaultValue: "11111",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CODIGOVENDA",
                table: "PRODUTO",
                newName: "CodigoVenda");

            migrationBuilder.RenameColumn(
                name: "COMPRADOR",
                table: "PRODUTO",
                newName: "Compradorrrrr");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoVenda",
                table: "PRODUTO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldDefaultValue: "11111");
        }
    }
}
