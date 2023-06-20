using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Controllers
{
    /// <summary>
    /// Controlador de ordenes de inventario nuevo.
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "UserSIPOP")]
    [Route("api/[controller]")]
    public class InventarioNuevoController : ControllerBase
    {
        /// <summary>
        /// <see cref="IInventarioNuevoBusiness"/> negocio.
        /// </summary>
        private readonly IInventarioNuevoBusiness _business;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="business"><see cref="IInventarioNuevoBusiness"/> instancia.</param>
        public InventarioNuevoController(IInventarioNuevoBusiness business)
        {
            _business = business;
        }

        #region Metodos de inventarios
        /// <summary>
        /// Crea un registro de inventario.
        /// </summary>
        /// <param name="inventario_base"><see cref="InventarioBaseSave"/> objeto.</param>
        /// <returns><see cref="InventarioResponse"/> objeto.</returns>
        [HttpPost("CreateInventarioBase")]
        public async Task<ActionResult<InventarioResponse>> CreateInventarioBaseAsync([FromBody] InventarioBaseSave inventario_base)
            => await _business.CreateInventarioBaseAsync(inventario_base);
        /// <summary>
        /// Verifica si el inventario requiere reconteo.
        /// </summary>
        /// <param name="inventario_id">Id del inventario.</param>
        /// <returns>Verdadero si requiere reconteo, de otro modo falso.</returns>
        [HttpGet("RequiereReconteo/{inventario_id}")]
        public async Task<ActionResult<Boolean>> RequiereReconteoAsync(Guid inventario_id)
            => await _business.RequiereReconteoAsync(inventario_id);
        /// <summary>
        /// Trae el objeto que indica que requiere reconteo.
        /// </summary>
        /// <param name="inventario_id">Id del inventario.</param>
        /// <returns><see cref="InventarioReconteoObject"/> objeto.</returns>
        [HttpGet("GetInventarioReconteo/{inventario_id}")]
        public async Task<InventarioReconteoObject> GetInventarioReconteoAsync(Guid inventario_id)
            => await _business.GetInventarioReconteoAsync(inventario_id);
        /// <summary>
        /// Trae el historial de reconteos por historial.
        /// </summary>
        /// <param name="inventario_id">Inventario id.</param>
        /// <returns><see cref="InventarioReconteoExportable"/> objeto.</returns>
        [HttpGet("GetReconteos/{inventario_id}")]
        public async Task<InventarioReconteoExportable> GetReconteosAsync(Guid inventario_id)
            => await _business.GetReconteosAsync(inventario_id);
        /// <summary>
        /// Hace un reconteo por inventario.
        /// </summary>
        /// <param name="inventarioReconteo"><see cref="InventarioReconteoSave"/> objeto.</param>
        /// <returns><see cref="InventarioReconteoRead"/> objeto.</returns>
        [HttpPost("Reconteo")]
        public async Task<InventarioReconteoRead> ReconteoAsync([FromBody] InventarioReconteoSave inventarioReconteo)
            => await _business.ReconteoAsync(inventarioReconteo);
        /// <summary>
        /// Actualiza un registro de inventario.
        /// </summary>
        /// <param name="inventario_base"><see cref="InventarioBaseUpdate"/> objeto.</param>
        /// <returns><see cref="InventarioBaseUpdate"/> objeto.</returns>
        [HttpPost("UpdateInventarioBase")]
        public async Task<ActionResult<InventarioBaseUpdate>> UpdateInventarioBaseAsync([FromBody] InventarioBaseUpdate inventario_base)
            => await _business.UpdateInventarioBaseAsync(inventario_base);
        /// <summary>
        /// Método que trae el inventario base por un punto de venta.
        /// </summary>
        /// <param name="punto_venta_id">Puedo de venta id.</param>
        /// <returns>Colección de <see cref="InventarioBaseRead"/>.</returns>
        [HttpGet]
        [Route("GetInventarioBase")]
        public async Task<ActionResult<IEnumerable<InventarioBaseRead>>> GetInventarioBase(Guid punto_venta_id)
            => Ok(await _business.GetInventarioBaseAsync(punto_venta_id));
        /// <summary>
        /// Método que devuelve todas las unidades de invetarios por producto.
        /// </summary>
        /// <param name="producto_id">Producto id.</param>
        /// <returns><see cref="UnidadInventarioDosRead"/> objeto.</returns>

        [HttpGet("GetUnidadesDeInventarios/{producto_id}")]
        public async Task<ActionResult<UnidadInventarioDosRead>> GetAllUnidadesInventariosPorProducto(Guid producto_id)
            => await _business.GetAllUnidadesInventariosPorProductoAsync(producto_id);
        /// <summary>
        /// Método que devuelve todas las unidades de invetarios.
        /// </summary>
        /// <returns><see cref="UnidadInventarioDosRead"/> objeto.</returns>

        [HttpGet("GetUnidadesDeInventarios")]
        public async Task<ActionResult<IEnumerable<UnidadInventarioDosRead>>> GetAllUnidadesInventarios()
            => Ok(await _business.GetAllUnidadesInventariosAsync());
        /// <summary>
        /// Método para traer el encabezado de inventario por usuario.
        /// </summary>
        /// <param name="usuario_id">Usuario id.</param>
        /// <returns><see cref="EncabezadoInventarioRead"/> objeto.</returns>
        [HttpGet("GetEncabezadoInventario/{usuario_id}")]
        public async Task<ActionResult<EncabezadoInventarioRead>> GetEncabezadoInventarioAsync(Guid usuario_id)
            => await _business.GetEncabezadoInventarioAsync(usuario_id);
        #endregion

        #region Integraciones
        /// <summary>
        /// Metodo por demanda para sincronizar stock de inventario teorico.
        /// </summary>
        /// <returns>Sap response.</returns>
        [HttpGet("SyncStockTeoricoInventario")]
        public async Task<ActionResult<IEnumerable<ResponsePuntoDeVentaPopsySAP>>> SyncSAPAsync()
            => Ok(await _business.SyncSAPAsync());
        /// <summary>
        /// Metodo por demanda para sincronizar stock de inventario teorico.
        /// </summary>
        /// <returns>Sap response.</returns>
        [HttpGet("SyncStockFecha")]
        public async Task<ActionResult<IEnumerable<ResponsePuntoDeVentaPopsySAP>>> SyncStockFechaAsync()
            => Ok(await _business.SyncStockFechaAsync());
        /// <summary>
        /// Metodo por demanda para sincronizar unidades de inventarios.
        /// </summary>
        /// <returns>Sap response.</returns>
        [HttpGet("SyncUnidadesDeInventarios")]
        public async Task<ActionResult<IEnumerable<ResponsePopsySAP>>> SyncUnidadesDeInventariosSAPAsync()
            => Ok(await _business.SyncUnidadesDeInventariosSAPAsync());
        #endregion
    }
}