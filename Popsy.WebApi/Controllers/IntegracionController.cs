using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Controllers
{
    /// <summary>
    /// Controlador de integración.
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "UserSIPOP")]
    [Route("api/[controller]")]
    public class IntegracionController : ControllerBase
    {
        private readonly IIntegraciones _repoIntegraciones;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repoIntegraciones"><see cref="IIntegraciones"/> instancia.</param>
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