using Popsy.Entities;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone los metodos de la base de datos relacionados con esta entidad: <see cref="TblRecepcionDeCompraEntity"/>.
    /// </summary>
    public interface IRecepcionDeCompraRepository
    {
        /// <summary>
        /// Guarda un nuevo registro de <see cref="TblRecepcionDeCompraEntity"/>.
        /// </summary>
        /// <param name="recepcionDeCompra">Objeto de <see cref="TblRecepcionDeCompraEntity"/></param>
        /// <returns>Verdadero si se guarda.</returns>
        Task<bool> CreateAsync(TblRecepcionDeCompraEntity recepcionDeCompra);
        /// <summary>
        /// Actualiza un registro existente de <see cref="TblRecepcionDeCompraEntity"/>.
        /// </summary>
        /// <param name="recepcionDeCompra">Objeto de <see cref="TblRecepcionDeCompraEntity"/></param>
        /// <returns>Verdadero si se actualiza.</returns>
        Task<bool> UpdateAsync(TblRecepcionDeCompraEntity recepcionDeCompra);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblRecepcionDeCompraEntity"/> id.</param>
        /// <returns><see cref="TblRecepcionDeCompraEntity"/></returns>
        Task<TblRecepcionDeCompraEntity?> GetRecepcionDeCompraAsync(Guid id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraEntity"/>.
        /// </summary>
        /// <returns>Registros de <see cref="TblRecepcionDeCompraEntity"/></returns>
        Task<IEnumerable<TblRecepcionDeCompraEntity>> GetRecepcionesDeComprasAsync();
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraEntity"/> por detalle de orden de compra.
        /// </summary>
        /// <param name="detalle_orden_compra_id">Id de detalle de orden de compra.</param>
        /// <returns>Registros de <see cref="TblRecepcionDeCompraEntity"/></returns>
        Task<IEnumerable<TblRecepcionDeCompraEntity>> GetRecepcionesDeComprasPorDetalleAsync(Guid detalle_orden_compra_id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraEntity"/> por codigo de recepción.
        /// </summary>
        /// <param name="codigo">Codigo de recepcion.</param>
        /// <returns>Registros de <see cref="TblRecepcionDeCompraEntity"/></returns>
        Task<IEnumerable<TblRecepcionDeCompraEntity>> GetRecepcionesDeComprasPorCodigoAsync(string codigo);
        /// <summary>
        /// Devuelve el número de constante del último registro.
        /// </summary>
        /// <returns>Última constante.</returns>
        Task<int> GetConstante();
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblRecepcionDeCompraEntity"/> con ese id.
        /// </summary>
        /// <param name="id"><see cref="TblRecepcionDeCompraEntity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<bool> ExisteAsync(Guid id);
    }
}
