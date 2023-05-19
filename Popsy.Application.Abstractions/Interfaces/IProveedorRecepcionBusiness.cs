using Popsy.Entities;
using Popsy.Enums;
using Popsy.Objects;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone la lógica de negocio relacionada con la entidad <see cref="TblProveedorRecepcionEntity"/>.
    /// </summary>
    public interface IProveedorRecepcionBusiness
    {
        /// <summary>
        /// Guarda o actualiza registro de <see cref="ProveedorRecepcionObject"/>.
        /// </summary>
        /// <param name="proveedor">Objeto de <see cref="ProveedorRecepcionObject"/></param>
        /// <returns>Verdadero si se guarda, falso si actualiza.</returns>
        Task<AccionesBD> CreateAsync(ProveedorRecepcionObject proveedor);
        /// <summary>
        /// Devuelve un registro por codigo sap.
        /// </summary>
        /// <param name="codigoSap"><see cref="TblProveedorRecepcionEntity"/> codigo sap.</param>
        /// <returns><see cref="ProveedorRecepcionObject"/></returns>
        Task<ProveedorRecepcionObject> GetProveedorRecepcionAsync(String codigoSap);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblProveedorRecepcionEntity"/> id.</param>
        /// <returns><see cref="ProveedorRecepcionObject"/></returns>
        Task<ProveedorRecepcionObject> GetProveedorRecepcionAsync(Guid id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblProveedorRecepcionEntity"/>.
        /// </summary>
        /// <returns>Registros de <see cref="ProveedorRecepcionObject"/></returns>
        Task<IEnumerable<ProveedorRecepcionObject>> GetProveedoresRecepcionAsync();
        Task<IEnumerable<ResponsePopsySAP>> SyncSAPAsync();
    }
}
