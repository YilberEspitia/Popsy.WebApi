using Microsoft.EntityFrameworkCore;

using Popsy.Entities;

namespace Popsy
{
    /// <summary>
    /// Modelo de la base de datos.
    /// </summary>
    public sealed partial class PopsyDbContext
    {
        public DbSet<VistaCategoriasProductosEntity> VistaCategoriasProductos { get; set; }
        public DbSet<VistaProductosConStockEntity> VistaProductosConStock { get; set; }
        public DbSet<VistaProductosParaInventarioEntity> VistaProductosParaInventario { get; set; }
        public DbSet<VistaPuntosVentaBodegasEntity> VistaPuntosVentaBodegas { get; set; }
        public DbSet<TblInventariosEntity> TblInventarios { get; set; }
        public DbSet<TblInventarioDetalleEntity> TblInventarioDetalle { get; set; }
        public DbSet<VistaMonitorInventarioEntity> VistaMonitorInventario { get; set; }
        public DbSet<VistaResumenInventarioEntity> VistaResumenInventario { get; set; }
        public DbSet<TblUsuariosPuntosVentasEntity> TblUsuariosPuntosVentas { get; set; }
        public DbSet<TblTipoInventarioEntity> TblTipoInventario { get; set; }
        public DbSet<TblProductosPuntosVentaEntity> TblProductosPuntosVenta { get; set; }
        public DbSet<TblProductosPedidosEntity> TblProductosPedidos { get; set; }
        public DbSet<TblDeterminarComprasTrasladosEntity> TblDeterminarComprasTraslados { get; set; }
        public DbSet<VistaPedidosPuntoVentaEntity> VistaPedidosPuntoVenta { get; set; }
        public DbSet<TblProductosEntity> TblProductos { get; set; }
        public DbSet<VistaProductoFactoresConversionEntity> VistaProductoFactoresConversion { get; set; }
        public DbSet<TblPuntosVentasEntity> TblPuntosVentas { get; set; }
    }
}
