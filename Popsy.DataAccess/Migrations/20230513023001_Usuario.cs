using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popsy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.usuario_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_puntos_ventas_usuario_id",
                table: "usuarios_puntos_ventas",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_usuario_id",
                table: "pedidos",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventarios_usuario_id",
                schema: "SIPOP",
                table: "inventarios",
                column: "usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventarios_usuarios_usuario_id",
                schema: "SIPOP",
                table: "inventarios",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "usuario_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_usuarios_usuario_id",
                table: "pedidos",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "usuario_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_puntos_ventas_usuarios_usuario_id",
                table: "usuarios_puntos_ventas",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "usuario_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventarios_usuarios_usuario_id",
                schema: "SIPOP",
                table: "inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_usuarios_usuario_id",
                table: "pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_puntos_ventas_usuarios_usuario_id",
                table: "usuarios_puntos_ventas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_puntos_ventas_usuario_id",
                table: "usuarios_puntos_ventas");

            migrationBuilder.DropIndex(
                name: "IX_pedidos_usuario_id",
                table: "pedidos");

            migrationBuilder.DropIndex(
                name: "IX_inventarios_usuario_id",
                schema: "SIPOP",
                table: "inventarios");
        }
    }
}
