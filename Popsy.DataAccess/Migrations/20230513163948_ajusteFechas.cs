using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popsy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ajusteFechas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_creacion",
                schema: "SIPOP",
                table: "tipoinventario");

            migrationBuilder.DropColumn(
                name: "fecha_modificacion",
                schema: "SIPOP",
                table: "tipoinventario");

            migrationBuilder.DropColumn(
                name: "fecha_creacion",
                schema: "SIPOP",
                table: "inventarios");

            migrationBuilder.DropColumn(
                name: "fecha_modificacion",
                schema: "SIPOP",
                table: "inventarios");

            migrationBuilder.DropColumn(
                name: "fecha_creacion",
                schema: "SIPOP",
                table: "inventariodetalle");

            migrationBuilder.DropColumn(
                name: "fecha_modificacion",
                schema: "SIPOP",
                table: "inventariodetalle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_creacion",
                schema: "SIPOP",
                table: "tipoinventario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_modificacion",
                schema: "SIPOP",
                table: "tipoinventario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_creacion",
                schema: "SIPOP",
                table: "inventarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_modificacion",
                schema: "SIPOP",
                table: "inventarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_creacion",
                schema: "SIPOP",
                table: "inventariodetalle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_modificacion",
                schema: "SIPOP",
                table: "inventariodetalle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
