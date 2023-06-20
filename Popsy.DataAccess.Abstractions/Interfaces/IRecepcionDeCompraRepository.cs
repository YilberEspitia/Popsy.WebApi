using Popsy.Entities;
using Popsy.Enums;
using Popsy.Objects;

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
        Task<Guid> CreateAsync(TblRecepcionDeCompraEntity recepcionDeCompra);
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
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblRecepcionDeCompraEntity"/> id.</param>
        /// <param name="estado">Estado.</param>
        /// <returns><see cref="TblRecepcionDeCompraEntity"/></returns>
        Task<TblRecepcionDeCompraEntity?> GetRecepcionDeCompraAsync(Guid id, SAPEstado estado);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraEntity"/>.
        /// </summary>
        /// <returns>Registros de <see cref="TblRecepcionDeCompraEntity"/></returns>
        Task<IEnumerable<TblRecepcionDeCompraEntity>> GetRecepcionesDeComprasAsync();
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblRecepcionDeCompraEntity"/> por detalle de orden de compra.
        /// </summary>
        /// <param name="orden_compra_id">Id de orden de compra.</param>
        /// <returns>Registros de <see cref="TblRecepcionDeCompraEntity"/></returns>
        Task<IEnumerable<TblRecepcionDeCompraEntity>> GetRecepcionesDeComprasPorDetalleAsync(Guid orden_compra_id);
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
        /// <summary>
        /// Guarda un nuevo registro de <see cref="TblResponseRecepcionDeCompraEntity"/>.
        /// </summary>
        /// <param name="responseRecepcionDeCompra">Objeto de <see cref="TblResponseRecepcionDeCompraEntity"/></param>
        /// <returns>Verdadero si se guarda.</returns>
        Task<bool> CreateAsync(TblResponseRecepcionDeCompraEntity responseRecepcionDeCompra);
        /// <summary>
        /// Actualiza el estado de una recepción de compra.
        /// </summary>
        /// <param name="recepcion_compra_id">Recepción de compra id.</param>
        /// <param name="nuevo_estado">Estado a actualizar.</param>
        /// <returns>Verdadero si actualiza, caso contrario devuelve falso.</returns>
        Task<bool> UpdateEstadoAsync(Guid recepcion_compra_id, SAPEstado nuevo_estado);
        /// <summary>
        /// Actualiza el estado del response recepción de compra.
        /// </summary>
        /// <param name="recepcion_compra_id">Recepción de compra id.</param>
        /// <param name="activo">Estado a actualizar.</param>
        /// <returns>Verdadero si actualiza, caso contrario devuelve falso.</returns>
        Task UpdateEstadoResponseAsync(Guid recepcion_compra_id, Boolean activo);
        /// <summary>
        /// Devuelve la información básica de las recepciones pendientes.
        /// </summary>
        /// <returns>Colección de <see cref="PendientesBasicObject"/></returns>
        Task<IEnumerable<PendientesBasicObject>> GetPendientesBasic();
        /// <summary>
        /// Crea un registro de historial de envio a SAP.
        /// </summary>
        /// <param name="historial"><see cref="TblHistorialEnvioRecepcionDeCompraEntity"/> objeto.</param>
        /// <returns>Verdadero si crea, de otro modo retorna falso.</returns>
        Task<Boolean> CrearHistorialAsync(TblHistorialEnvioRecepcionDeCompraEntity historial);
        /// <summary>
        /// Devuelve el último registro de historial de envio a SAP.
        /// </summary>
        /// <param name="recepcion_compra_id">Recepción de compra id.</param>
        /// <returns><see cref="TblHistorialEnvioRecepcionDeCompraEntity"/> objeto.</returns>
        Task<TblHistorialEnvioRecepcionDeCompraEntity?> GetUltimoHistorial(Guid recepcion_compra_id);
        /// <summary>
        /// Devuelve el último registro de historial de envio a SAP.
        /// </summary>
        /// <param name="recepcion_compra_id">Recepción de compra id.</param>
        /// <returns>XML.</returns>
        Task<String?> GetUltimoXml(Guid recepcion_compra_id);
    }
}
