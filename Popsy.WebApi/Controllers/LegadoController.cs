using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Controllers
{
    /// <summary>
    /// Controlador de ordenes de compra.
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "ControlInventarios")]
    [Route("api/[controller]")]
    public class LegadoController : ControllerBase
    {
        /// <summary><see cref="ILegadoBusiness"/> instancia.</summary>
        private readonly ILegadoBusiness _business;
        /// <summary><see cref="IProcedimientoAlmacenadoBusiness"/> instancia.</summary>
        private readonly IProcedimientoAlmacenadoBusiness _procedimientos;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="business"><see cref="ILegadoBusiness"/> instancia.</param>
        /// <param name="procedimientos"><see cref="IProcedimientoAlmacenadoBusiness"/> instancia.</param>
        public LegadoController(ILegadoBusiness business, IProcedimientoAlmacenadoBusiness procedimientos)
        {
            _business = business;
            _procedimientos = procedimientos;
        }

        /// <summary>
        /// Devuelve todos los seguimientos de los puntos de venta.
        /// </summary>
        /// <returns>Colección de <see cref="SeguimientoPDVObject"/> objeto.</returns>
        [HttpGet("GetSeguimientosPDV")]
        public async Task<ActionResult<IEnumerable<SeguimientoPDVObject>>> GetSeguimientoPDVsAsync()
        {
            await _procedimientos.ProcedimientoSeguimientoPDV();
            return Ok(await _business.GetSeguimientoPDVsAsync());
        }
        /// <summary>
        /// Devuelve los detalles de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns>Colección de <see cref="DetalleSeguimientoPDVObject"/> objeto.</returns>
        [HttpGet("GetSeguimientoPDVDetalle/{punto_venta_id}")]
        public async Task<ActionResult<IEnumerable<DetalleSeguimientoPDVObject>>> GetSeguimientoPDVDetalleAsync(Guid punto_venta_id)
            => Ok(await _business.GetSeguimientoPDVDetalleAsync(punto_venta_id));
        /// <summary>
        /// Devuelve los detalles de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="tipo">Tipo.</param>
        /// <returns>Colección de <see cref="DetalleSeguimientoPDVObject"/> objeto.</returns>
        [HttpGet("GetSeguimientoPDVDetalle/{punto_venta_id}/{tipo}")]
        public async Task<ActionResult<IEnumerable<DetalleSeguimientoPDVObject>>> GetSeguimientoPDVDetalleAsync(Guid punto_venta_id, SAPType tipo)
            => Ok(await _business.GetSeguimientoPDVDetalleAsync(punto_venta_id, tipo));
        /// <summary>
        /// Devuelve los detalles de un seguimiento.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="id">Id del tipo.</param>
        /// <param name="tipo">Tipo.</param>
        /// <returns><see cref="DetalleSeguimientoPDVObject"/> objeto.</returns>
        [HttpGet("GetSeguimientoPDVDetalle/{punto_venta_id}/{tipo}/{id}")]
        public async Task<ActionResult<DetalleSeguimientoPDVObject>> GetSeguimientoPDVDetalleAsync(Guid punto_venta_id, Guid id, SAPType tipo)
            => await _business.GetSeguimientoPDVDetalleAsync(punto_venta_id, id, tipo);
        /// <summary>
        /// Actualiza el estado de un tipo de comunicación con SAP.
        /// </summary>
        /// <param name="id">Id del tipo.</param>
        /// <param name="tipo">Tipo.</param>
        /// <param name="nuevo_estado">Estado a actualizar.</param>
        /// <returns>Verdadero si actualiza, caso contrario devuelve falso.</returns>
        [HttpPost("UpdateEstado/{id}/{tipo}/{nuevo_estado}")]
        public async Task<ActionResult<bool>> UpdateEstadoAsync(Guid id, SAPType tipo, SAPEstado nuevo_estado)
            => await _business.UpdateEstadoAsync(id, tipo, nuevo_estado);
        /// <summary>
        /// Envia manualmente la recepción de compra a SAP.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="recepcion_compra_id">Recepción de compra id.</param>
        /// <returns><see cref="ResponseRecepcionDeCompraObject"/> response.</returns>
        [HttpPost("EnviarRecepcionDeCompra/{punto_venta_id}/{recepcion_compra_id}")]
        public async Task<ActionResult<ResponseRecepcionDeCompraXMLObject>> EnviarRecepcionDeCompra(Guid punto_venta_id, Guid recepcion_compra_id)
            => Ok(await _business.EnviarRecepcionDeCompra(punto_venta_id, recepcion_compra_id));
        /// <summary>
        /// Envia manualmente las recepciones de compras a SAP.
        /// </summary>
        /// <returns><see cref="ResponseRecepcionDeCompraXMLTotalObject"/> response.</returns>
        [HttpPost("EnviarRecepcionesDeCompra")]
        public async Task<ActionResult<ResponseRecepcionDeCompraXMLTotalObject>> EnviarRecepcionesDeCompra()
            => Ok(await _business.EnviarRecepcionesDeCompra());
        /// <summary>
        /// Gestiona y compara los stocks por fecha.
        /// </summary>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <param name="fecha_stock">Fecha a comparar.</param>
        /// <returns><see cref="InventarioGestionSAP"/> objeto.</returns>
        [HttpGet("GestionarStock/{punto_venta_id}/{fecha_stock}")]
        public async Task<ActionResult<InventarioGestionSAP>> GestionarStockAsync(Guid punto_venta_id, DateTime fecha_stock)
            => await _business.GestionarStockAsync(punto_venta_id, fecha_stock);
    }
}