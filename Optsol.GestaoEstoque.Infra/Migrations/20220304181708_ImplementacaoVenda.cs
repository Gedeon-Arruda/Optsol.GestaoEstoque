using Microsoft.EntityFrameworkCore.Migrations;

namespace Optsol.GestaoEstoque.Infra.Migrations
{
    public partial class ImplementacaoVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_DEPOSITO_DEPOSITOID",
                table: "PRODUTO");

            migrationBuilder.AlterColumn<int>(
                name: "DEPOSITOID",
                table: "PRODUTO",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VENDAID",
                table: "PRODUTO",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_VENDAID",
                table: "PRODUTO",
                column: "VENDAID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_DEPOSITO_DEPOSITOID",
                table: "PRODUTO",
                column: "DEPOSITOID",
                principalTable: "DEPOSITO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_VENDA_VENDAID",
                table: "PRODUTO",
                column: "VENDAID",
                principalTable: "VENDA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_DEPOSITO_DEPOSITOID",
                table: "PRODUTO");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_VENDA_VENDAID",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_VENDAID",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "VENDAID",
                table: "PRODUTO");

            migrationBuilder.AlterColumn<int>(
                name: "DEPOSITOID",
                table: "PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_DEPOSITO_DEPOSITOID",
                table: "PRODUTO",
                column: "DEPOSITOID",
                principalTable: "DEPOSITO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
