using Microsoft.EntityFrameworkCore;

using Popsy.Entities;

namespace Popsy
{
    /// <summary>
    /// Modelo de la base de datos.
    /// </summary>
    public sealed partial class PopsyDbContext
    {
        #region Nivel0
        public DbSet<TblBodegaEntity> Bodegas { get; set; }
        public DbSet<TblCentroLogisticoEntity> CentrosLogisticos { get; set; }
        public DbSet<TblEstadoPedidoEntity> EstadoDePedidos { get; set; }
        public DbSet<TblFactorConversionEntity> FactoresDeConversion { get; set; }
        public DbSet<TblOrganizacionVentaEntity> OrganizacionesVentas { get; set; }
        public DbSet<TblProductoEntity> Productos { get; set; }
        public DbSet<TblProductoProveedorEntity> ProductoresProveedor { get; set; }
        public DbSet<TblProveedorRecepcionEntity> ProveedoresRecepcion { get; set; }
        public DbSet<TblTipoInventarioEntity> TiposDeInventario { get; set; }
        public DbSet<TblTipoPedidoCompraTrasladoEntity> TipoPedidoCompraTraslados { get; set; }
        public DbSet<TblTipoPedidoEntity> TiposDePedidos { get; set; }
        public DbSet<TblTipoTransaccionEntity> TiposDeTransacciones { get; set; }
        public DbSet<TblUsuarioEntity> Usuarios { get; set; }
        #endregion
        #region Nivel1
        public DbSet<TblDistritoEntity> Distritos { get; set; }
        public DbSet<TblProductoFactorConversionEntity> FactoresDeConversionProducto { get; set; }
        #endregion
        #region Nivel2
        public DbSet<TblPuntoVentaEntity> PuntosDeVenta { get; set; }
        #endregion
        #region Nivel3
        public DbSet<TblBodegaPuntoVentaEntity> BodegaPuntosDeVenta { get; set; }
        public DbSet<TblDeterminarCompraTrasladoEntity> DeterminarCompraTraslados { get; set; }
        public DbSet<TblInventarioEntity> Inventarios { get; set; }
        public DbSet<TblOrdenDeCompraEntity> OrdenesDeCompra { get; set; }
        public DbSet<TblPedidoEntity> Pedidos { get; set; }
        public DbSet<TblProductoPuntoVentaEntity> ProductosPuntoDeVenta { get; set; }
        public DbSet<TblTipoPedidoPorAlmacenEntity> TiposDePedidoPorAlmacen { get; set; }
        public DbSet<TblUsuarioPuntoVentaEntity> UsuariosPuntoDeVenta { get; set; }
        #endregion
        #region Nivel4
        public DbSet<TblDetalleOrdenDeCompraEntity> DetallesOrdenesDeCompra { get; set; }
        public DbSet<TblInventarioDetalleEntity> InventarioDetalles { get; set; }
        public DbSet<TblProductoPedidoEntity> PropuctosPorPedido { get; set; }
        public DbSet<TblTransaccionEntity> Transacciones { get; set; }
        #endregion
        #region Nivel5
        public DbSet<TblErrorTransaccionEntity> ErroresTransaccion { get; set; }
        public DbSet<TblRecepcionDeCompraEntity> RecepcionesDeCompra { get; set; }
        #endregion
        #region Vistas
        public DbSet<VistaCategoriasProductosEntity> VistaCategoriasProductos { get; set; }
        public DbSet<VistaProductosConStockEntity> VistaProductosConStock { get; set; }
        public DbSet<VistaProductosParaInventarioEntity> VistaProductosParaInventario { get; set; }
        public DbSet<VistaPuntosVentaBodegasEntity> VistaPuntosVentaBodegas { get; set; }
        public DbSet<VistaMonitorInventarioEntity> VistaMonitorInventario { get; set; }
        public DbSet<VistaResumenInventarioEntity> VistaResumenInventario { get; set; }
        public DbSet<VistaPedidosPuntoVentaEntity> VistaPedidosPuntoVenta { get; set; }
        public DbSet<VistaProductoFactoresConversionEntity> VistaProductoFactoresConversion { get; set; }
        #endregion
    }
}
