using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popsy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InventarioConteo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "requiere_conteo",
                table: "inventariodetalle2",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "inventario_conteo",
                columns: table => new
                {
                    inventario_conteo_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    cantidad = table.Column<double>(type: "float", nullable: false),
                    inicial = table.Column<bool>(type: "bit", nullable: false),
                    final = table.Column<bool>(type: "bit", nullable: false),
                    inventario_detalle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario_conteo", x => x.inventario_conteo_id);
                    table.ForeignKey(
                        name: "FK_inventario_conteo_inventariodetalle2_inventario_detalle_id",
                        column: x => x.inventario_detalle_id,
                        principalTable: "inventariodetalle2",
                        principalColumn: "inventario_detalle_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventario_conteo_inventario_detalle_id",
                table: "inventario_conteo",
                column: "inventario_detalle_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventario_conteo");

            migrationBuilder.DropColumn(
                name: "requiere_conteo",
                table: "inventariodetalle2");
        }
    }
}
