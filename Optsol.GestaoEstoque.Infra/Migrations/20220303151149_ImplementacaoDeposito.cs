using Microsoft.EntityFrameworkCore.Migrations;

namespace Optsol.GestaoEstoque.Infra.Migrations
{
    public partial class ImplementacaoDeposito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "ID",
                table: "PRODUTO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PRODUTO",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUTO_ID",
                table: "PRODUTO",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "DEPOSITO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPOSITO_ID", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEPOSITO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUTO_ID",
                table: "PRODUTO");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PRODUTO",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "ID",
                table: "PRODUTO",
                column: "Id");
        }
    }
}
