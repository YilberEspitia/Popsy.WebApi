using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popsy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SIPOP");

            migrationBuilder.CreateTable(
                name: "bodegas",
                columns: table => new
                {
                    bodega_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_bodega = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    codigo_sap = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bodegas", x => x.bodega_id);
                });

            migrationBuilder.CreateTable(
                name: "centros_logisticos",
                columns: table => new
                {
                    centros_logisticos_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo_cedi_sap = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombre_cedi_sap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centros_logisticos", x => x.centros_logisticos_id);
                });

            migrationBuilder.CreateTable(
                name: "estados_pedidos",
                columns: table => new
                {
                    estado_pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados_pedidos", x => x.estado_pedido_id);
                });

            migrationBuilder.CreateTable(
                name: "factores_conversion",
                columns: table => new
                {
                    factor_conversion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    unidad_base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contador = table.Column<int>(type: "int", nullable: false),
                    unidad_medida_alter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo_fc_sap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factores_conversion", x => x.factor_conversion_id);
                });

            migrationBuilder.CreateTable(
                name: "organizaciones_ventas",
                columns: table => new
                {
                    organizacion_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizaciones_ventas", x => x.organizacion_venta_id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    presentacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    minima_unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    habilitado_inventario = table.Column<int>(type: "int", nullable: true),
                    habilitado_pedido = table.Column<int>(type: "int", nullable: true),
                    categoria_producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    denominador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria_Producto1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria_Producto2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria_producto3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoria_producto4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.producto_id);
                });

            migrationBuilder.CreateTable(
                name: "productos_proveedores",
                columns: table => new
                {
                    productos_proveedores_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo_producto_sap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo_proveedor_sap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_proveedores", x => x.productos_proveedores_id);
                });

            migrationBuilder.CreateTable(
                name: "proveedores_recepcion",
                columns: table => new
                {
                    proveedor_recepcion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codigo_sap_proveedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores_recepcion", x => x.proveedor_recepcion_id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_pedido",
                columns: table => new
                {
                    tipo_pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_pedido", x => x.tipo_pedido_id);
                });

            migrationBuilder.CreateTable(
                name: "tipoinventario",
                schema: "SIPOP",
                columns: table => new
                {
                    tipo_inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_tipo_inventario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    abreviatura_inventario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoinventario", x => x.tipo_inventario_id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_pedidos_compras_traslados",
                columns: table => new
                {
                    tipo_pedido_compra_traslado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo_tipo_pedido_sap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nombre_tipo_pedido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    documento_tipo_pedido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_pedidos_compras_traslados", x => x.tipo_pedido_compra_traslado_id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_transacciones",
                columns: table => new
                {
                    tipo_transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_transacciones", x => x.tipo_transaccion_id);
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

            migrationBuilder.CreateTable(
                name: "distritos",
                columns: table => new
                {
                    distrito_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    organizacion_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distritos", x => x.distrito_id);
                    table.ForeignKey(
                        name: "FK_distritos_organizaciones_ventas_organizacion_venta_id",
                        column: x => x.organizacion_venta_id,
                        principalTable: "organizaciones_ventas",
                        principalColumn: "organizacion_venta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos_factores_conversion",
                columns: table => new
                {
                    producto_factor_conversion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    factor_conversion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_factores_conversion", x => x.producto_factor_conversion_id);
                    table.ForeignKey(
                        name: "FK_productos_factores_conversion_factores_conversion_factor_conversion_id",
                        column: x => x.factor_conversion_id,
                        principalTable: "factores_conversion",
                        principalColumn: "factor_conversion_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productos_factores_conversion_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "puntos_ventas",
                columns: table => new
                {
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CENTRO_CONOS = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ALMACEN_CONOS = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DOC_CONOS = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CENTRO_CS = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ALMACEN_CS = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DOC_CS = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CENTRO_CG = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ALMACEN_CG = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DOC_CG = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CENTRO_CGR = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ALMACEN_CGR = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DOC_CGR = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CENTRO_CSR = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ALMACEN_CSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOC_CSR = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CENTRO_UT = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ALMACEN_UT = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DOC_UT = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    distrito_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puntos_ventas", x => x.punto_venta_id);
                    table.ForeignKey(
                        name: "FK_puntos_ventas_distritos_distrito_id",
                        column: x => x.distrito_id,
                        principalTable: "distritos",
                        principalColumn: "distrito_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bodegas_puntos_ventas",
                columns: table => new
                {
                    bodega_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bodegas_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bodegas_puntos_ventas", x => x.bodega_punto_venta_id);
                    table.ForeignKey(
                        name: "FK_bodegas_puntos_ventas_bodegas_bodegas_id",
                        column: x => x.bodegas_id,
                        principalTable: "bodegas",
                        principalColumn: "bodega_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bodegas_puntos_ventas_puntos_ventas_punto_venta_id",
                        column: x => x.punto_venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "determinar_compras_traslados",
                columns: table => new
                {
                    determinar_compra_traslado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    requiere_pedido_compra = table.Column<int>(type: "int", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_Venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_determinar_compras_traslados", x => x.determinar_compra_traslado_id);
                    table.ForeignKey(
                        name: "FK_determinar_compras_traslados_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_determinar_compras_traslados_puntos_ventas_punto_Venta_id",
                        column: x => x.punto_Venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventarios",
                schema: "SIPOP",
                columns: table => new
                {
                    inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo_inventario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_toma_fisica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipo_inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventarios", x => x.inventario_id);
                    table.ForeignKey(
                        name: "FK_inventarios_puntos_ventas_punto_venta_id",
                        column: x => x.punto_venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventarios_tipoinventario_tipo_inventario_id",
                        column: x => x.tipo_inventario_id,
                        principalSchema: "SIPOP",
                        principalTable: "tipoinventario",
                        principalColumn: "tipo_inventario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordenes_compras",
                columns: table => new
                {
                    orden_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orden_compra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_orden_compra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    proveedor_recepcion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes_compras", x => x.orden_compra_id);
                    table.ForeignKey(
                        name: "FK_ordenes_compras_proveedores_recepcion_proveedor_recepcion_id",
                        column: x => x.proveedor_recepcion_id,
                        principalTable: "proveedores_recepcion",
                        principalColumn: "proveedor_recepcion_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordenes_compras_puntos_ventas_punto_venta_id",
                        column: x => x.punto_venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mensajeReciboSap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaMensajeSap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoUnoSap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoDosSap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipo_pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    estado_pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.pedido_id);
                    table.ForeignKey(
                        name: "FK_pedidos_estados_pedidos_estado_pedido_id",
                        column: x => x.estado_pedido_id,
                        principalTable: "estados_pedidos",
                        principalColumn: "estado_pedido_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedidos_puntos_ventas_punto_venta_id",
                        column: x => x.punto_venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedidos_tipo_pedido_tipo_pedido_id",
                        column: x => x.tipo_pedido_id,
                        principalTable: "tipo_pedido",
                        principalColumn: "tipo_pedido_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos_puntos_venta",
                columns: table => new
                {
                    producto_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad_producto_maxima = table.Column<int>(type: "int", nullable: false),
                    stock_actual = table.Column<int>(type: "int", nullable: false),
                    stock_transito = table.Column<int>(type: "int", nullable: false),
                    punto_distribucion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_puntos_venta", x => x.producto_punto_venta_id);
                    table.ForeignKey(
                        name: "FK_productos_puntos_venta_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productos_puntos_venta_puntos_ventas_punto_venta_id",
                        column: x => x.punto_venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tipo_pedidos_por_almacen",
                columns: table => new
                {
                    tipo_pedido_por_almacen_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    codigo_almacen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    centro_logistico_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipo_pedido_compra_traslado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_pedidos_por_almacen", x => x.tipo_pedido_por_almacen_id);
                    table.ForeignKey(
                        name: "FK_tipo_pedidos_por_almacen_centros_logisticos_centro_logistico_id",
                        column: x => x.centro_logistico_id,
                        principalTable: "centros_logisticos",
                        principalColumn: "centros_logisticos_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tipo_pedidos_por_almacen_puntos_ventas_punto_venta_id",
                        column: x => x.punto_venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tipo_pedidos_por_almacen_tipos_pedidos_compras_traslados_tipo_pedido_compra_traslado_id",
                        column: x => x.tipo_pedido_compra_traslado_id,
                        principalTable: "tipos_pedidos_compras_traslados",
                        principalColumn: "tipo_pedido_compra_traslado_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios_puntos_ventas",
                columns: table => new
                {
                    usuario_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios_puntos_ventas", x => x.usuario_punto_venta_id);
                    table.ForeignKey(
                        name: "FK_usuarios_puntos_ventas_puntos_ventas_punto_venta_id",
                        column: x => x.punto_venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventariodetalle",
                schema: "SIPOP",
                columns: table => new
                {
                    inventario_detalle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    minima_unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bodega_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventariodetalle", x => x.inventario_detalle_id);
                    table.ForeignKey(
                        name: "FK_inventariodetalle_bodegas_bodega_id",
                        column: x => x.bodega_id,
                        principalTable: "bodegas",
                        principalColumn: "bodega_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventariodetalle_inventarios_inventario_id",
                        column: x => x.inventario_id,
                        principalSchema: "SIPOP",
                        principalTable: "inventarios",
                        principalColumn: "inventario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle_orden_compra",
                columns: table => new
                {
                    detalle_orden_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad_solicitada = table.Column<int>(type: "int", nullable: false),
                    unidad_presentacion_solicitada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orden_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_orden_compra", x => x.detalle_orden_compra_id);
                    table.ForeignKey(
                        name: "FK_detalle_orden_compra_ordenes_compras_orden_compra_id",
                        column: x => x.orden_compra_id,
                        principalTable: "ordenes_compras",
                        principalColumn: "orden_compra_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_orden_compra_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
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
                    justificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_pedidos", x => x.producto_pedido_id);
                    table.ForeignKey(
                        name: "FK_productos_pedidos_pedidos_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "pedidos",
                        principalColumn: "pedido_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productos_pedidos_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    es_error = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.transaccion_id);
                    table.ForeignKey(
                        name: "FK_Transacciones_pedidos_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "pedidos",
                        principalColumn: "pedido_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transacciones_tipos_transacciones_tipo_transaccion_id",
                        column: x => x.tipo_transaccion_id,
                        principalTable: "tipos_transacciones",
                        principalColumn: "tipo_transaccion_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recepciones_compras",
                columns: table => new
                {
                    recepcion_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad_recibida = table.Column<int>(type: "int", nullable: false),
                    numero_factura = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Unidad_presentacion_recibida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    detalle_orden_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recepciones_compras", x => x.recepcion_compra_id);
                    table.ForeignKey(
                        name: "FK_recepciones_compras_detalle_orden_compra_detalle_orden_compra_id",
                        column: x => x.detalle_orden_compra_id,
                        principalTable: "detalle_orden_compra",
                        principalColumn: "detalle_orden_compra_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "errores_transacciones",
                columns: table => new
                {
                    error_transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    datos_enviados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datos_recibidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_errores_transacciones", x => x.error_transaccion_id);
                    table.ForeignKey(
                        name: "FK_errores_transacciones_Transacciones_transaccion_id",
                        column: x => x.transaccion_id,
                        principalTable: "Transacciones",
                        principalColumn: "transaccion_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bodegas_puntos_ventas_bodegas_id",
                table: "bodegas_puntos_ventas",
                column: "bodegas_id");

            migrationBuilder.CreateIndex(
                name: "IX_bodegas_puntos_ventas_punto_venta_id",
                table: "bodegas_puntos_ventas",
                column: "punto_venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_compra_orden_compra_id",
                table: "detalle_orden_compra",
                column: "orden_compra_id");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_compra_producto_id",
                table: "detalle_orden_compra",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_determinar_compras_traslados_producto_id",
                table: "determinar_compras_traslados",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_determinar_compras_traslados_punto_Venta_id",
                table: "determinar_compras_traslados",
                column: "punto_Venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_distritos_organizacion_venta_id",
                table: "distritos",
                column: "organizacion_venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_errores_transacciones_transaccion_id",
                table: "errores_transacciones",
                column: "transaccion_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventariodetalle_bodega_id",
                schema: "SIPOP",
                table: "inventariodetalle",
                column: "bodega_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventariodetalle_inventario_id",
                schema: "SIPOP",
                table: "inventariodetalle",
                column: "inventario_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventarios_punto_venta_id",
                schema: "SIPOP",
                table: "inventarios",
                column: "punto_venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventarios_tipo_inventario_id",
                schema: "SIPOP",
                table: "inventarios",
                column: "tipo_inventario_id");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_compras_proveedor_recepcion_id",
                table: "ordenes_compras",
                column: "proveedor_recepcion_id");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_compras_punto_venta_id",
                table: "ordenes_compras",
                column: "punto_venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_estado_pedido_id",
                table: "pedidos",
                column: "estado_pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_punto_venta_id",
                table: "pedidos",
                column: "punto_venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_tipo_pedido_id",
                table: "pedidos",
                column: "tipo_pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_productos_factores_conversion_factor_conversion_id",
                table: "productos_factores_conversion",
                column: "factor_conversion_id");

            migrationBuilder.CreateIndex(
                name: "IX_productos_factores_conversion_producto_id",
                table: "productos_factores_conversion",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_productos_pedidos_pedido_id",
                table: "productos_pedidos",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_productos_pedidos_producto_id",
                table: "productos_pedidos",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_productos_puntos_venta_producto_id",
                table: "productos_puntos_venta",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_productos_puntos_venta_punto_venta_id",
                table: "productos_puntos_venta",
                column: "punto_venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_puntos_ventas_distrito_id",
                table: "puntos_ventas",
                column: "distrito_id");

            migrationBuilder.CreateIndex(
                name: "IX_recepciones_compras_detalle_orden_compra_id",
                table: "recepciones_compras",
                column: "detalle_orden_compra_id");

            migrationBuilder.CreateIndex(
                name: "IX_tipo_pedidos_por_almacen_centro_logistico_id",
                table: "tipo_pedidos_por_almacen",
                column: "centro_logistico_id");

            migrationBuilder.CreateIndex(
                name: "IX_tipo_pedidos_por_almacen_punto_venta_id",
                table: "tipo_pedidos_por_almacen",
                column: "punto_venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_tipo_pedidos_por_almacen_tipo_pedido_compra_traslado_id",
                table: "tipo_pedidos_por_almacen",
                column: "tipo_pedido_compra_traslado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_pedido_id",
                table: "Transacciones",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_tipo_transaccion_id",
                table: "Transacciones",
                column: "tipo_transaccion_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_puntos_ventas_punto_venta_id",
                table: "usuarios_puntos_ventas",
                column: "punto_venta_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bodegas_puntos_ventas");

            migrationBuilder.DropTable(
                name: "determinar_compras_traslados");

            migrationBuilder.DropTable(
                name: "errores_transacciones");

            migrationBuilder.DropTable(
                name: "inventariodetalle",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "productos_factores_conversion");

            migrationBuilder.DropTable(
                name: "productos_pedidos");

            migrationBuilder.DropTable(
                name: "productos_proveedores");

            migrationBuilder.DropTable(
                name: "productos_puntos_venta");

            migrationBuilder.DropTable(
                name: "recepciones_compras");

            migrationBuilder.DropTable(
                name: "tipo_pedidos_por_almacen");

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

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "bodegas");

            migrationBuilder.DropTable(
                name: "inventarios",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "factores_conversion");

            migrationBuilder.DropTable(
                name: "detalle_orden_compra");

            migrationBuilder.DropTable(
                name: "centros_logisticos");

            migrationBuilder.DropTable(
                name: "tipos_pedidos_compras_traslados");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "tipos_transacciones");

            migrationBuilder.DropTable(
                name: "tipoinventario",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "ordenes_compras");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "estados_pedidos");

            migrationBuilder.DropTable(
                name: "tipo_pedido");

            migrationBuilder.DropTable(
                name: "proveedores_recepcion");

            migrationBuilder.DropTable(
                name: "puntos_ventas");

            migrationBuilder.DropTable(
                name: "distritos");

            migrationBuilder.DropTable(
                name: "organizaciones_ventas");
        }
    }
}
