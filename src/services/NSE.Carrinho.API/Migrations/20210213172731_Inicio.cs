using Microsoft.EntityFrameworkCore.Migrations;

namespace NSE.Carrinho.API.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_CarrinhoClientes_CarrinhoId",
                table: "CarrinhoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoClientes",
                table: "CarrinhoClientes");

            migrationBuilder.RenameTable(
                name: "CarrinhoClientes",
                newName: "CarrinhoCliente");

            migrationBuilder.RenameIndex(
                name: "IDX_CLIENTE",
                table: "CarrinhoCliente",
                newName: "IDX_Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoCliente",
                table: "CarrinhoCliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId",
                principalTable: "CarrinhoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoCliente",
                table: "CarrinhoCliente");

            migrationBuilder.RenameTable(
                name: "CarrinhoCliente",
                newName: "CarrinhoClientes");

            migrationBuilder.RenameIndex(
                name: "IDX_Cliente",
                table: "CarrinhoClientes",
                newName: "IDX_CLIENTE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoClientes",
                table: "CarrinhoClientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_CarrinhoClientes_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId",
                principalTable: "CarrinhoClientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
