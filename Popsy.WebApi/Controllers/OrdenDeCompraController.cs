using Microsoft.AspNetCore.Mvc;

using Popsy.Interfaces;
using Popsy.Objects;

namespace WebApiIntegracion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenDeCompraController : ControllerBase
    {
        private readonly IProveedorRecepcionBusiness _proveedor;

        public OrdenDeCompraController(IProveedorRecepcionBusiness proveedor)
        {
            _proveedor = proveedor;
        }
        [HttpPost("CrearProveedor")]
        public async Task<ActionResult<bool>> CreateAsync([FromBody] ProveedorRecepcionObject ordenDeCompra)
            => await _proveedor.CreateAsync(ordenDeCompra);

        [HttpGet("GetProveedorPorId/{id}")]
        public async Task<ActionResult<ProveedorRecepcionObject>> GetProveedorRecepcionAsync(Guid id)
            => await _proveedor.GetProveedorRecepcionAsync(id);

        [HttpGet("GetProveedorPorSap/{codigoSap}")]
        public async Task<ActionResult<ProveedorRecepcionObject>> GetProveedorRecepcionAsync(String codigoSap)
            => await _proveedor.GetProveedorRecepcionAsync(codigoSap);

        [HttpGet("GetProveedores")]
        public async Task<IEnumerable<ProveedorRecepcionObject>> GetProveedoresRecepcionAsync()
            => await _proveedor.GetProveedoresRecepcionAsync();
    }
}