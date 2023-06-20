using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface IRecepcionDeCompraBusiness
    {
        #region RecepcionDeCompra
        /// <summary>
        /// Guarda o actualiza registro de <see cref="TblRecepcionDeCompraEntity"/>.
        /// </summary>
        /// <param name="recepcionDeCompra">Objeto de <see cref="RecepcionDeCompraSave"/></param>
        /// <returns>Verdadero si se guarda, falso si actualiza.</returns>
        Task<string> CreateAsync(RecepcionDeCompraSave recepcionDeCompra);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblRecepcionDeCompraEntity"/> id.</param>
        /// <returns><see cref="RecepcionDeCompraRead"/></returns>
        Task<RecepcionDeCompraRead> GetRecepcionDeCompraAsync(Guid id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraEntity"/>.
        /// </summary>
        /// <returns>Registros de <see cref="RecepcionDeCompraRead"/></returns>
        Task<IEnumerable<RecepcionDeCompraRead>> GetRecepcionesDeComprasAsync();
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraEntity"/> por detalle de orden de compra.
        /// </summary>
        /// <param name="detalle_orden_compra_id">Id de detalle de orden de compra.</param>
        /// <returns>Registros de <see cref="RecepcionDeCompraRead"/></returns>
        Task<IEnumerable<RecepcionDeCompraRead>> GetRecepcionesDeComprasPorDetalleAsync(Guid detalle_orden_compra_id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraEntity"/> por codigo de recepción.
        /// </summary>
        /// <param name="codigo">Codigo de recepcion.</param>
        /// <returns>Registros de <see cref="RecepcionDeCompraRead"/></returns>
        Task<IEnumerable<RecepcionDeCompraRead>> GetRecepcionesDeComprasPorCodigoAsync(string codigo);
        #endregion
    }
}
