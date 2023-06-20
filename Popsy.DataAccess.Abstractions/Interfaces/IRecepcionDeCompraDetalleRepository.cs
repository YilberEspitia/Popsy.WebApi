using Popsy.Entities;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone los metodos de la base de datos relacionados con esta entidad: <see cref="TblRecepcionDeCompraDetalleEntity"/>.
    /// </summary>
    public interface IRecepcionDeCompraDetalleRepository
    {
        /// <summary>
        /// Guarda un nuevo registro de <see cref="TblRecepcionDeCompraDetalleEntity"/>.
        /// </summary>
        /// <param name="detalleRecepcionDeCompra">Objeto de <see cref="TblRecepcionDeCompraDetalleEntity"/></param>
        /// <returns>Verdadero si se guarda.</returns>
        Task<bool> CreateAsync(TblRecepcionDeCompraDetalleEntity detalleRecepcionDeCompra);
        /// <summary>
        /// Actualiza un registro existente de <see cref="TblRecepcionDeCompraDetalleEntity"/>.
        /// </summary>
        /// <param name="detalleRecepcionDeCompra">Objeto de <see cref="TblRecepcionDeCompraDetalleEntity"/></param>
        /// <returns>Verdadero si se actualiza.</returns>
        Task<bool> UpdateAsync(TblRecepcionDeCompraDetalleEntity detalleRecepcionDeCompra);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblRecepcionDeCompraDetalleEntity"/> id.</param>
        /// <returns><see cref="TblRecepcionDeCompraDetalleEntity"/></returns>
        Task<TblRecepcionDeCompraDetalleEntity?> GetDetalleRecepcionDeCompraAsync(Guid id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraDetalleEntity"/>.
        /// </summary>
        /// <returns>Registros de <see cref="TblRecepcionDeCompraDetalleEntity"/></returns>
        Task<IEnumerable<TblRecepcionDeCompraDetalleEntity>> GetDetallesDeRecepcionesDeCompraAsync();
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraDetalleEntity"/> por producto.
        /// </summary>
        /// <param name="producto_id">Id de producto.</param>
        /// <returns>Registros de <see cref="TblRecepcionDeCompraDetalleEntity"/></returns>
        Task<IEnumerable<TblRecepcionDeCompraDetalleEntity>> GetDetallesDeRecepcionesDeCompraPorProductoAsync(Guid producto_id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraDetalleEntity"/> por orden de compra.
        /// </summary>
        /// <param name="recepcion_compra_id">Id de orden de compra.</param>
        /// <returns>Registros de <see cref="TblRecepcionDeCompraDetalleEntity"/></returns>
        Task<IEnumerable<TblRecepcionDeCompraDetalleEntity>> GetDetallesDeRecepcionesDeCompraPorRecepcionAsync(Guid recepcion_compra_id);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblRecepcionDeCompraDetalleEntity"/> con ese id.
        /// </summary>
        /// <param name="id"><see cref="TblRecepcionDeCompraDetalleEntity"/> id.</param>
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
    }
}
