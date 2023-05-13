using Microsoft.EntityFrameworkCore;

using Popsy.Entities;

namespace Popsy
{
    /// <summary>
    /// DbContext para manejo de entidades.
    /// </summary>
    public sealed partial class PopsyDbContext : DbContext
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options">Referencia de <see cref="DbContextOptions"/></param>
        public PopsyDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblRecepcionDeCompraEntity>()
                .Property(e => e.constante)
                .ValueGeneratedOnAdd()
                .HasAnnotation("SqlServer:Identity:Seed", "1");

            modelBuilder.Entity<VistaCategoriasProductosEntity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vistacategoriasproductos", "SIPOP");
            });
            modelBuilder.Entity<VistaMonitorInventarioEntity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vistamonitorInventario", "SIPOP");
            });
            modelBuilder.Entity<VistaPedidosPuntoVentaEntity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vistapedidospuntoventa", "SIPOP");
            });
            modelBuilder.Entity<VistaProductoFactoresConversionEntity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vistaproductofactoresconversion", "SIPOP");
            });
            modelBuilder.Entity<VistaProductosConStockEntity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vistaproductosconstock", "SIPOP");
            });
            modelBuilder.Entity<VistaProductosParaInventarioEntity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vistaproductosparainventario", "SIPOP");
            });
            modelBuilder.Entity<VistaPuntosVentaBodegasEntity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vistapuntosventabodegas", "SIPOP");
            });
            modelBuilder.Entity<VistaResumenInventarioEntity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vistaresumeninventario", "SIPOP");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
