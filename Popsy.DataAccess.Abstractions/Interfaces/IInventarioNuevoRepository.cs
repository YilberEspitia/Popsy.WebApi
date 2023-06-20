using Popsy.Entities;
using Popsy.Enums;
using Popsy.Objects;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone los metodos de la base de datos relacionados con esta entidad: <see cref="TblStockTeoricoInventariosDos"/>.
    /// </summary>
    public interface IInventarioNuevoRepository
    {
        #region Basic Stock Inventario.
        /// <summary>
        /// Guarda un nuevo registro de <see cref="TblStockTeoricoInventariosDos"/>.
        /// </summary>
        /// <param name="stockTeoricoInventario">Objeto de <see cref="TblStockTeoricoInventariosDos"/></param>
        /// <returns>Verdadero si se guarda.</returns>
        Task<Guid> CreateAsync(TblStockTeoricoInventariosDos stockTeoricoInventario);
        /// <summary>
        /// Actualiza un registro existente de <see cref="TblStockTeoricoInventariosDos"/>.
        /// </summary>
        /// <param name="stockTeoricoInventario">Objeto de <see cref="TblStockTeoricoInventariosDos"/></param>
        /// <returns>Id.</returns>
        Task<Boolean> UpdateAsync(TblStockTeoricoInventariosDos stockTeoricoInventario);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblStockTeoricoInventariosDos"/> id.</param>
        /// <returns><see cref="TblStockTeoricoInventariosDos"/></returns>
        Task<TblStockTeoricoInventariosDos?> GetStockTeoricoInventarioAsync(Guid id);
        /// <summary>
        /// Devuelve un registro.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="producto_id">Producto id.</param>
        /// <returns><see cref="TblStockTeoricoInventariosDos"/></returns>
        Task<TblStockTeoricoInventariosDos?> GetStockTeoricoInventarioAsync(Guid punto_venta_id, Guid producto_id);
        #endregion
        #region Basic Stock Fecha.
        /// <summary>
        /// Guarda un nuevo registro de <see cref="TblStockAFechaEntity"/>.
        /// </summary>
        /// <param name="stockFecha">Objeto de <see cref="TblStockAFechaEntity"/></param>
        /// <returns>Id.</returns>
        Task<Guid> CreateAsync(TblStockAFechaEntity stockFecha);
        /// <summary>
        /// Actualiza un registro existente de <see cref="TblStockAFechaEntity"/>.
        /// </summary>
        /// <param name="stockFecha">Objeto de <see cref="TblStockAFechaEntity"/></param>
        /// <returns>Verdadero si se actualiza.</returns>
        Task<Boolean> UpdateAsync(TblStockAFechaEntity stockFecha);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblStockAFechaEntity"/> id.</param>
        /// <returns><see cref="TblStockAFechaEntity"/></returns>
        Task<TblStockAFechaEntity?> GetStockFechaInventarioAsync(Guid id);
        /// <summary>
        /// Devuelve un registro.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="producto_id">Producto id.</param>
        /// <returns><see cref="TblStockAFechaEntity"/></returns>
        Task<TblStockAFechaEntity?> GetStockFechaInventarioAsync(Guid punto_venta_id, Guid producto_id);
        #endregion
        #region Basic Unidad Inventario Dos
        /// <summary>
        /// Guarda un nuevo registro de <see cref="TblUnidadInventarioDos"/>.
        /// </summary>
        /// <param name="unidadInventario">Objeto de <see cref="TblUnidadInventarioDos"/></param>
        /// <returns>Verdadero si se guarda.</returns>
        Task<Guid> CreateUnidadInventarioAsync(TblUnidadInventarioDos unidadInventario);
        /// <summary>
        /// Actualiza un registro existente de <see cref="TblUnidadInventarioDos"/>.
        /// </summary>
        /// <param name="unidadInventario">Objeto de <see cref="TblUnidadInventarioDos"/></param>
        /// <returns>Verdadero si se actualiza.</returns>
        Task<Boolean> UpdateUnidadInventarioAsync(TblUnidadInventarioDos unidadInventario);
        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="TblUnidadInventarioDos"/> id.</param>
        /// <returns><see cref="TblUnidadInventarioDos"/></returns>
        Task<TblUnidadInventarioDos?> GetUnidadInventarioAsync(Guid id);
        /// <summary>
        /// Devuelve un registro.
        /// </summary>
        /// <param name="producto_id">Producto id.</param>
        /// <returns><see cref="TblUnidadInventarioDos"/></returns>
        Task<TblUnidadInventarioDos?> GetUnidadInventarioPorProductoAsync(Guid producto_id);
        #endregion
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblStockTeoricoInventariosDos"/>.
        /// </summary>
        /// <returns>Registros de <see cref="TblStockTeoricoInventariosDos"/></returns>
        Task<IEnumerable<TblStockTeoricoInventariosDos>> GetStockTeoricoInventarioAsync();
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblStockTeoricoInventariosDos"/> por producto.
        /// </summary>
        /// <param name="producto_id">Id de producto.</param>
        /// <returns>Registros de <see cref="TblStockTeoricoInventariosDos"/></returns>
        Task<IEnumerable<TblStockTeoricoInventariosDos>> GetStockTeoricoInventarioPorProductoAsync(Guid producto_id);
        /// <summary>
        /// Devuelve todos los registros de <see cref="TblStockTeoricoInventariosDos"/> por orden de compra.
        /// </summary>
        /// <param name="punto_venta_id">Id del punto de venta.</param>
        /// <returns>Registros de <see cref="TblStockTeoricoInventariosDos"/></returns>
        Task<IEnumerable<TblStockTeoricoInventariosDos>> GetStockTeoricoInventarioPorPuntoAsync(Guid punto_venta_id);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblStockTeoricoInventariosDos"/> con ese id.
        /// </summary>
        /// <param name="id"><see cref="TblStockTeoricoInventariosDos"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<Boolean> ExisteStockAsync(Guid id);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblProductoEntity"/> con ese id.
        /// </summary>
        /// <param name="id"><see cref="TblProductoEntity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<Boolean> ExisteProductoAsync(Guid producto_id);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblProductoEntity"/> con ese código.
        /// </summary>
        /// <param name="codigo">Código de producto.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<Boolean> ExisteProductoAsync(string codigo);
        Task<Guid> GetProductoPorCodigoAsync(string codigo);
        Task<Guid> GetPuntoDeVentaPorCodigoAsync(string codigo);
        Task<IEnumerable<PuntoDeVentaBasicRead>> GetAllPuntosDeVentaAsync();
        Task<UnidadInventarioDosRead?> GetAllUnidadesInventariosPorProductoAsync(Guid producto_id);
        Task<IEnumerable<UnidadInventarioDosRead>> GetAllUnidadesInventariosAsync();

        #region Metodos de inventarios.
        /// <summary>
        /// Crea un registro de inventario.
        /// </summary>
        /// <param name="inventario_base"><see cref="InventarioBaseSave"/> objeto.</param>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="validarCantidades">Indica si se deben validar las cantidades.</param>
        /// <returns><see cref="InventarioCreadoResponse"/> objeto.</returns>
        Task<InventarioCreadoResponse> CreateInventarioBaseAsync(InventarioBaseSave inventario_base, Guid punto_venta_id, Boolean validarCantidades = false);
        /// <summary>
        /// Actualiza un registro de inventario.
        /// </summary>
        /// <param name="inventario_base"><see cref="InventarioBaseUpdate"/> objeto.</param>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns><see cref="InventarioBaseUpdate"/> objeto.</returns>
        Task<InventarioBaseUpdate> UpdateInventarioBaseAsync(InventarioBaseUpdate inventario_base, Guid punto_venta_id);
        /// <summary>
        /// Método que trae el inventario base por un punto de venta.
        /// </summary>
        /// <param name="punto_venta_id">Puedo de venta id.</param>
        /// <returns>Colección de <see cref="InventarioBaseRead"/>.</returns>
        Task<IEnumerable<InventarioBaseRead>> GetInventarioBaseAsync(Guid punto_venta_id);
        /// <summary>
        /// Devuelve los puntos de venta por usuario según su estado.
        /// </summary>
        /// <param name="usuario_id">Usuario id.</param>
        /// <param name="activos">Estado.</param>
        /// <returns>Global ids de los puntos de venta.</returns>
        Task<IEnumerable<Guid>> GetUsuariosPuntosVentasAsync(Guid usuario_id, Boolean activos = false);
        /// <summary>
        /// Verifica si existe una instancia de <see cref="TblInventario2Entity"/> con ese id.
        /// </summary>
        /// <param name="inventario_id"><see cref="TblInventario2Entity"/> id.</param>
        /// <returns>Verdadero si existe, si no retorna falso.</returns>
        Task<Boolean> ExisteAsync(Guid inventario_id);
        /// <summary>
        /// Actualiza el estado de un inventario.
        /// </summary>
        /// <param name="inventario_id">Id de inventario.</param>
        /// <param name="nuevo_estado">Estado a actualizar.</param>
        /// <returns>Verdadero si actualiza, caso contrario devuelve falso.</returns>
        Task<Boolean> UpdateEstadoAsync(Guid inventario_id, SAPEstado nuevo_estado);
        /// <summary>
        /// Trae el inventario a gestionar para envió a SAP.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="fecha_stock">Fecha de inventariado.</param>
        /// <returns><see cref="InventarioGestionSAP"/> objeto.</returns>
        Task<InventarioGestionSAP?> GetInventarioGestionAsync(Guid punto_venta_id, DateTime fecha_stock);
        #endregion
        #region Conteo
        /// <summary>
        /// Devuelve los tickets represados por punto de venta.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns><see cref="TicketsSeguimientoPDVObject"/> objeto.</returns>
        Task<TicketsSeguimientoPDVObject> GetTicketsPDVAsync(Guid punto_venta_id);
        /// <summary>
        /// Guarda un registro de conteo.
        /// </summary>
        /// <param name="inventario_conteo"></param>
        /// <returns></returns>
        Task<Guid> SaveConteoAsync(TblInventarioConteo2Entity inventario_conteo);
        /// <summary>
        /// Actualiza el estado de reconteo.
        /// </summary>
        /// <param name="detalle_id">Id del detalle.</param>
        /// <param name="estado">Nuevo estado para actualizar.</param>
        /// <returns>Verdadero si lo actualiza, de otro modo retorna falso.</returns>
        Task<Boolean> UpdateEstadoReconteoAsync(Guid detalle_id, Boolean estado);
        /// <summary>
        /// Verifica si el inventario requiere reconteo.
        /// </summary>
        /// <param name="inventario_id">Id del inventario.</param>
        /// <returns>Verdadero si requiere reconteo, de otro modo falso.</returns>
        Task<Boolean> RequiereReconteoAsync(Guid inventario_id);
        /// <summary>
        /// Verifica si el detalle de un inventario requiere reconteo.
        /// </summary>
        /// <param name="detalle_id">Id del detalle.</param>
        /// <returns>Verdadero si requiere reconteo, de otro modo falso.</returns>
        Task<Boolean> DetalleRequiereReconteoAsync(Guid detalle_id);
        /// <summary>
        /// Trae el objeto que indica que requiere reconteo.
        /// </summary>
        /// <param name="inventario_id">Id del inventario.</param>
        /// <returns><see cref="InventarioReconteoObject"/> objeto.</returns>
        Task<InventarioReconteoObject?> GetInventarioReconteoAsync(Guid inventario_id);
        /// <summary>
        /// Reliza el reconteo de todos los detalles del inventario.
        /// </summary>
        /// <param name="reconteos">Colección de <see cref="InventarioConteoSave"/></param>
        /// <returns>Colección de <see cref="InventarioConteoRead"/></returns>
        Task<IEnumerable<InventarioConteoRead>> ReconteoAsync(IEnumerable<InventarioConteoSave> reconteos);
        /// <summary>
        /// Trae el historial de reconteos por historial.
        /// </summary>
        /// <param name="inventario_id">Inventario id.</param>
        /// <returns><see cref="InventarioReconteoExportable"/> objeto.</returns>
        Task<InventarioReconteoExportable?> GetReconteosAsync(Guid inventario_id);
        #endregion
    }
}
