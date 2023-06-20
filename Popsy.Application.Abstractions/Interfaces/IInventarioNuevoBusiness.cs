using Popsy.Objects;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Interfaz que expone la lógica de negocio relacionada con el nuevo modulo de inventarios.
    /// </summary>
    public interface IInventarioNuevoBusiness
    {
        #region Integraciones
        /// <summary>
        /// Metodo que sincroniza el stock teorico.
        /// </summary>
        /// <returns>Response de la sincronización.</returns>
        Task<IEnumerable<ResponsePuntoDeVentaPopsySAP>> SyncSAPAsync();
        /// <summary>
        /// Metodo que sincroniza el stock a fecha.
        /// </summary>
        /// <returns>Response de la sincronización.</returns>
        Task<IEnumerable<ResponsePuntoDeVentaPopsySAP>> SyncStockFechaAsync();
        /// <summary>
        /// Metodo que sincroniza las unidades de inventarios.
        /// </summary>
        /// <returns>Response de la sincronización.</returns>
        Task<IEnumerable<ResponsePopsySAP>> SyncUnidadesDeInventariosSAPAsync();
        /// <summary>
        /// Metodo que devuelve todas las unidades de invetarios por producto.
        /// </summary>
        /// <param name="producto_id">Producto id.</param>
        /// <returns><see cref="UnidadInventarioDosRead"/> objeto.</returns>
        Task<UnidadInventarioDosRead> GetAllUnidadesInventariosPorProductoAsync(Guid producto_id);
        /// <summary>
        /// Metodo que devuelve todas las unidades de invetarios.
        /// </summary>
        /// <returns><see cref="UnidadInventarioDosRead"/> objeto.</returns>
        Task<IEnumerable<UnidadInventarioDosRead>> GetAllUnidadesInventariosAsync();
        #endregion

        #region Metodos de inventarios
        /// <summary>
        /// Crea un registro de inventario.
        /// </summary>
        /// <param name="inventario_base"><see cref="InventarioBaseSave"/> objeto.</param>
        /// <returns><see cref="InventarioResponse"/> objeto.</returns>
        Task<InventarioResponse> CreateInventarioBaseAsync(InventarioBaseSave inventario_base);
        /// <summary>
        /// Actualiza un registro de inventario.
        /// </summary>
        /// <param name="inventario_base"><see cref="InventarioBaseUpdate"/> objeto.</param>
        /// <returns><see cref="InventarioBaseUpdate"/> objeto.</returns>
        Task<InventarioBaseUpdate> UpdateInventarioBaseAsync(InventarioBaseUpdate inventario_base);
        /// <summary>
        /// Método que trae el inventario base por un punto de venta.
        /// </summary>
        /// <param name="punto_venta_id">Puedo de venta id.</param>
        /// <returns>Colección de <see cref="InventarioBaseRead"/>.</returns>
        Task<IEnumerable<InventarioBaseRead>> GetInventarioBaseAsync(Guid punto_venta_id);
        /// <summary>
        /// Método para traer el encabezado de inventario por usuario.
        /// </summary>
        /// <param name="usuario_id">Usuario id.</param>
        /// <returns><see cref="EncabezadoInventarioRead"/> objeto.</returns>
        Task<EncabezadoInventarioRead> GetEncabezadoInventarioAsync(Guid usuario_id);
        /// <summary>
        /// Verifica si el inventario requiere reconteo.
        /// </summary>
        /// <param name="inventario_id">Id del inventario.</param>
        /// <returns>Verdadero si requiere reconteo, de otro modo falso.</returns>
        Task<Boolean> RequiereReconteoAsync(Guid inventario_id);
        /// <summary>
        /// Trae el objeto que indica que requiere reconteo.
        /// </summary>
        /// <param name="inventario_id">Id del inventario.</param>
        /// <returns><see cref="InventarioReconteoObject"/> objeto.</returns>
        Task<InventarioReconteoObject> GetInventarioReconteoAsync(Guid inventario_id);
        /// <summary>
        /// Hace un reconteo por inventario.
        /// </summary>
        /// <param name="inventarioReconteo"><see cref="InventarioReconteoSave"/> objeto.</param>
        /// <returns><see cref="InventarioReconteoRead"/> objeto.</returns>
        Task<InventarioReconteoRead> ReconteoAsync(InventarioReconteoSave inventarioReconteo);
        /// <summary>
        /// Trae el historial de reconteos por historial.
        /// </summary>
        /// <param name="inventario_id">Inventario id.</param>
        /// <returns><see cref="InventarioReconteoExportable"/> objeto.</returns>
        Task<InventarioReconteoExportable> GetReconteosAsync(Guid inventario_id);
        #endregion
    }
}
