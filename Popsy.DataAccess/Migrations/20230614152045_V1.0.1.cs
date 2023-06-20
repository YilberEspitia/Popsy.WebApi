using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Popsy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class V101 : Migration
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
                    bodega_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    nombre_bodega = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    codigo_sap = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bodegas", x => x.bodega_id);
                });

            migrationBuilder.CreateTable(
                name: "centros_logisticos",
                columns: table => new
                {
                    centros_logisticos_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    codigo_cedi_sap = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombre_cedi_sap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centros_logisticos", x => x.centros_logisticos_id);
                });

            migrationBuilder.CreateTable(
                name: "estados_pedidos",
                columns: table => new
                {
                    estado_pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados_pedidos", x => x.estado_pedido_id);
                });

            migrationBuilder.CreateTable(
                name: "factores_conversion",
                columns: table => new
                {
                    factor_conversion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    unidad_base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contador = table.Column<int>(type: "int", nullable: false),
                    unidad_medida_alter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo_fc_sap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factores_conversion", x => x.factor_conversion_id);
                });

            migrationBuilder.CreateTable(
                name: "organizaciones_ventas",
                columns: table => new
                {
                    organizacion_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizaciones_ventas", x => x.organizacion_venta_id);
                });

            migrationBuilder.CreateTable(
                name: "permisos",
                columns: table => new
                {
                    permiso_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisos", x => x.permiso_id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
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
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.producto_id);
                });

            migrationBuilder.CreateTable(
                name: "productos_proveedores",
                columns: table => new
                {
                    productos_proveedores_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    codigo_producto_sap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo_proveedor_sap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_proveedores", x => x.productos_proveedores_id);
                });

            migrationBuilder.CreateTable(
                name: "proveedores_recepcion",
                columns: table => new
                {
                    proveedor_recepcion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codigo_sap_proveedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores_recepcion", x => x.proveedor_recepcion_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    rol_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.rol_id);
                });

            migrationBuilder.CreateTable(
                name: "SeguimientoPDVTracker",
                columns: table => new
                {
                    COMPAÑIA = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PdV = table.Column<string>(type: "nvarchar(45)", nullable: true),
                    ULTIMAACTUALIZACIONDELSISTEMA = table.Column<DateTime>(name: "ULTIMA ACTUALIZACION DEL SISTEMA", type: "datetime2", nullable: false),
                    T_TRACKER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tipo_pedido",
                columns: table => new
                {
                    tipo_pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    tipo_inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    nombre_tipo_inventario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    abreviatura_inventario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoinventario", x => x.tipo_inventario_id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_pedidos_compras_traslados",
                columns: table => new
                {
                    tipo_pedido_compra_traslado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    codigo_tipo_pedido_sap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nombre_tipo_pedido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    documento_tipo_pedido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_pedidos_compras_traslados", x => x.tipo_pedido_compra_traslado_id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_transacciones",
                columns: table => new
                {
                    tipo_transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_transacciones", x => x.tipo_transaccion_id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.usuario_id);
                });

            migrationBuilder.CreateTable(
                name: "distritos",
                columns: table => new
                {
                    distrito_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    organizacion_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    producto_factor_conversion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    factor_conversion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                name: "unidades_inventarios_dos",
                columns: table => new
                {
                    unidad_inventario_dos_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    unidad_consumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unidad_despacho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unidad_conteo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidades_inventarios_dos", x => x.unidad_inventario_dos_id);
                    table.ForeignKey(
                        name: "FK_unidades_inventarios_dos_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles_permisos",
                columns: table => new
                {
                    rol_permiso_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rol_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    permiso_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_permisos", x => x.rol_permiso_id);
                    table.ForeignKey(
                        name: "FK_roles_permisos_permisos_permiso_id",
                        column: x => x.permiso_id,
                        principalTable: "permisos",
                        principalColumn: "permiso_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roles_permisos_roles_rol_id",
                        column: x => x.rol_id,
                        principalTable: "roles",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historial_usuarios",
                columns: table => new
                {
                    historial_usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    autor_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuario_modificado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial_usuarios", x => x.historial_usuario_id);
                    table.ForeignKey(
                        name: "FK_historial_usuarios_usuarios_autor_id",
                        column: x => x.autor_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios_roles",
                columns: table => new
                {
                    usuario_rol_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rol_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios_roles", x => x.usuario_rol_id);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_roles_rol_id",
                        column: x => x.rol_id,
                        principalTable: "roles",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "puntos_ventas",
                columns: table => new
                {
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
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
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    bodega_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    bodegas_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    determinar_compra_traslado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    requiere_pedido_compra = table.Column<int>(type: "int", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_Venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    codigo_inventario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_toma_fisica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipo_inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_inventarios_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventarios2",
                columns: table => new
                {
                    inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    codigo_inventario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<short>(type: "smallint", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipo_inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventarios2", x => x.inventario_id);
                    table.ForeignKey(
                        name: "FK_inventarios2_puntos_ventas_punto_venta_id",
                        column: x => x.punto_venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventarios2_tipoinventario_tipo_inventario_id",
                        column: x => x.tipo_inventario_id,
                        principalSchema: "SIPOP",
                        principalTable: "tipoinventario",
                        principalColumn: "tipo_inventario_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventarios2_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordenes_compras",
                columns: table => new
                {
                    orden_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    orden_compra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_orden_compra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    recibida = table.Column<bool>(type: "bit", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    proveedor_recepcion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mensajeReciboSap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaMensajeSap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoUnoSap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoDosSap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<short>(type: "smallint", nullable: false),
                    xml_sap = table.Column<byte[]>(type: "binary(7000)", nullable: true),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipo_pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    estado_pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    table.ForeignKey(
                        name: "FK_pedidos_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos_puntos_venta",
                columns: table => new
                {
                    producto_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    cantidad_producto_maxima = table.Column<int>(type: "int", nullable: false),
                    stock_actual = table.Column<int>(type: "int", nullable: false),
                    stock_transito = table.Column<int>(type: "int", nullable: false),
                    punto_distribucion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                name: "stock_fecha",
                columns: table => new
                {
                    stock_fecha_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_fecha", x => x.stock_fecha_id);
                    table.ForeignKey(
                        name: "FK_stock_fecha_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stock_fecha_puntos_ventas_punto_venta_id",
                        column: x => x.punto_venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stock_teorico_inventarios_dos",
                columns: table => new
                {
                    stock_teorico_inventarios_dos_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    stock_teorico = table.Column<double>(type: "float", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_teorico_inventarios_dos", x => x.stock_teorico_inventarios_dos_id);
                    table.ForeignKey(
                        name: "FK_stock_teorico_inventarios_dos_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stock_teorico_inventarios_dos_puntos_ventas_punto_venta_id",
                        column: x => x.punto_venta_id,
                        principalTable: "puntos_ventas",
                        principalColumn: "punto_venta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tipo_pedidos_por_almacen",
                columns: table => new
                {
                    tipo_pedido_por_almacen_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    codigo_almacen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    centro_logistico_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipo_pedido_compra_traslado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    usuario_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                    table.ForeignKey(
                        name: "FK_usuarios_puntos_ventas_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventariodetalle",
                schema: "SIPOP",
                columns: table => new
                {
                    inventario_detalle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    producto_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    minima_unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<double>(type: "float", nullable: false),
                    inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bodega_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "inventariodetalle2",
                columns: table => new
                {
                    inventario_detalle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    producto_punto_venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<double>(type: "float", nullable: false),
                    unidad_consumo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidad_consumo_total = table.Column<double>(type: "float", nullable: true),
                    unidad_despacho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidad_despacho_total = table.Column<double>(type: "float", nullable: true),
                    unidad_conteo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidad_conteo_total = table.Column<double>(type: "float", nullable: true),
                    inventario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bodega_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventariodetalle2", x => x.inventario_detalle_id);
                    table.ForeignKey(
                        name: "FK_inventariodetalle2_bodegas_bodega_id",
                        column: x => x.bodega_id,
                        principalTable: "bodegas",
                        principalColumn: "bodega_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventariodetalle2_inventarios2_inventario_id",
                        column: x => x.inventario_id,
                        principalTable: "inventarios2",
                        principalColumn: "inventario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle_orden_compra",
                columns: table => new
                {
                    detalle_orden_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    cantidad_solicitada = table.Column<int>(type: "int", nullable: false),
                    unidad_presentacion_solicitada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    posicion_producto = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orden_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                name: "recepciones_compras",
                columns: table => new
                {
                    recepcion_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    numero_factura = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    constante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo_recepcion_compra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<short>(type: "smallint", nullable: false),
                    orden_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recepciones_compras", x => x.recepcion_compra_id);
                    table.ForeignKey(
                        name: "FK_recepciones_compras_ordenes_compras_orden_compra_id",
                        column: x => x.orden_compra_id,
                        principalTable: "ordenes_compras",
                        principalColumn: "orden_compra_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos_pedidos",
                columns: table => new
                {
                    producto_pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    stock_actual = table.Column<int>(type: "int", nullable: false),
                    stock_transito = table.Column<int>(type: "int", nullable: false),
                    null_line = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    justificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                name: "respuestas_pedidos_sap",
                columns: table => new
                {
                    respuesta_pedido_sap_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    log_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    log_msg_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    message_v1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message_v2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    message_v3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    message_v4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_respuestas_pedidos_sap", x => x.respuesta_pedido_sap_id);
                    table.ForeignKey(
                        name: "FK_respuestas_pedidos_sap_pedidos_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "pedidos",
                        principalColumn: "pedido_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    es_error = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pedido_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                name: "historial_envio_recepciones_compras",
                columns: table => new
                {
                    historial_envio_recepciones_compras_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    XML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recepcion_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial_envio_recepciones_compras", x => x.historial_envio_recepciones_compras_id);
                    table.ForeignKey(
                        name: "FK_historial_envio_recepciones_compras_recepciones_compras_recepcion_compra_id",
                        column: x => x.recepcion_compra_id,
                        principalTable: "recepciones_compras",
                        principalColumn: "recepcion_compra_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recepciones_compras_detalle",
                columns: table => new
                {
                    recepcion_compra_detalle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    cantidad_recibida = table.Column<int>(type: "int", nullable: false),
                    unidad_presentacion_recibida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    recepcion_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recepciones_compras_detalle", x => x.recepcion_compra_detalle_id);
                    table.ForeignKey(
                        name: "FK_recepciones_compras_detalle_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recepciones_compras_detalle_recepciones_compras_recepcion_compra_id",
                        column: x => x.recepcion_compra_id,
                        principalTable: "recepciones_compras",
                        principalColumn: "recepcion_compra_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recepciones_compras_respuesta",
                columns: table => new
                {
                    recepcion_compra_respuesta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogMsgNo = table.Column<int>(type: "int", nullable: true),
                    MessageV1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageV2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageV3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageV4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Row = table.Column<int>(type: "int", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    System = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    recepcion_compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recepciones_compras_respuesta", x => x.recepcion_compra_respuesta_id);
                    table.ForeignKey(
                        name: "FK_recepciones_compras_respuesta_recepciones_compras_recepcion_compra_id",
                        column: x => x.recepcion_compra_id,
                        principalTable: "recepciones_compras",
                        principalColumn: "recepcion_compra_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "errores_transacciones",
                columns: table => new
                {
                    error_transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    datos_enviados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datos_recibidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transaccion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
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
                name: "IX_historial_envio_recepciones_compras_recepcion_compra_id",
                table: "historial_envio_recepciones_compras",
                column: "recepcion_compra_id");

            migrationBuilder.CreateIndex(
                name: "IX_historial_usuarios_autor_id",
                table: "historial_usuarios",
                column: "autor_id");

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
                name: "IX_inventariodetalle2_bodega_id",
                table: "inventariodetalle2",
                column: "bodega_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventariodetalle2_inventario_id",
                table: "inventariodetalle2",
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
                name: "IX_inventarios_usuario_id",
                schema: "SIPOP",
                table: "inventarios",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventarios2_punto_venta_id",
                table: "inventarios2",
                column: "punto_venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventarios2_tipo_inventario_id",
                table: "inventarios2",
                column: "tipo_inventario_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventarios2_usuario_id",
                table: "inventarios2",
                column: "usuario_id");

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
                name: "IX_pedidos_usuario_id",
                table: "pedidos",
                column: "usuario_id");

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
                name: "IX_recepciones_compras_orden_compra_id",
                table: "recepciones_compras",
                column: "orden_compra_id");

            migrationBuilder.CreateIndex(
                name: "IX_recepciones_compras_detalle_producto_id",
                table: "recepciones_compras_detalle",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_recepciones_compras_detalle_recepcion_compra_id",
                table: "recepciones_compras_detalle",
                column: "recepcion_compra_id");

            migrationBuilder.CreateIndex(
                name: "IX_recepciones_compras_respuesta_recepcion_compra_id",
                table: "recepciones_compras_respuesta",
                column: "recepcion_compra_id");

            migrationBuilder.CreateIndex(
                name: "IX_respuestas_pedidos_sap_pedido_id",
                table: "respuestas_pedidos_sap",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_permisos_permiso_id",
                table: "roles_permisos",
                column: "permiso_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_permisos_rol_id",
                table: "roles_permisos",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_stock_fecha_producto_id",
                table: "stock_fecha",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_stock_fecha_punto_venta_id",
                table: "stock_fecha",
                column: "punto_venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_stock_teorico_inventarios_dos_producto_id",
                table: "stock_teorico_inventarios_dos",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_stock_teorico_inventarios_dos_punto_venta_id",
                table: "stock_teorico_inventarios_dos",
                column: "punto_venta_id");

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
                name: "IX_unidades_inventarios_dos_producto_id",
                table: "unidades_inventarios_dos",
                column: "producto_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_puntos_ventas_punto_venta_id",
                table: "usuarios_puntos_ventas",
                column: "punto_venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_puntos_ventas_usuario_id",
                table: "usuarios_puntos_ventas",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_roles_rol_id",
                table: "usuarios_roles",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_roles_usuario_id",
                table: "usuarios_roles",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bodegas_puntos_ventas");

            migrationBuilder.DropTable(
                name: "detalle_orden_compra");

            migrationBuilder.DropTable(
                name: "determinar_compras_traslados");

            migrationBuilder.DropTable(
                name: "errores_transacciones");

            migrationBuilder.DropTable(
                name: "historial_envio_recepciones_compras");

            migrationBuilder.DropTable(
                name: "historial_usuarios");

            migrationBuilder.DropTable(
                name: "inventariodetalle",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "inventariodetalle2");

            migrationBuilder.DropTable(
                name: "productos_factores_conversion");

            migrationBuilder.DropTable(
                name: "productos_pedidos");

            migrationBuilder.DropTable(
                name: "productos_proveedores");

            migrationBuilder.DropTable(
                name: "productos_puntos_venta");

            migrationBuilder.DropTable(
                name: "recepciones_compras_detalle");

            migrationBuilder.DropTable(
                name: "recepciones_compras_respuesta");

            migrationBuilder.DropTable(
                name: "respuestas_pedidos_sap");

            migrationBuilder.DropTable(
                name: "roles_permisos");

            migrationBuilder.DropTable(
                name: "SeguimientoPDVTracker");

            migrationBuilder.DropTable(
                name: "stock_fecha");

            migrationBuilder.DropTable(
                name: "stock_teorico_inventarios_dos");

            migrationBuilder.DropTable(
                name: "tipo_pedidos_por_almacen");

            migrationBuilder.DropTable(
                name: "unidades_inventarios_dos");

            migrationBuilder.DropTable(
                name: "usuarios_puntos_ventas");

            migrationBuilder.DropTable(
                name: "usuarios_roles");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "inventarios",
                schema: "SIPOP");

            migrationBuilder.DropTable(
                name: "bodegas");

            migrationBuilder.DropTable(
                name: "inventarios2");

            migrationBuilder.DropTable(
                name: "factores_conversion");

            migrationBuilder.DropTable(
                name: "recepciones_compras");

            migrationBuilder.DropTable(
                name: "permisos");

            migrationBuilder.DropTable(
                name: "centros_logisticos");

            migrationBuilder.DropTable(
                name: "tipos_pedidos_compras_traslados");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "roles");

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
                name: "estados_pedidos");

            migrationBuilder.DropTable(
                name: "tipo_pedido");

            migrationBuilder.DropTable(
                name: "usuarios");

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
