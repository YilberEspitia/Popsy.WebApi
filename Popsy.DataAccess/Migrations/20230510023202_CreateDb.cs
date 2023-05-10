using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popsy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SIPOP");

            migrationBuilder.CreateTable(
                name: "determinar_compras_traslados",
                columns: table => new
                {
                    determinar_compra_traslado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_Venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    requiere_pedido_compra = table.Column<int>(type: "int", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_determinar_compras_traslados", x => x.determinar_compra_traslado_id);
                });

            migrationBuilder.CreateTable(
                name: "inventariodetalle",
                schema: "SIPOP",
                columns: table => new
                {
                    inventario_detalle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bodega_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    minima_unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventariodetalle", x => x.inventario_detalle_id);
                });

            migrationBuilder.CreateTable(
                name: "inventarios",
                schema: "SIPOP",
                columns: table => new
                {
                    inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipo_inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo_inventario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_toma_fisica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventarios", x => x.inventario_id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria_Producto2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria_Producto1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.producto_id);
                });

            migrationBuilder.CreateTable(
                name: "productos_pedidos",
                columns: table => new
                {
                    producto_pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    stock_actual = table.Column<int>(type: "int", nullable: false),
                    stock_transito = table.Column<int>(type: "int", nullable: false),
                    null_line = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    justificacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_pedidos", x => x.producto_pedido_id);
                });

            migrationBuilder.CreateTable(
                name: "productos_puntos_venta",
                columns: table => new
                {
                    producto_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad_producto_maxima = table.Column<int>(type: "int", nullable: false),
                    stock_actual = table.Column<int>(type: "int", nullable: false),
                    stock_transito = table.Column<int>(type: "int", nullable: false),
                    punto_distribucion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_puntos_venta", x => x.producto_punto_venta_id);
                });

            migrationBuilder.CreateTable(
                name: "puntos_ventas",
                columns: table => new
                {
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puntos_ventas", x => x.punto_venta_id);
                });

            migrationBuilder.CreateTable(
                name: "tipoinventario",
                schema: "SIPOP",
                columns: table => new
                {
                    tipo_inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_tipo_inventario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    abreviatura_inventario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoinventario", x => x.tipo_inventario_id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios_puntos_ventas",
                columns: table => new
                {
                    usuario_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios_puntos_ventas", x => x.usuario_punto_venta_id);
                });

            migrationBuilder.CreateTable(
                name: "vistacategoriasproductos",
                schema: "SIPOP",
                columns: table => new
                {
                    categoria_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    categoria_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistacategoriasproductos", x => x.categoria_id);
                });

            migrationBuilder.CreateTable(
                name: "vistamonitorInventario",
                schema: "SIPOP",
                columns: table => new
                {
                    inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo_inventario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_tipo_inventario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_toma_fisica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuario_inventario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistamonitorInventario", x => x.inventario_id);
                });

            migrationBuilder.CreateTable(
                name: "vistapedidospuntoventa",
                schema: "SIPOP",
                columns: table => new
                {
                    pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo_punto_venta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    centro_cs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    almacen_cs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    doc_cs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    organizacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistapedidospuntoventa", x => x.pedido_id);
                });

            migrationBuilder.CreateTable(
                name: "vistaproductofactoresconversion",
                schema: "SIPOP",
                columns: table => new
                {
                    producto_factor_conversion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    factor_conversion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    unidad_base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contador = table.Column<int>(type: "int", nullable: false),
                    unidad_medida_alter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistaproductofactoresconversion", x => x.producto_factor_conversion_id);
                });

            migrationBuilder.CreateTable(
                name: "vistaproductosconstock",
                schema: "SIPOP",
                columns: table => new
                {
                    producto_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_punto_venta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad_producto_maxima = table.Column<int>(type: "int", nullable: false),
                    stock_actual = table.Column<int>(type: "int", nullable: false),
                    presentacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    minima_unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria_producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    factor_conversion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistaproductosconstock", x => x.producto_punto_venta_id);
                });

            migrationBuilder.CreateTable(
                name: "vistaproductosparainventario",
                schema: "SIPOP",
                columns: table => new
                {
                    producto_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_punto_venta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad_producto_maxima = table.Column<int>(type: "int", nullable: false),
                    stock_actual = table.Column<int>(type: "int", nullable: false),
                    presentacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    minima_unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria_producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    factor_conversion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre_producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contador = table.Column<int>(type: "int", nullable: false),
                    unidad_base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unidad_medida_alter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistaproductosparainventario", x => x.producto_punto_venta_id);
                });

            migrationBuilder.CreateTable(
                name: "vistapuntosventabodegas",
                schema: "SIPOP",
                columns: table => new
                {
                    bodegas_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bodega_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_punto_venta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo_punto_venta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre_bodega = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistapuntosventabodegas", x => x.bodegas_punto_venta_id);
                });

            migrationBuilder.CreateTable(
                name: "vistaresumeninventario",
                schema: "SIPOP",
                columns: table => new
                {
                    inventario_detalle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre_punto_venta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre_producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vistaresumeninventario", x => x.inventario_detalle_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "determinar_compras_traslados");

            migrationBuilder.DropTable(
                name: "inventariodetalle",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "inventarios",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "productos_pedidos");

            migrationBuilder.DropTable(
                name: "productos_puntos_venta");

            migrationBuilder.DropTable(
                name: "puntos_ventas");

            migrationBuilder.DropTable(
                name: "tipoinventario",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "usuarios_puntos_ventas");

            migrationBuilder.DropTable(
                name: "vistacategoriasproductos",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "vistamonitorInventario",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "vistapedidospuntoventa",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "vistaproductofactoresconversion",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "vistaproductosconstock",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "vistaproductosparainventario",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "vistapuntosventabodegas",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "vistaresumeninventario",
                schema: "SIPOP");
        }
    }
}
