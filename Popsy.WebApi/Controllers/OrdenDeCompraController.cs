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
        private readonly IOrdenDeCompraBusiness _ordenDeCompra;

        public OrdenDeCompraController(IProveedorRecepcionBusiness proveedor, IOrdenDeCompraBusiness ordenDeCompra)
        {
            _proveedor = proveedor;
            _ordenDeCompra = ordenDeCompra;
        }

        #region Proveedor
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
        #endregion

        #region OrdenDeCompra
        [HttpPost("CrearOrden")]
        public async Task<ActionResult<bool>> CreateAsync([FromBody] OrdenDeCompraSave ordenDeCompra)
            => await _ordenDeCompra.CreateAsync(ordenDeCompra);

        [HttpGet("GetOrdenDeCompra/{id}")]
        public async Task<ActionResult<OrdenDeCompraRead>> GetOrdenDeCompraAsync(Guid id)
            => await _ordenDeCompra.GetOrdenDeCompraAsync(id);

        [HttpGet("GetOrdenesDeCompra")]
        public async Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraAsync()
            => await _ordenDeCompra.GetOrdenesDeCompraAsync();

        [HttpGet("GetOrdenesDeCompraPorProveedor/{proveedor_recepcion_id}")]
        public async Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraPorProveedorAsync(Guid proveedor_recepcion_id)
            => await _ordenDeCompra.GetOrdenesDeCompraPorProveedorAsync(proveedor_recepcion_id);

        [HttpGet("GetOrdenesDeCompraPorPunto/{punto_venta_id}")]
        public async Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraPorPuntoAsync(Guid punto_venta_id)
            => await _ordenDeCompra.GetOrdenesDeCompraPorPuntoAsync(punto_venta_id);
        #endregion

        #region Detalle
        [HttpPost("CrearDetalle")]
        public async Task<ActionResult<bool>> CreateAsync([FromBody] DetalleOrdenDeCompraSave detalleOrdenDeCompra)
            => await _ordenDeCompra.CreateAsync(detalleOrdenDeCompra);

        [HttpPost("CrearDetalles")]
        public async Task<ActionResult<bool>> CreateManyAsync([FromBody] IEnumerable<DetalleOrdenDeCompraSave> detallesOrdenDeCompra)
            => await _ordenDeCompra.CreateManyAsync(detallesOrdenDeCompra);

        [HttpGet("GetDetalle/{id}")]
        public async Task<ActionResult<DetalleOrdenDeCompraRead>> GetDetalleOrdenDeCompraAsync(Guid id)
            => await _ordenDeCompra.GetDetalleOrdenDeCompraAsync(id);

        [HttpGet("GetDetalles")]
        public async Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraAsync()
            => await _ordenDeCompra.GetDetallesDeOrdenesDeCompraAsync();

        [HttpGet("GetDetallesPorProducto/{producto_id}")]
        public async Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraPorProductoAsync(Guid producto_id)
            => await _ordenDeCompra.GetDetallesDeOrdenesDeCompraPorProductoAsync(producto_id);

        [HttpGet("GetDetallesPorOrden/{orden_compra_id}")]
        public async Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraPorOrdenAsync(Guid orden_compra_id)
            => await _ordenDeCompra.GetDetallesDeOrdenesDeCompraPorOrdenAsync(orden_compra_id);
        #endregion

        #region RecepcionDeCompra
        [HttpPost("CrearRecepcionDeCompra")]
        public async Task<string> CreateAsync(RecepcionDeCompraSave recepcionDeCompra)
            => await _ordenDeCompra.CreateAsync(recepcionDeCompra);

        [HttpGet("GetRecepcionDeCompra/{id}")]
        public async Task<RecepcionDeCompraSave> GetRecepcionDeCompraAsync(Guid id)
            => await _ordenDeCompra.GetRecepcionDeCompraAsync(id);

        [HttpGet("GetRecepcionesDeCompras")]
        public async Task<IEnumerable<RecepcionDeCompraSave>> GetRecepcionesDeComprasAsync()
            => await _ordenDeCompra.GetRecepcionesDeComprasAsync();

        [HttpGet("GetRecepcionesDeCompraPorDetalle/{detalle_orden_compra_id}")]
        public async Task<IEnumerable<RecepcionDeCompraSave>> GetRecepcionesDeComprasPorDetalleAsync(Guid detalle_orden_compra_id)
            => await _ordenDeCompra.GetRecepcionesDeComprasPorDetalleAsync(detalle_orden_compra_id);

        [HttpGet("GetRecepcionesDeCompraPorCodigo/{codigo}")]
        public async Task<IEnumerable<RecepcionDeCompraSave>> GetRecepcionesDeComprasPorCodigoAsync(string codigo)
            => await _ordenDeCompra.GetRecepcionesDeComprasPorCodigoAsync(codigo);
        #endregion
    }
}