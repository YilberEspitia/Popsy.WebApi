using Popsy.Entities;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone los metodos de la base de datos relacionados con esta entidad: <see cref="TblProveedorRecepcionEntity"/>.
    /// </summary>
    public interface IProveedorRecepcionRepository
    {
        /// <summary>
        /// Guarda un nuevo registro de <see cref="TblProveedorRecepcionEntity"/>.
        /// </summary>
        /// <param name="proveedorRecepcion">Objeto de <see cref="TblProveedorRecepcionEntity"/></param>
        /// <returns>Verdadero si se guarda.</returns>
        Task<bool> CreateAsync(TblProveedorRecepcionEntity proveedorRecepcion);
        /// <summary>
        /// Actualiza un registro existente de <see cref="TblProveedorRecepcionEntity"/>.
        /// </summary>
        /// <param name="proveedorRecepcion">Objeto de <see cref="TblProveedorRecepcionEntity"/></param>
        /// <returns>Verdadero si se actualiza.</returns>
        Task<bool> UpdateAsync(TblProveedorRecepcionEntity proveedorRecepcion);
        /// <summary>
        /// Devuelve un registro por codigo sap.
        /// </summary>
        /// <param name="codigoSap"><see cref="TblProveedorRecepcionEntity"/> codigo sap.</param>
        /// <returns><see cref="TblProveedorRecepcionEntity"/></returns>
        Task<TblProveedorRecepcionEntity?> GetProveedorRecepcionAsync(String codigoSap);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblProveedorRecepcionEntity"/> id.</param>
        /// <returns><see cref="TblProveedorRecepcionEntity"/></returns>
        Task<TblProveedorRecepcionEntity?> GetProveedorRecepcionAsync(Guid id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblProveedorRecepcionEntity"/>.
        /// </summary>
        /// <returns>Registros de <see cref="TblProveedorRecepcionEntity"/></returns>
        Task<IEnumerable<TblProveedorRecepcionEntity>> GetProveedoresRecepcionAsync();
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblProveedorRecepcionEntity"/> con ese id.
        /// </summary>
        /// <param name="id"><see cref="TblProveedorRecepcionEntity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<bool> ExisteAsync(Guid id);
    }
}
