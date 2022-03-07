using Microsoft.EntityFrameworkCore.Migrations;

namespace Optsol.GestaoEstoque.Infra.Migrations
{
    public partial class RelacionamentoDepositoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DEPOSITOID",
                table: "PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_DEPOSITOID",
                table: "PRODUTO",
                column: "DEPOSITOID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_DEPOSITO_DEPOSITOID",
                table: "PRODUTO",
                column: "DEPOSITOID",
                principalTable: "DEPOSITO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_DEPOSITO_DEPOSITOID",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_DEPOSITOID",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "DEPOSITOID",
                table: "PRODUTO");
        }
    }
}
