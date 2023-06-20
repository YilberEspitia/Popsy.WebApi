using Popsy.Entities;
using Popsy.Objects;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone la lógica de negocio relacionada con el módulo de ordenes de compra.
    /// </summary>
    public interface IOrdenDeCompraBusiness
    {
        #region OrdenDeCompra
        /// <summary>
        /// Guarda o actualiza un registro de <see cref="TblDetalleOrdenDeCompraEntity"/>.
        /// </summary>
        /// <param name="ordenDeCompra">Objeto de <see cref="OrdenDeCompraSave"/></param>
        /// <returns>Verdadero si se guarda, falso si actualiza.</returns>
        Task<bool> CreateAsync(OrdenDeCompraSave ordenDeCompra);
        /// <summary>
        /// Devuelve un registro por orden de compra.
        /// </summary>
        /// <param name="ordenDeCompra"><see cref="TblOrdenDeCompraEntity"/> orden de compra.</param>
        /// <returns><see cref="OrdenDeCompraRead"/></returns>
        Task<OrdenDeCompraRead> GetOrdenDeCompraAsync(String ordenDeCompra);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblOrdenDeCompraEntity"/> id.</param>
        /// <returns><see cref="OrdenDeCompraRead"/></returns>
        Task<OrdenDeCompraRead> GetOrdenDeCompraAsync(Guid id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblOrdenDeCompraEntity"/>.
        /// </summary>
        /// <returns>Registros de <see cref="OrdenDeCompraRead"/></returns>
        Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraAsync();
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblOrdenDeCompraEntity"/> por proveedor.
        /// </summary>
        /// <param name="proveedor_recepcion_id">Id de proveedor.</param>
        /// <returns>Registros de <see cref="OrdenDeCompraRead"/></returns>
        Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraPorProveedorAsync(Guid proveedor_recepcion_id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblOrdenDeCompraEntity"/> por punto de venta.
        /// </summary>
        /// <param name="punto_venta_id">Id de punto de venta.</param>
        /// <returns>Registros de <see cref="OrdenDeCompraRead"/></returns>
        Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraPorPuntoAsync(Guid punto_venta_id);
        #endregion

        #region Detalle
        /// <summary>
        /// Guarda o actualiza registro de <see cref="TblDetalleOrdenDeCompraEntity"/>.
        /// </summary>
        /// <param name="detalleOrdenDeCompra">Objeto de <see cref="DetalleOrdenDeCompraSave"/></param>
        /// <returns>Verdadero si se guarda, falso si actualiza.</returns>
        Task<bool> CreateAsync(DetalleOrdenDeCompraSave detalleOrdenDeCompra);
        /// <summary>
        /// Guarda o actualiza varios registros de <see cref="TblDetalleOrdenDeCompraEntity"/>.
        /// </summary>
        /// <param name="detalleOrdenDeCompra">Objeto de <see cref="DetalleOrdenDeCompraSave"/></param>
        /// <returns>Verdadero si se guarda o actualiza.</returns>
        Task<bool> CreateManyAsync(IEnumerable<DetalleOrdenDeCompraSave> detalleOrdenDeCompra);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblDetalleOrdenDeCompraEntity"/> id.</param>
        /// <returns><see cref="DetalleOrdenDeCompraRead"/></returns>
        Task<DetalleOrdenDeCompraRead> GetDetalleOrdenDeCompraAsync(Guid id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblDetalleOrdenDeCompraEntity"/>.
        /// </summary>
        /// <returns>Registros de <see cref="DetalleOrdenDeCompraRead"/></returns>
        Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraAsync();
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblDetalleOrdenDeCompraEntity"/> por producto.
        /// </summary>
        /// <param name="producto_id">Id de producto.</param>
        /// <returns>Registros de <see cref="DetalleOrdenDeCompraRead"/></returns>
        Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraPorProductoAsync(Guid producto_id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblDetalleOrdenDeCompraEntity"/> por orden de compra.
        /// </summary>
        /// <param name="orden_compra_id">Id de orden de compra.</param>
        /// <returns>Registros de <see cref="DetalleOrdenDeCompraRead"/></returns>
        Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraPorOrdenAsync(Guid orden_compra_id);
        #endregion

        #region Integraciones
        /// <summary>
        /// Metodo que sincroniza las ordenes de compra.
        /// </summary>
        /// <returns>Response de la sincronización.</returns>
        Task<IEnumerable<ResponseOrdenesPopsySAP>> SyncSAPAsync();
        #endregion
    }
}
