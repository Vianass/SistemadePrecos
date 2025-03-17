using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPrecos.Core.Migrations
{
    /// <inheritdoc />
    public partial class AjustesApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                    {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    });
        }

            /*migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categoria_pkey", x => x.id_categoria);
                });*/

            /*migrationBuilder.CreateTable(
                name: "loja",
                columns: table => new
                {
                    id_loja = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying", nullable: false),
                    localizacao = table.Column<string>(type: "character varying", nullable: false),
                    contacto = table.Column<decimal>(type: "numeric", nullable: false),
                    data_criacao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("loja_pkey", x => x.id_loja);
                });*/

            /*migrationBuilder.CreateTable(
                name: "mensagem",
                columns: table => new
                {
                    id_mensagem = table.Column<int>(type: "integer", nullable: false),
                    conteudo = table.Column<string>(type: "character varying", nullable: false),
                    data_envio = table.Column<DateOnly>(type: "date", nullable: false),
                    application_user_id = table.Column<string>(type: "varchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("mensagem_pkey", x => x.id_mensagem);
                    table.ForeignKey(
                        name: "fk_mensagem_user",
                        column: x => x.application_user_id,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });*/

            /*migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id_produto = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying", nullable: false),
                    categoria = table.Column<string>(type: "character varying", nullable: false),
                    descricao = table.Column<string>(type: "character varying", nullable: false),
                    id_categoria = table.Column<int>(type: "integer", nullable: false),
                    application_user_id = table.Column<string>(type: "varchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("produto_pkey", x => x.id_produto);
                    table.ForeignKey(
                        name: "fk_produto_user",
                        column: x => x.application_user_id,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categoria",
                        principalColumn: "id_categoria");
                });*/

            /*migrationBuilder.CreateTable(
                name: "categoria_produto",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "integer", nullable: false),
                    id_produto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categoria_produto_pkey", x => new { x.id_categoria, x.id_produto });
                    table.ForeignKey(
                        name: "id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categoria",
                        principalColumn: "id_categoria");
                    table.ForeignKey(
                        name: "id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id_produto");
                });

            migrationBuilder.CreateTable(
                name: "preco",
                columns: table => new
                {
                    id_preco = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false),
                    data_hora = table.Column<DateOnly>(type: "date", nullable: false),
                    credibilidade = table.Column<string>(type: "character varying", nullable: false),
                    id_produto = table.Column<int>(type: "integer", nullable: false),
                    application_user_id = table.Column<string>(type: "varchar(450)", nullable: false),
                    id_loja = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("preco_pkey", x => x.id_preco);
                    table.ForeignKey(
                        name: "application_user_id",
                        column: x => x.application_user_id,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "id_loja",
                        column: x => x.id_loja,
                        principalTable: "loja",
                        principalColumn: "id_loja");
                    table.ForeignKey(
                        name: "id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id_produto");
                });

            migrationBuilder.CreateTable(
                name: "relatorio",
                columns: table => new
                {
                    id_relatorio = table.Column<int>(type: "integer", nullable: false),
                    tipo = table.Column<string>(type: "character varying", nullable: false),
                    dados = table.Column<string>(type: "character varying", nullable: false),
                    data_geracao = table.Column<DateOnly>(type: "date", nullable: false),
                    id_loja = table.Column<int>(type: "integer", nullable: false),
                    id_produto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("relatorio_pkey", x => x.id_relatorio);
                    table.ForeignKey(
                        name: "id_loja",
                        column: x => x.id_loja,
                        principalTable: "loja",
                        principalColumn: "id_loja");
                    table.ForeignKey(
                        name: "id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id_produto");
                });

            migrationBuilder.CreateTable(
                name: "avaliacao_preco",
                columns: table => new
                {
                    id_avaliacao = table.Column<int>(type: "integer", nullable: false),
                    comentario = table.Column<string>(type: "character varying", nullable: false),
                    confiabilidade = table.Column<string>(type: "character varying", nullable: false),
                    id_preco = table.Column<int>(type: "integer", nullable: false),
                    application_user_id = table.Column<string>(type: "varchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("avaliacao_preco_pkey", x => x.id_avaliacao);
                    table.ForeignKey(
                        name: "FK_avaliacao_preco_ApplicationUser_application_user_id",
                        column: x => x.application_user_id,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "id_preco",
                        column: x => x.id_preco,
                        principalTable: "preco",
                        principalColumn: "id_preco");
                });

            migrationBuilder.CreateTable(
                name: "relatorio_loja",
                columns: table => new
                {
                    id_relatoro = table.Column<int>(type: "integer", nullable: false),
                    id_loja = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("relatorio_loja_pkey", x => new { x.id_relatoro, x.id_loja });
                    table.ForeignKey(
                        name: "id_loja",
                        column: x => x.id_loja,
                        principalTable: "loja",
                        principalColumn: "id_loja");
                    table.ForeignKey(
                        name: "id_relatorio",
                        column: x => x.id_relatoro,
                        principalTable: "relatorio",
                        principalColumn: "id_relatorio");
                });

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
                name: "IX_avaliacao_preco_application_user_id",
                table: "avaliacao_preco",
                column: "application_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_preco_id_preco",
                table: "avaliacao_preco",
                column: "id_preco");

            migrationBuilder.CreateIndex(
                name: "IX_categoria_produto_id_produto",
                table: "categoria_produto",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_application_user_id",
                table: "mensagem",
                column: "application_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_preco_application_user_id",
                table: "preco",
                column: "application_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_preco_id_loja",
                table: "preco",
                column: "id_loja");

            migrationBuilder.CreateIndex(
                name: "IX_preco_id_produto",
                table: "preco",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_produto_application_user_id",
                table: "produto",
                column: "application_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_produto_id_categoria",
                table: "produto",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_relatorio_id_loja",
                table: "relatorio",
                column: "id_loja");

            migrationBuilder.CreateIndex(
                name: "IX_relatorio_id_produto",
                table: "relatorio",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_relatorio_loja_id_loja",
                table: "relatorio_loja",
                column: "id_loja");

            migrationBuilder.CreateIndex(
                name: "IX_relatorio_produto_id_relatorio",
                table: "relatorio_produto",
                column: "id_relatorio");
        }*/
        

        /*// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avaliacao_preco");

            migrationBuilder.DropTable(
                name: "categoria_produto");

            migrationBuilder.DropTable(
                name: "mensagem");

            migrationBuilder.DropTable(
                name: "relatorio_loja");

            migrationBuilder.DropTable(
                name: "relatorio_produto");

            migrationBuilder.DropTable(
                name: "preco");

            migrationBuilder.DropTable(
                name: "relatorio");

            migrationBuilder.DropTable(
                name: "loja");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "categoria");
        }*/
    }
}

