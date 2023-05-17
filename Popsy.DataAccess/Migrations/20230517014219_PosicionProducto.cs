using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popsy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PosicionProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "posicion_producto",
                table: "ordenes_compras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "posicion_producto",
                table: "ordenes_compras");
        }
    }
}
