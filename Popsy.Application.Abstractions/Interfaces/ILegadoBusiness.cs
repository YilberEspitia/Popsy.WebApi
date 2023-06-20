using Popsy.Enums;
using Popsy.Objects;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone el negocio de puntos de venta.
    /// </summary>
    public interface ILegadoBusiness
    {
        /// <summary>
        /// Devuelve todos los seguimientos de los puntos de venta.
        /// </summary>
        /// <returns>Colecci�n de <see cref="SeguimientoPDVObject"/> objeto.</returns>
        Task<IEnumerable<SeguimientoPDVObject>> GetSeguimientoPDVsAsync();
        /// <summary>
        /// Devuelve los detalles de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns>Colecci�n de <see cref="DetalleSeguimientoPDVObject"/> objeto.</returns>
        Task<IEnumerable<DetalleSeguimientoPDVObject>> GetSeguimientoPDVDetalleAsync(Guid punto_venta_id);
        /// <summary>
        /// Devuelve los detalles de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="tipo">Tipo.</param>
        /// <returns>Colecci�n de <see cref="DetalleSeguimientoPDVObject"/> objeto.</returns>
        Task<IEnumerable<DetalleSeguimientoPDVObject>> GetSeguimientoPDVDetalleAsync(Guid punto_venta_id, SAPType tipo);
        /// <summary>
        /// Devuelve los detalles de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="id">Id del tipo.</param>
        /// <param name="tipo">Tipo.</param>
        /// <returns><see cref="DetalleSeguimientoPDVObject"/> objeto.</returns>
        Task<DetalleSeguimientoPDVObject> GetSeguimientoPDVDetalleAsync(Guid punto_venta_id, Guid id, SAPType tipo);
        /// <summary>
        /// Actualiza el estado de un tipo de comunicaci�n con SAP.
        /// </summary>
        /// <param name="id">Id del tipo.</param>
        /// <param name="tipo">Tipo.</param>
        /// <param name="nuevo_estado">Estado a actualizar.</param>
        /// <returns>Verdadero si actualiza, caso contrario devuelve falso.</returns>
        Task<bool> UpdateEstadoAsync(Guid id, SAPType tipo, SAPEstado nuevo_estado);
        /// <summary>
        /// Envia manualmente la recepci�n de compra a SAP.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="recepcion_compra_id">Recepci�n de compra id.</param>
        /// <returns><see cref="ResponseRecepcionDeCompraXMLObject"/> response.</returns>
        Task<ResponseRecepcionDeCompraXMLObject> EnviarRecepcionDeCompra(Guid punto_venta_id, Guid recepcion_compra_id);
        /// <summary>
        /// Envia manualmente la recepci�n de compra a SAP.
        /// </summary>
        /// <returns><see cref="ResponseRecepcionDeCompraXMLTotalObject"/> response.</returns>
        Task<ResponseRecepcionDeCompraXMLTotalObject> EnviarRecepcionesDeCompra();
        /// <summary>
        /// Gestiona y compara los stocks por fecha.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="fecha_stock">Fecha a comparar.</param>
        /// <returns><see cref="InventarioGestionSAP"/> objeto.</returns>
        Task<InventarioGestionSAP> GestionarStockAsync(Guid punto_venta_id, DateTime fecha_stock);
    }
}