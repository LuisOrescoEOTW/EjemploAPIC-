using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planos.Migrations
{
    public partial class PlanosDeCanios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DobEstadoPlano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DobEstadoPlano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DobSemi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DobSemi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DobUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DobUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DobPlano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemielaboradoId = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaCambioEstado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioBajaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DobPlano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DobPlano_DobEstadoPlano_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "DobEstadoPlano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DobPlano_DobSemi_SemielaboradoId",
                        column: x => x.SemielaboradoId,
                        principalTable: "DobSemi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DobPlano_DobUsuario_UsuarioBajaId",
                        column: x => x.UsuarioBajaId,
                        principalTable: "DobUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DobPlano_DobUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "DobUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DobImpresionesPlanos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaImpresion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioBajaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DobImpresionesPlanos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DobImpresionesPlanos_DobPlano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "DobPlano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DobImpresionesPlanos_DobUsuario_UsuarioBajaId",
                        column: x => x.UsuarioBajaId,
                        principalTable: "DobUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DobImpresionesPlanos_DobUsuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "DobUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DobImpresionesPlanos_PlanoId",
                table: "DobImpresionesPlanos",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_DobImpresionesPlanos_UsuarioBajaId",
                table: "DobImpresionesPlanos",
                column: "UsuarioBajaId");

            migrationBuilder.CreateIndex(
                name: "IX_DobImpresionesPlanos_UsuarioId",
                table: "DobImpresionesPlanos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DobPlano_EstadoId",
                table: "DobPlano",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_DobPlano_SemielaboradoId",
                table: "DobPlano",
                column: "SemielaboradoId");

            migrationBuilder.CreateIndex(
                name: "IX_DobPlano_UsuarioBajaId",
                table: "DobPlano",
                column: "UsuarioBajaId");

            migrationBuilder.CreateIndex(
                name: "IX_DobPlano_UsuarioId",
                table: "DobPlano",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DobImpresionesPlanos");

            migrationBuilder.DropTable(
                name: "DobPlano");

            migrationBuilder.DropTable(
                name: "DobEstadoPlano");

            migrationBuilder.DropTable(
                name: "DobSemi");

            migrationBuilder.DropTable(
                name: "DobUsuario");
        }
    }
}
