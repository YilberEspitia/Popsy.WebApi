using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Controllers
{
    /// <summary>
    /// Controlador para la gestión del super usuario.
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "SuperUserSIPOP")]
    [Route("api/[controller]")]
    public class SuperUsuarioController : ControllerBase
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly ISuperUsuarioBusiness _business;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="applicationLifetime"><see cref="IHostApplicationLifetime"/> instancia.</param>
        /// <param name="business"><see cref="ISuperUsuarioBusiness"/> instancia.</param>
        public SuperUsuarioController(IHostApplicationLifetime applicationLifetime, ISuperUsuarioBusiness business)
        {
            _applicationLifetime = applicationLifetime;
            _business = business;
        }

        /// <summary>
        /// Crea un registro de inventario.
        /// </summary>
        /// <param name="inventario_base"><see cref="InventarioBaseSave"/> objeto.</param>
        /// <param name="punto_venta_id">Punto de venta id.</param>
        /// <returns><see cref="InventarioResponse"/> objeto.</returns>
        [HttpPost("CreateInventarioBase/{punto_venta_id}")]
        public async Task<ActionResult<InventarioResponse>> CreateInventarioBaseAsync(Guid punto_venta_id, [FromBody] InventarioBaseSave inventario_base)
            => await _business.CreateInventarioBaseAsync(inventario_base, punto_venta_id);
        /// <summary>
        /// Detiene el servicio
        /// </summary>
        [HttpPost("stop")]
        public IActionResult StopService()
        {
            Task.Run(() =>
            {
                // Espera 5 segundos para permitir que la respuesta se envíe correctamente
                Thread.Sleep(5000);
                // Detiene la aplicación
                _applicationLifetime.StopApplication();
            });
            return Ok("El servicio se detendrá en breve.");
        }
    }
}
