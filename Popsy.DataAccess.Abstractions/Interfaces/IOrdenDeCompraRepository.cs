using Popsy.Entities;
using Popsy.Objects;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone los metodos de la base de datos relacionados con esta entidad: <see cref="TblOrdenDeCompraEntity"/>.
    /// </summary>
    public interface IOrdenDeCompraRepository
    {
        /// <summary>
        /// Guarda un nuevo registro de <see cref="TblOrdenDeCompraEntity"/>.
        /// </summary>
        /// <param name="ordenDeCompra">Objeto de <see cref="TblOrdenDeCompraEntity"/></param>
        /// <returns>Verdadero si se guarda.</returns>
        Task<Guid> CreateAsync(TblOrdenDeCompraEntity ordenDeCompra);
        /// <summary>
        /// Actualiza un registro existente de <see cref="TblOrdenDeCompraEntity"/>.
        /// </summary>
        /// <param name="ordenDeCompra">Objeto de <see cref="TblOrdenDeCompraEntity"/></param>
        /// <returns>Verdadero si se actualiza.</returns>
        Task<bool> UpdateAsync(TblOrdenDeCompraEntity ordenDeCompra);
        /// <summary>
        /// Devuelve un registro por orden de compra.
        /// </summary>
        /// <param name="ordenDeCompra"><see cref="TblOrdenDeCompraEntity"/> orden de compra.</param>
        /// <returns><see cref="TblOrdenDeCompraEntity"/></returns>
        Task<TblOrdenDeCompraEntity?> GetOrdenDeCompraAsync(String ordenDeCompra);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblOrdenDeCompraEntity"/> id.</param>
        /// <returns><see cref="TblOrdenDeCompraEntity"/></returns>
        Task<TblOrdenDeCompraEntity?> GetOrdenDeCompraAsync(Guid id);
        Task<TblOrdenDeCompraEntity?> GetOrdenDeCompraPorCodigoAsync(string codigo);
        Task<IEnumerable<PuntoDeVentaBasicRead>> GetAllPuntosDeVentaAsync();
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblOrdenDeCompraEntity"/>.
        /// </summary>
        /// <returns>Registros de <see cref="TblOrdenDeCompraEntity"/></returns>
        Task<IEnumerable<TblOrdenDeCompraEntity>> GetOrdenesDeCompraAsync();
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblOrdenDeCompraEntity"/> por proveedor.
        /// </summary>
        /// <param name="proveedor_recepcion_id">Id de proveedor.</param>
        /// <returns>Registros de <see cref="TblOrdenDeCompraEntity"/></returns>
        Task<IEnumerable<TblOrdenDeCompraEntity>> GetOrdenesDeCompraPorProveedorAsync(Guid proveedor_recepcion_id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblOrdenDeCompraEntity"/> por punto de venta.
        /// </summary>
        /// <param name="punto_venta_id">Id de punto de venta.</param>
        /// <returns>Registros de <see cref="TblOrdenDeCompraEntity"/></returns>
        Task<IEnumerable<TblOrdenDeCompraEntity>> GetOrdenesDeCompraPorPuntoAsync(Guid punto_venta_id);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblProveedorRecepcionEntity"/> con ese id.
        /// </summary>
        /// <param name="proveedor_recepcion_id"><see cref="TblProveedorRecepcionEntity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<bool> ExisteProveedorRecepcionAsync(Guid proveedor_recepcion_id);
        Task<bool> ExisteProveedorRecepcionPorCodigoAsync(string codigo_sap);
        Task<Guid> GetIdProveedorRecepcionPorCodigoAsync(string codigo_sap);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblOrdenDeCompraEntity"/> con ese id.
        /// </summary>
        /// <param name="id"><see cref="TblOrdenDeCompraEntity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<bool> ExisteAsync(Guid id);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblPuntoVentaEntity"/> con ese id.
        /// </summary>
        /// <param name="punto_venta_id"><see cref="TblPuntoVentaEntity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<bool> ExistePuntoDeVentaAsync(Guid punto_venta_id);
        /// <summary>
        /// Actualiza el estado de la orden de compra.
        /// </summary>
        /// <param name="orden_compra_id">Id de orden de compra.</param>
        /// <param name="recibida">Nuevo valor de recibido.</param>
        Task ActualizarRecepcionDeOrden(Guid orden_compra_id, bool recibida);
    }
}
