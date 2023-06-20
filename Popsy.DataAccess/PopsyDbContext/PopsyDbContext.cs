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

            #region Guid
            #region Auth
            modelBuilder.Entity<TblUsuarioEntity>().Property(x => x.usuario_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblPermisoEntity>().Property(x => x.permiso_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblRolEntity>().Property(x => x.rol_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblHistorialUsuarioEntity>().Property(x => x.historial_usuario_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblRolPermisoEntity>().Property(x => x.rol_permiso_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblUsuarioRolEntity>().Property(x => x.usuario_rol_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            #endregion
            #region Nivel0
            modelBuilder.Entity<TblBodegaEntity>().Property(x => x.bodega_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblCentroLogisticoEntity>().Property(x => x.centros_logisticos_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblEstadoPedidoEntity>().Property(x => x.estado_pedido_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblFactorConversionEntity>().Property(x => x.factor_conversion_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblOrganizacionVentaEntity>().Property(x => x.organizacion_venta_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblProductoEntity>().Property(x => x.producto_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblProductoProveedorEntity>().Property(x => x.productos_proveedores_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblProveedorRecepcionEntity>().Property(x => x.proveedor_recepcion_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblTipoInventarioEntity>().Property(x => x.tipo_inventario_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblTipoPedidoCompraTrasladoEntity>().Property(x => x.tipo_pedido_compra_traslado_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblTipoPedidoEntity>().Property(x => x.tipo_pedido_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblTipoTransaccionEntity>().Property(x => x.tipo_transaccion_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            #endregion
            #region Nivel1
            modelBuilder.Entity<TblUnidadInventarioDos>().Property(x => x.unidad_inventario_dos_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblDistritoEntity>().Property(x => x.distrito_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblProductoFactorConversionEntity>().Property(x => x.producto_factor_conversion_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            #endregion
            #region Nivel2
            modelBuilder.Entity<TblPuntoVentaEntity>().Property(x => x.punto_venta_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            #endregion
            #region Nivel3
            modelBuilder.Entity<TblBodegaPuntoVentaEntity>().Property(x => x.bodega_punto_venta_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblDeterminarCompraTrasladoEntity>().Property(x => x.determinar_compra_traslado_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblInventarioEntity>().Property(x => x.inventario_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblInventario2Entity>().Property(x => x.inventario_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblOrdenDeCompraEntity>().Property(x => x.orden_compra_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblPedidoEntity>().Property(x => x.pedido_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblStockAFechaEntity>().Property(x => x.stock_fecha_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblProductoPuntoVentaEntity>().Property(x => x.producto_punto_venta_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblStockTeoricoInventariosDos>().Property(x => x.stock_teorico_inventarios_dos_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblTipoPedidoPorAlmacenEntity>().Property(x => x.tipo_pedido_por_almacen_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblUsuarioPuntoVentaEntity>().Property(x => x.usuario_punto_venta_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            #endregion
            #region Nivel4
            modelBuilder.Entity<TblDetalleOrdenDeCompraEntity>().Property(x => x.detalle_orden_compra_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblInventarioDetalleEntity>().Property(x => x.inventario_detalle_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblInventarioDetalle2Entity>().Property(x => x.inventario_detalle_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblProductoPedidoEntity>().Property(x => x.producto_pedido_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblResponsePedidoEntity>().Property(x => x.respuesta_pedido_sap_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblTransaccionEntity>().Property(x => x.transaccion_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblRecepcionDeCompraEntity>().Property(x => x.recepcion_compra_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            #endregion
            #region Nivel5
            modelBuilder.Entity<TblErrorTransaccionEntity>().Property(x => x.error_transaccion_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblRecepcionDeCompraDetalleEntity>().Property(x => x.recepcion_compra_detalle_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblHistorialEnvioRecepcionDeCompraEntity>().Property(x => x.historial_envio_recepciones_compras_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblInventarioConteo2Entity>().Property(x => x.inventario_conteo_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<TblResponseRecepcionDeCompraEntity>().Property(x => x.recepcion_compra_respuesta_id).HasDefaultValueSql("NEWSEQUENTIALID()");
            #endregion
            #endregion

            #region FechaCreacion
            #region Auth
            //modelBuilder.Entity<TblUsuarioEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblPermisoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblRolEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblHistorialUsuarioEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblRolPermisoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblUsuarioRolEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel0
            modelBuilder.Entity<TblBodegaEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblCentroLogisticoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblEstadoPedidoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblFactorConversionEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblOrganizacionVentaEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProductoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProductoProveedorEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProveedorRecepcionEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblTipoInventarioEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblTipoPedidoCompraTrasladoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblTipoPedidoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblTipoTransaccionEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel1
            modelBuilder.Entity<TblUnidadInventarioDos>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblDistritoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProductoFactorConversionEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel2
            modelBuilder.Entity<TblPuntoVentaEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel3
            modelBuilder.Entity<TblBodegaPuntoVentaEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblDeterminarCompraTrasladoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblInventario2Entity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblOrdenDeCompraEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblPedidoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblStockAFechaEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProductoPuntoVentaEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblStockTeoricoInventariosDos>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblTipoPedidoPorAlmacenEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblUsuarioPuntoVentaEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel4
            modelBuilder.Entity<TblDetalleOrdenDeCompraEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblInventarioDetalleEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblInventarioDetalle2Entity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProductoPedidoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblResponsePedidoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblTransaccionEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblRecepcionDeCompraEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel5
            modelBuilder.Entity<TblErrorTransaccionEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblRecepcionDeCompraDetalleEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblHistorialEnvioRecepcionDeCompraEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblInventarioConteo2Entity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblResponseRecepcionDeCompraEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #endregion

            #region FechaModificacion
            #region Auth
            //modelBuilder.Entity<TblUsuarioEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblPermisoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblRolEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblHistorialUsuarioEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblRolPermisoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblUsuarioRolEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel0
            modelBuilder.Entity<TblBodegaEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblCentroLogisticoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblEstadoPedidoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblFactorConversionEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblOrganizacionVentaEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProductoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProductoProveedorEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProveedorRecepcionEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblTipoInventarioEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblTipoPedidoCompraTrasladoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblTipoPedidoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblTipoTransaccionEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel1
            modelBuilder.Entity<TblUnidadInventarioDos>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblDistritoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProductoFactorConversionEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel2
            modelBuilder.Entity<TblPuntoVentaEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel3
            modelBuilder.Entity<TblBodegaPuntoVentaEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblDeterminarCompraTrasladoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblInventarioEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblInventario2Entity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblOrdenDeCompraEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblPedidoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblStockAFechaEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProductoPuntoVentaEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblStockTeoricoInventariosDos>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblTipoPedidoPorAlmacenEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblUsuarioPuntoVentaEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel4
            modelBuilder.Entity<TblDetalleOrdenDeCompraEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<TblInventarioDetalleEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblInventarioDetalle2Entity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblResponsePedidoEntity>().Property(x => x.fecha_creacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblProductoPedidoEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblTransaccionEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblRecepcionDeCompraEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #region Nivel5
            modelBuilder.Entity<TblErrorTransaccionEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblRecepcionDeCompraDetalleEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblHistorialEnvioRecepcionDeCompraEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblInventarioConteo2Entity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TblResponseRecepcionDeCompraEntity>().Property(x => x.fecha_modificacion).HasDefaultValueSql("GETDATE()");
            #endregion
            #endregion

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
            modelBuilder.Entity<TblSeguimientoPDVTrackerEntity>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<TblSeguimientoPDVEntity>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("SeguimientoPDV");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
