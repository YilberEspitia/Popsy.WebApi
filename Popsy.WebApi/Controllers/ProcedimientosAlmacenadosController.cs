using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Popsy.Common;
using Popsy.Interfaces;

namespace Popsy.Controllers
{
    /// <summary>
    /// Controlador para ejecutar procedimientos almacenados.
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "UserSIPOP")]
    [Route("api/[controller]")]
    public class ProcedimientosAlmacenados : ControllerBase
    {
        private readonly IProcedimientoAlmacenadoBusiness _procedimientos;

        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="procedimientos">Procedimientos almacenados.</param>
        public ProcedimientosAlmacenados(IProcedimientoAlmacenadoBusiness procedimientos)
        {
            _procedimientos = procedimientos;
        }
        /// <summary>
        /// Ejecuta un procedimiento almacenado.
        /// </summary>
        /// <param name="storedProcName">El nombre del procedimiento almacenado.</param>
        [HttpPost("EjecutarProcedimientoAlmacenado/{storedProcName}")]
        public async Task<IActionResult> ExecuteStoredProc(string storedProcName)
        {
            await _procedimientos.ExecuteStoredProc(storedProcName);
            return Ok("Procedimiento almacenado ejecutado correctamente");
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado ProcedimientoSeguimientoPDV.
        /// </summary>
        [HttpPost("ProcedimientoSeguimientoPDV")]
        public async Task<IActionResult> ProcedimientoSeguimientoPDV()
        {
            int filasAfectadas = await _procedimientos.ProcedimientoSeguimientoPDV();
            return Ok(String.Format(PopsyConstants.ProcedimientoOk, filasAfectadas));
        }
    }
}