using Popsy.Entities;
using Popsy.Objects;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone el repositorio de puntos de venta.
    /// </summary>
    public interface IPuntosVentasRepository
    {
        Task<IEnumerable<Guid>> GetAllPuntosVentaAsyn();
        /// <summary>
        /// Devuelve el punto de venta por id.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns><see cref="TblPuntoVentaEntity"/> object.</returns>
        Task<TblPuntoVentaEntity?> GetPuntoVentasId(Guid punto_venta_id);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblPuntoVentaEntity"/> con ese id.
        /// </summary>
        /// <param name="punto_venta_id"><see cref="TblPuntoVentaEntity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<bool> ExistePuntoDeVentaAsync(Guid punto_venta_id);
        /// <summary>
        /// Devuelve todos los puntos de venta con seguimientos.
        /// </summary>
        /// <returns>Colección de <see cref="SeguimientoPDVObject"/> objeto.</returns>
        Task<IEnumerable<SeguimientoPDVObjectBase>> GetPuntosPorSeguimientoPDVsAsync();
        /// <summary>
        /// Devuelve todos los pendientes por punto de venta.
        /// </summary>
        /// <returns><see cref="SeguimientoPDVObject"/> objeto.</returns>
        Task<PendientesPDVObject> GetPendientesPDVAsync(Guid punto_venta_id);
        /// <summary>
        /// Devuelve la fecha de la toma de inventario pendiente.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns>Fecha de la toma del inventario.</returns>
        Task<DateTime?> GetFechaTomaInventarioAsync(Guid punto_venta_id);

        #region Detalles
        /// <summary>
        /// Devuelve los detalles de pedidos de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns>Global ids.</returns>
        Task<IEnumerable<Guid>> GetSeguimientoPDVDetallePedidosAsync(Guid punto_venta_id);
        /// <summary>
        /// Devuelve los detalles de inventarios de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns>Global ids.</returns>
        Task<IEnumerable<Guid>> GetSeguimientoPDVDetalleInventariosAsync(Guid punto_venta_id);
        /// <summary>
        /// Devuelve los detalles de pedidos de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns>Global ids.</returns>
        Task<IEnumerable<Guid>> GetSeguimientoPDVDetalleRecepcionesAsync(Guid punto_venta_id);
        /// <summary>
        /// Devuelve los detalles de pedidos de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="pedido_id">Pedido id.</param>
        /// <returns>Colección de <see cref="DetalleSeguimientoPDVObject"/> objeto.</returns>
        Task<DetalleSeguimientoPDVObject?> GetSeguimientoPDVDetallePedidoAsync(Guid punto_venta_id, Guid pedido_id);
        /// <summary>
        /// Devuelve los detalles de inventarios de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="inventario_id">Inventario id.</param>
        /// <returns>Colección de <see cref="DetalleSeguimientoPDVObject"/> objeto.</returns>
        Task<DetalleSeguimientoPDVObject?> GetSeguimientoPDVDetalleInventarioAsync(Guid punto_venta_id, Guid inventario_id);
        /// <summary>
        /// Devuelve los detalles de pedidos de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="recepcion_id">Recepcion id.</param>
        /// <returns><see cref="DetalleSeguimientoPDVObject"/> objeto.</returns>
        Task<DetalleSeguimientoPDVObject?> GetSeguimientoPDVDetalleRecepcionAsync(Guid punto_venta_id, Guid recepcion_id);
        #endregion
    }
}