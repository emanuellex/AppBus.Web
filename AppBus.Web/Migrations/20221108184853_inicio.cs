using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppBus.Web.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_TIPO_ONIBUS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_TIPO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_TIPO_ONIBUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DS_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DS_SENHA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DS_TELEFONE = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    NR_CPF = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DT_DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ONIBUS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NR_NUMERO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NR_LINHA = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    NM_REGIAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VL_Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DC_STATUS = table.Column<int>(type: "int", nullable: false),
                    FL_ACESSIVEL = table.Column<bool>(type: "bit", nullable: false),
                    TipoOnibusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ONIBUS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ONIBUS_Tbl_TIPO_ONIBUS_TipoOnibusId",
                        column: x => x.TipoOnibusId,
                        principalTable: "Tbl_TIPO_ONIBUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_BILHETE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NR_BILHETE = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    NM_TITULAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VL_VALOR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DS_TIPO_BILHETE = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_BILHETE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_BILHETE_Tbl_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Tbl_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CARTAO_CREDITO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NR_Cartao = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    NM_TITULAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NR_CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NR_CVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DT_VALIDADE = table.Column<DateTime>(type: "datetime2", maxLength: 3, nullable: false),
                    DS_Bandeira = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CARTAO_CREDITO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_CARTAO_CREDITO_Tbl_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Tbl_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_AVALIACAO",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    OnibusId = table.Column<int>(type: "int", nullable: false),
                    DS_NOTA = table.Column<int>(type: "int", nullable: false),
                    DC_COMENTARIO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AVALIACAO", x => new { x.UsuarioId, x.OnibusId });
                    table.ForeignKey(
                        name: "FK_Tbl_AVALIACAO_Tbl_ONIBUS_OnibusId",
                        column: x => x.OnibusId,
                        principalTable: "Tbl_ONIBUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_AVALIACAO_Tbl_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Tbl_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AVALIACAO_OnibusId",
                table: "Tbl_AVALIACAO",
                column: "OnibusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_BILHETE_UsuarioId",
                table: "Tbl_BILHETE",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CARTAO_CREDITO_UsuarioId",
                table: "Tbl_CARTAO_CREDITO",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ONIBUS_TipoOnibusId",
                table: "Tbl_ONIBUS",
                column: "TipoOnibusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_AVALIACAO");

            migrationBuilder.DropTable(
                name: "Tbl_BILHETE");

            migrationBuilder.DropTable(
                name: "Tbl_CARTAO_CREDITO");

            migrationBuilder.DropTable(
                name: "Tbl_ONIBUS");

            migrationBuilder.DropTable(
                name: "Tbl_USUARIO");

            migrationBuilder.DropTable(
                name: "Tbl_TIPO_ONIBUS");
        }
    }
}
