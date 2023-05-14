using Microsoft.EntityFrameworkCore;

using Popsy.Entities;

namespace Popsy
{
    /// <summary>
    /// Modelo de la base de datos.
    /// </summary>
    public sealed partial class PopsyDbContext
    {
        #region Auth
        /// <summary>
        /// Tabla de usarios.
        /// </summary>
        public DbSet<TblUsuarioEntity> Usuarios { get; set; }
        /// <summary>
        /// Tabla de permisos.
        /// </summary>
        public DbSet<TblPermisoEntity> Permisos { get; set; }
        /// <summary>
        /// Tabla de roles.
        /// </summary>
        public DbSet<TblRolEntity> Roles { get; set; }
        /// <summary>
        /// Tabla de usuarios.
        /// </summary>
        public DbSet<TblHistorialUsuarioEntity> HistorialUsuarios { get; set; }
        /// <summary>
        /// Tabla de roles por permiso.
        /// </summary>
        public DbSet<TblRolPermisoEntity> RolesPorPermiso { get; set; }
        /// <summary>
        /// Tabla de roles por usuarios.
        /// </summary>
        public DbSet<TblUsuarioRolEntity> RolesDeUsuarios { get; set; }
        #endregion
        #region Nivel0
        /// <summary>
        /// Tabla de bodegas.
        /// </summary>
        public DbSet<TblBodegaEntity> Bodegas { get; set; }
        /// <summary>
        /// Tabla de centros logisticos.
        /// </summary>
        public DbSet<TblCentroLogisticoEntity> CentrosLogisticos { get; set; }
        /// <summary>
        /// Tabla de estado de pedidos.
        /// </summary>
        public DbSet<TblEstadoPedidoEntity> EstadoDePedidos { get; set; }
        /// <summary>
        /// Tabla de factores de conversión.
        /// </summary>
        public DbSet<TblFactorConversionEntity> FactoresDeConversion { get; set; }
        /// <summary>
        /// Tabla de organizaciones de ventas.
        /// </summary>
        public DbSet<TblOrganizacionVentaEntity> OrganizacionesVentas { get; set; }
        /// <summary>
        /// Tabla de productos.
        /// </summary>
        public DbSet<TblProductoEntity> Productos { get; set; }
        /// <summary>
        /// Tabla de productos por proveedor.
        /// </summary>
        public DbSet<TblProductoProveedorEntity> ProductoresProveedor { get; set; }
        /// <summary>
        /// Tabla de recepción de proveedores.
        /// </summary>
        public DbSet<TblProveedorRecepcionEntity> ProveedoresRecepcion { get; set; }
        /// <summary>
        /// Tabla de tipos de inventarios.
        /// </summary>
        public DbSet<TblTipoInventarioEntity> TiposDeInventario { get; set; }
        /// <summary>
        /// TipoPedidoCompraTraslados.
        /// </summary>
        public DbSet<TblTipoPedidoCompraTrasladoEntity> TipoPedidoCompraTraslados { get; set; }
        /// <summary>
        /// Tabla de tipos de pedidos.
        /// </summary>
        public DbSet<TblTipoPedidoEntity> TiposDePedidos { get; set; }
        /// <summary>
        /// Tabla de tipos de transacciones.
        /// </summary>
        public DbSet<TblTipoTransaccionEntity> TiposDeTransacciones { get; set; }
        #endregion
        #region Nivel1
        /// <summary>
        /// Tabla de distritos.
        /// </summary>
        public DbSet<TblDistritoEntity> Distritos { get; set; }
        /// <summary>
        /// Tabla de factores de conversión por producto.
        /// </summary>
        public DbSet<TblProductoFactorConversionEntity> FactoresDeConversionProducto { get; set; }
        #endregion
        #region Nivel2
        /// <summary>
        /// Tabla de puntos de venta.
        /// </summary>
        public DbSet<TblPuntoVentaEntity> PuntosDeVenta { get; set; }
        #endregion
        #region Nivel3
        /// <summary>
        /// Tabla de puntos de venta por bodega.
        /// </summary>
        public DbSet<TblBodegaPuntoVentaEntity> BodegaPuntosDeVenta { get; set; }
        /// <summary>
        /// Tabla para determinar el traslado de la compra.
        /// </summary>
        public DbSet<TblDeterminarCompraTrasladoEntity> DeterminarCompraTraslados { get; set; }
        /// <summary>
        /// Tabla de inventarios.
        /// </summary>
        public DbSet<TblInventarioEntity> Inventarios { get; set; }
        /// <summary>
        /// Tabla de ordenes de compra.
        /// </summary>
        public DbSet<TblOrdenDeCompraEntity> OrdenesDeCompra { get; set; }
        /// <summary>
        /// Tabla de pedidos.
        /// </summary>
        public DbSet<TblPedidoEntity> Pedidos { get; set; }
        /// <summary>
        /// Tabla de productos por punto de venta.
        /// </summary>
        public DbSet<TblProductoPuntoVentaEntity> ProductosPuntoDeVenta { get; set; }
        /// <summary>
        /// Tabla de tipos de pedido por almacen.
        /// </summary>
        public DbSet<TblTipoPedidoPorAlmacenEntity> TiposDePedidoPorAlmacen { get; set; }
        /// <summary>
        /// Tabla de tipos de pedido por almacen.
        /// </summary>
        public DbSet<TblUsuarioPuntoVentaEntity> UsuariosPuntoDeVenta { get; set; }
        #endregion
        #region Nivel4
        /// <summary>
        /// Tabla de detalles de ordenes de compra.
        /// </summary>
        public DbSet<TblDetalleOrdenDeCompraEntity> DetallesOrdenesDeCompra { get; set; }
        /// <summary>
        /// Tabla de detalles de inventarios.
        /// </summary>
        public DbSet<TblInventarioDetalleEntity> InventarioDetalles { get; set; }
        /// <summary>
        /// Tabla de productos por pedido.
        /// </summary>
        public DbSet<TblProductoPedidoEntity> PropuctosPorPedido { get; set; }
        /// <summary>
        /// Tabla de transacciones.
        /// </summary>
        public DbSet<TblTransaccionEntity> Transacciones { get; set; }
        #endregion
        #region Nivel5
        /// <summary>
        /// Tabla de errores por transacción.
        /// </summary>
        public DbSet<TblErrorTransaccionEntity> ErroresTransaccion { get; set; }
        /// <summary>
        /// Tabla de recepciones de compra.
        /// </summary>
        public DbSet<TblRecepcionDeCompraEntity> RecepcionesDeCompra { get; set; }
        #endregion
        #region Vistas
        /// <summary>
        /// Vista de categorias de productos.
        /// </summary>
        public DbSet<VistaCategoriasProductosEntity> VistaCategoriasProductos { get; set; }
        /// <summary>
        /// Vista de productos con stock.
        /// </summary>
        public DbSet<VistaProductosConStockEntity> VistaProductosConStock { get; set; }
        /// <summary>
        /// Vista de productos para inventario.
        /// </summary>
        public DbSet<VistaProductosParaInventarioEntity> VistaProductosParaInventario { get; set; }
        /// <summary>
        /// Vista de puntos de venta por bodega.
        /// </summary>
        public DbSet<VistaPuntosVentaBodegasEntity> VistaPuntosVentaBodegas { get; set; }
        /// <summary>
        /// Vista de inventario de monitor.
        /// </summary>
        public DbSet<VistaMonitorInventarioEntity> VistaMonitorInventario { get; set; }
        /// <summary>
        /// Vista de resumen de inventario.
        /// </summary>
        public DbSet<VistaResumenInventarioEntity> VistaResumenInventario { get; set; }
        /// <summary>
        /// Vista de pedidos por punto de venta.
        /// </summary>
        public DbSet<VistaPedidosPuntoVentaEntity> VistaPedidosPuntoVenta { get; set; }
        /// <summary>
        /// Vista de productos por factores de conversión.
        /// </summary>
        public DbSet<VistaProductoFactoresConversionEntity> VistaProductoFactoresConversion { get; set; }
        #endregion
    }
}
