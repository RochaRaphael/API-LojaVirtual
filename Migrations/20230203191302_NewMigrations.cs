using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILojaVirtual.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Url = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false),
                    Excluido = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Login = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    ChaveVerificacao = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: true),
                    LastToken = table.Column<string>(type: "NVARCHAR(MAX)", maxLength: 256, nullable: true),
                    IsVerification = table.Column<bool>(type: "BIT", nullable: true),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false),
                    Excluido = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Url = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Quantidade = table.Column<int>(type: "INT", nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false),
                    Excluido = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "DATE", nullable: false, defaultValue: new DateTime(2023, 2, 3, 19, 13, 2, 240, DateTimeKind.Utc).AddTicks(9173))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => new { x.PedidoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_Pedido_ProdutoId",
                        column: x => x.PedidoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtoo_PedidoId",
                        column: x => x.ProdutoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
