using Microsoft.AspNetCore.Mvc;

using Popsy.Interfaces;
using Popsy.Objects;

namespace WebApiIntegracion.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class IntegracionController : ControllerBase
    {
        private readonly IIntegraciones _repoIntegraciones;
        public IntegracionController(IIntegraciones repoIntegraciones)
        {
            _repoIntegraciones = repoIntegraciones;
        }

        /// <summary>
        /// Hace todos los calculos para enviar a SAP
        /// </summary>
        /// <remarks>
        /// Retorna toda la información de SAP pedido = bc75c0db-e6c8-ed11-8927-34735a9c3f29 
        /// Es el encabezado del inventario 
        /// </remarks>
        [HttpGet]
        [Route("GetRespuestaPedidoSAPIntegracion")]
        public async Task<IActionResult> GetRespuestaPedidoSAPIntegracion(Guid pedido_id)
        {
            RespuestaServicioEntity respuesta = new RespuestaServicioEntity();
            respuesta = await _repoIntegraciones.GetRespuestaPedidoSAPIntegracion(pedido_id);
            return Ok(respuesta);
        }
    }
}