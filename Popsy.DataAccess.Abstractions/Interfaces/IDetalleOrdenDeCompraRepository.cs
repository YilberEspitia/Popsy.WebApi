using Popsy.Entities;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone los metodos de la base de datos relacionados con esta entidad: <see cref="TblDetalleOrdenDeCompraEntity"/>.
    /// </summary>
    public interface IDetalleOrdenDeCompraRepository
    {
        /// <summary>
        /// Guarda un nuevo registro de <see cref="TblDetalleOrdenDeCompraEntity"/>.
        /// </summary>
        /// <param name="detalleOrdenDeCompra">Objeto de <see cref="TblDetalleOrdenDeCompraEntity"/></param>
        /// <returns>Verdadero si se guarda.</returns>
        Task<Guid> CreateAsync(TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra);
        /// <summary>
        /// Actualiza un registro existente de <see cref="TblDetalleOrdenDeCompraEntity"/>.
        /// </summary>
        /// <param name="detalleOrdenDeCompra">Objeto de <see cref="TblDetalleOrdenDeCompraEntity"/></param>
        /// <returns>Verdadero si se actualiza.</returns>
        Task<bool> UpdateAsync(TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblDetalleOrdenDeCompraEntity"/> id.</param>
        /// <returns><see cref="TblDetalleOrdenDeCompraEntity"/></returns>
        Task<TblDetalleOrdenDeCompraEntity?> GetDetalleOrdenDeCompraAsync(Guid id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblDetalleOrdenDeCompraEntity"/>.
        /// </summary>
        /// <returns>Registros de <see cref="TblDetalleOrdenDeCompraEntity"/></returns>
        Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> GetDetallesDeOrdenesDeCompraAsync();
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblDetalleOrdenDeCompraEntity"/> por producto.
        /// </summary>
        /// <param name="producto_id">Id de producto.</param>
        /// <returns>Registros de <see cref="TblDetalleOrdenDeCompraEntity"/></returns>
        Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> GetDetallesDeOrdenesDeCompraPorProductoAsync(Guid producto_id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblDetalleOrdenDeCompraEntity"/> por orden de compra.
        /// </summary>
        /// <param name="orden_compra_id">Id de orden de compra.</param>
        /// <returns>Registros de <see cref="TblDetalleOrdenDeCompraEntity"/></returns>
        Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> GetDetallesDeOrdenesDeCompraPorOrdenAsync(Guid orden_compra_id);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblDetalleOrdenDeCompraEntity"/> con ese id.
        /// </summary>
        /// <param name="id"><see cref="TblDetalleOrdenDeCompraEntity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<bool> ExisteAsync(Guid id);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblProductoEntity"/> con ese id.
        /// </summary>
        /// <param name="id"><see cref="TblProductoEntity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<bool> ExisteProductoAsync(Guid producto_id);
        Task<bool> ExisteProductoAsync(string codigo);
        Task<Guid> GetProductoPorCodigoAsync(string codigo);
        Task UpdateEstadoDetalles(Guid orden_compra_id, bool activo);
        Task UpdateEstadoDetalle(Guid detalle_orden_compra_id, bool activo);
        Task<TblDetalleOrdenDeCompraEntity?> GetDetalleAsync(Guid orden_compra_id, Guid producto_id, string unidad_presentacion_solicitada);
    }
}
