using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Optsol.GestaoEstoque.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEPOSITO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LOCALIZACAO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPOSITO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VENDA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COMPRADOR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PRECO = table.Column<int>(type: "int", nullable: false),
                    DEPOSITOID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUTO_DEPOSITO_DEPOSITOID",
                        column: x => x.DEPOSITOID,
                        principalTable: "DEPOSITO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VENDAPRODUTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QUANTIDADEVENDIDA = table.Column<int>(type: "int", nullable: false),
                    VENDAID = table.Column<int>(type: "int", nullable: false),
                    PRODUTOID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDAPRODUTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VENDAPRODUTO_PRODUTO_PRODUTOID",
                        column: x => x.PRODUTOID,
                        principalTable: "PRODUTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VENDAPRODUTO_VENDA_VENDAID",
                        column: x => x.VENDAID,
                        principalTable: "VENDA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_DEPOSITOID",
                table: "PRODUTO",
                column: "DEPOSITOID");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAPRODUTO_PRODUTOID",
                table: "VENDAPRODUTO",
                column: "PRODUTOID");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAPRODUTO_VENDAID",
                table: "VENDAPRODUTO",
                column: "VENDAID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VENDAPRODUTO");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "VENDA");

            migrationBuilder.DropTable(
                name: "DEPOSITO");
        }
    }
}
