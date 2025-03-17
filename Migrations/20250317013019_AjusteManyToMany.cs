using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPrecos.Core.Migrations
{
    /// <inheritdoc />
    public partial class AjusteManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "id_categoria",
                table: "categoria_produto");

            migrationBuilder.DropForeignKey(
                name: "id_produto",
                table: "categoria_produto");

            migrationBuilder.DropForeignKey(
                name: "id_produto",
                table: "preco");

            migrationBuilder.DropForeignKey(
                name: "id_categoria",
                table: "produto");

            migrationBuilder.DropTable(
                name: "relatorio_produto");

            /*migrationBuilder.DropIndex(
                name: "IX_produto_id_categoria",
                table: "produto");*/

            migrationBuilder.DropPrimaryKey(
                name: "categoria_produto_pkey",
                table: "categoria_produto");

            /*migrationBuilder.DropColumn(
                name: "categoria",
                table: "produto");*/

            migrationBuilder.DropColumn(
                name: "id_categoria",
                table: "produto");

            migrationBuilder.RenameColumn(
                name: "id_produto",
                table: "categoria_produto",
                newName: "IdProduto");

            migrationBuilder.RenameColumn(
                name: "id_categoria",
                table: "categoria_produto",
                newName: "IdCategoria");

            /*migrationBuilder.RenameIndex(
                name: "IX_categoria_produto_id_produto",
                table: "categoria_produto",
                newName: "IX_categoria_produto_IdProduto");*/

            migrationBuilder.AddColumn<int>(
                name: "RelatorioIdRelatorio",
                table: "produto",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoCategoria",
                table: "produto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoria_produto",
                table: "categoria_produto",
                columns: new[] { "IdCategoria", "IdProduto" });

            migrationBuilder.CreateIndex(
                name: "IX_produto_RelatorioIdRelatorio",
                table: "produto",
                column: "RelatorioIdRelatorio");

            migrationBuilder.AddForeignKey(
                name: "FK_categoria_produto_categoria_IdCategoria",
                table: "categoria_produto",
                column: "IdCategoria",
                principalTable: "categoria",
                principalColumn: "id_categoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categoria_produto_produto_IdProduto",
                table: "categoria_produto",
                column: "IdProduto",
                principalTable: "produto",
                principalColumn: "id_produto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_relatorio_RelatorioIdRelatorio",
                table: "produto",
                column: "RelatorioIdRelatorio",
                principalTable: "relatorio",
                principalColumn: "id_relatorio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoria_produto_categoria_IdCategoria",
                table: "categoria_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_categoria_produto_produto_IdProduto",
                table: "categoria_produto");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_relatorio_RelatorioIdRelatorio",
                table: "produto");

            migrationBuilder.DropIndex(
                name: "IX_produto_RelatorioIdRelatorio",
                table: "produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoria_produto",
                table: "categoria_produto");

            migrationBuilder.DropColumn(
                name: "RelatorioIdRelatorio",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "TipoCategoria",
                table: "produto");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "categoria_produto",
                newName: "id_produto");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "categoria_produto",
                newName: "id_categoria");

            migrationBuilder.RenameIndex(
                name: "IX_categoria_produto_IdProduto",
                table: "categoria_produto",
                newName: "IX_categoria_produto_id_produto");

            migrationBuilder.AddColumn<string>(
                name: "categoria",
                table: "produto",
                type: "character varying",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "id_categoria",
                table: "produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "categoria_produto_pkey",
                table: "categoria_produto",
                columns: new[] { "id_categoria", "id_produto" });

            migrationBuilder.CreateTable(
                name: "relatorio_produto",
                columns: table => new
                {
                    id_produto = table.Column<int>(type: "integer", nullable: false),
                    id_relatorio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("relatorio_produto_pkey", x => new { x.id_produto, x.id_relatorio });
                    table.ForeignKey(
                        name: "id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id_produto");
                    table.ForeignKey(
                        name: "id_relatorio",
                        column: x => x.id_relatorio,
                        principalTable: "relatorio",
                        principalColumn: "id_relatorio");
                });

            migrationBuilder.CreateIndex(
                name: "IX_produto_id_categoria",
                table: "produto",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_relatorio_produto_id_relatorio",
                table: "relatorio_produto",
                column: "id_relatorio");

            migrationBuilder.AddForeignKey(
                name: "id_categoria",
                table: "categoria_produto",
                column: "id_categoria",
                principalTable: "categoria",
                principalColumn: "id_categoria");

            migrationBuilder.AddForeignKey(
                name: "id_produto",
                table: "categoria_produto",
                column: "id_produto",
                principalTable: "produto",
                principalColumn: "id_produto");

            migrationBuilder.AddForeignKey(
                name: "id_categoria",
                table: "produto",
                column: "id_categoria",
                principalTable: "categoria",
                principalColumn: "id_categoria");
        }
    }
}
