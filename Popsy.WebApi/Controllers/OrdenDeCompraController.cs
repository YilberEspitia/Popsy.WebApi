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
    [Authorize(Policy = "UserSIPOP")]
    [Route("api/[controller]")]
    public class OrdenDeCompraController : ControllerBase
    {
        /// <summary>
        /// <see cref="IProveedorRecepcionBusiness"/> negocio.
        /// </summary>
        private readonly IProveedorRecepcionBusiness _proveedor;
        /// <summary>
        /// <see cref="IOrdenDeCompraBusiness"/> negocio.
        /// </summary>
        private readonly IOrdenDeCompraBusiness _ordenDeCompra;
        /// <summary>
        /// <see cref="IRecepcionDeCompraBusiness"/> negocio.
        /// </summary>
        private readonly IRecepcionDeCompraBusiness _recepcionDeCompra;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="proveedor"><see cref="IProveedorRecepcionBusiness"/> negocio.</param>
        /// <param name="ordenDeCompra"><see cref="IOrdenDeCompraBusiness"/> negocio.</param>
        /// <param name="recepcionDeCompra"><see cref="IRecepcionDeCompraBusiness"/> negocio.</param>
        public OrdenDeCompraController(IProveedorRecepcionBusiness proveedor, IOrdenDeCompraBusiness ordenDeCompra, IRecepcionDeCompraBusiness recepcionDeCompra)
        {
            _proveedor = proveedor;
            _ordenDeCompra = ordenDeCompra;
            _recepcionDeCompra = recepcionDeCompra;
        }

        #region Proveedor
        /// <summary>
        /// Guarda o actualiza registro de <see cref="ProveedorRecepcionObject"/>.
        /// </summary>
        /// <param name="proveedorSave">Objeto de <see cref="ProveedorRecepcionObject"/></param>
        /// <returns>Verdadero si se guarda, falso si actualiza.</returns>
        [HttpPost("CrearProveedor")]
        public async Task<ActionResult<AccionesBD>> CreateAsync([FromBody] ProveedorRecepcionObject proveedorSave)
            => await _proveedor.CreateAsync(proveedorSave);

        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="ProveedorRecepcionObject"/> id.</param>
        /// <returns><see cref="ProveedorRecepcionObject"/></returns>
        [HttpGet("GetProveedorPorId/{id}")]
        public async Task<ActionResult<ProveedorRecepcionObject>> GetProveedorRecepcionAsync(Guid id)
            => await _proveedor.GetProveedorRecepcionAsync(id);

        /// <summary>
        /// Devuelve un registro por codigo sap.
        /// </summary>
        /// <param name="codigoSap"><see cref="ProveedorRecepcionObject"/> codigo sap.</param>
        /// <returns><see cref="ProveedorRecepcionObject"/></returns>
        [HttpGet("GetProveedorPorSap/{codigoSap}")]
        public async Task<ActionResult<ProveedorRecepcionObject>> GetProveedorRecepcionAsync(String codigoSap)
            => await _proveedor.GetProveedorRecepcionAsync(codigoSap);

        /// <summary>
        /// Devuelve todos los registros de <see cref="ProveedorRecepcionObject"/>.
        /// </summary>
        /// <returns>Registros de <see cref="ProveedorRecepcionObject"/></returns>
        [HttpGet("GetProveedores")]
        public async Task<IEnumerable<ProveedorRecepcionObject>> GetProveedoresRecepcionAsync()
            => await _proveedor.GetProveedoresRecepcionAsync();
        #endregion

        #region OrdenDeCompra
        /// <summary>
        /// Guarda o actualiza un registro de <see cref="OrdenDeCompraSave"/>.
        /// </summary>
        /// <param name="ordenDeCompra">Objeto de <see cref="OrdenDeCompraSave"/></param>
        /// <returns>Verdadero si se guarda, falso si actualiza.</returns>
        [HttpPost("CrearOrden")]
        public async Task<ActionResult<bool>> CreateAsync([FromBody] OrdenDeCompraSave ordenDeCompra)
            => await _ordenDeCompra.CreateAsync(ordenDeCompra);

        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="OrdenDeCompraRead"/> id.</param>
        /// <returns><see cref="OrdenDeCompraRead"/></returns>
        [HttpGet("GetOrdenDeCompra/{id}")]
        public async Task<ActionResult<OrdenDeCompraRead>> GetOrdenDeCompraAsync(Guid id)
            => await _ordenDeCompra.GetOrdenDeCompraAsync(id);

        /// <summary>
        /// Devuelve todos los registros de <see cref="OrdenDeCompraRead"/>.
        /// </summary>
        /// <returns>Registros de <see cref="OrdenDeCompraRead"/></returns>
        [HttpGet("GetOrdenesDeCompra")]
        public async Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraAsync()
            => await _ordenDeCompra.GetOrdenesDeCompraAsync();

        /// <summary>
        /// Devuelve todos los registros de <see cref="OrdenDeCompraRead"/> por proveedor.
        /// </summary>
        /// <param name="proveedor_recepcion_id">Id de proveedor.</param>
        /// <returns>Registros de <see cref="OrdenDeCompraRead"/></returns>
        [HttpGet("GetOrdenesDeCompraPorProveedor/{proveedor_recepcion_id}")]
        public async Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraPorProveedorAsync(Guid proveedor_recepcion_id)
            => await _ordenDeCompra.GetOrdenesDeCompraPorProveedorAsync(proveedor_recepcion_id);

        /// <summary>
        /// Devuelve todos los registros de <see cref="OrdenDeCompraRead"/> por punto de venta.
        /// </summary>
        /// <param name="punto_venta_id">Id de punto de venta.</param>
        /// <returns>Registros de <see cref="OrdenDeCompraRead"/></returns>
        [HttpGet("GetOrdenesDeCompraPorPunto/{punto_venta_id}")]
        public async Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraPorPuntoAsync(Guid punto_venta_id)
            => await _ordenDeCompra.GetOrdenesDeCompraPorPuntoAsync(punto_venta_id);
        #endregion

        #region Detalle
        /// <summary>
        /// Guarda o actualiza registro de <see cref="DetalleOrdenDeCompraSave"/>.
        /// </summary>
        /// <param name="detalleOrdenDeCompra">Objeto de <see cref="DetalleOrdenDeCompraSave"/></param>
        /// <returns>Verdadero si se guarda, falso si actualiza.</returns>
        [HttpPost("CrearDetalle")]
        public async Task<ActionResult<bool>> CreateAsync([FromBody] DetalleOrdenDeCompraSave detalleOrdenDeCompra)
            => await _ordenDeCompra.CreateAsync(detalleOrdenDeCompra);

        /// <summary>
        /// Guarda o actualiza varios registros de <see cref="DetalleOrdenDeCompraSave"/>.
        /// </summary>
        /// <param name="detallesOrdenDeCompra">Objeto de <see cref="DetalleOrdenDeCompraSave"/></param>
        /// <returns>Verdadero si se guarda o actualiza.</returns>
        [HttpPost("CrearDetalles")]
        public async Task<ActionResult<bool>> CreateManyAsync([FromBody] IEnumerable<DetalleOrdenDeCompraSave> detallesOrdenDeCompra)
            => await _ordenDeCompra.CreateManyAsync(detallesOrdenDeCompra);

        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="DetalleOrdenDeCompraRead"/> id.</param>
        /// <returns><see cref="DetalleOrdenDeCompraRead"/></returns>
        [HttpGet("GetDetalle/{id}")]
        public async Task<ActionResult<DetalleOrdenDeCompraRead>> GetDetalleOrdenDeCompraAsync(Guid id)
            => await _ordenDeCompra.GetDetalleOrdenDeCompraAsync(id);

        /// <summary>
        /// Devuelve todos los registros de <see cref="DetalleOrdenDeCompraRead"/>.
        /// </summary>
        /// <returns>Registros de <see cref="DetalleOrdenDeCompraRead"/></returns>
        [HttpGet("GetDetalles")]
        public async Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraAsync()
            => await _ordenDeCompra.GetDetallesDeOrdenesDeCompraAsync();

        /// <summary>
        /// Devuelve todos los registros de <see cref="DetalleOrdenDeCompraRead"/> por producto.
        /// </summary>
        /// <param name="producto_id">Id de producto.</param>
        /// <returns>Registros de <see cref="DetalleOrdenDeCompraRead"/></returns>
        [HttpGet("GetDetallesPorProducto/{producto_id}")]
        public async Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraPorProductoAsync(Guid producto_id)
            => await _ordenDeCompra.GetDetallesDeOrdenesDeCompraPorProductoAsync(producto_id);

        /// <summary>
        /// Devuelve todos los registros de <see cref="DetalleOrdenDeCompraRead"/> por orden de compra.
        /// </summary>
        /// <param name="orden_compra_id">Id de orden de compra.</param>
        /// <returns>Registros de <see cref="DetalleOrdenDeCompraRead"/></returns>
        [HttpGet("GetDetallesPorOrden/{orden_compra_id}")]
        public async Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraPorOrdenAsync(Guid orden_compra_id)
            => await _ordenDeCompra.GetDetallesDeOrdenesDeCompraPorOrdenAsync(orden_compra_id);
        #endregion

        #region RecepcionDeCompra
        /// <summary>
        /// Guarda o actualiza registro de <see cref="RecepcionDeCompraSave"/>.
        /// </summary>
        /// <param name="recepcionDeCompra">Objeto de <see cref="RecepcionDeCompraSave"/></param>
        /// <returns>Verdadero si se guarda, falso si actualiza.</returns>
        [HttpPost("CrearRecepcionDeCompra")]
        public async Task<string> CreateAsync(RecepcionDeCompraSave recepcionDeCompra)
            => await _recepcionDeCompra.CreateAsync(recepcionDeCompra);

        /// <summary>
        /// Devuelve un registro por id.
        /// </summary>
        /// <param name="id"><see cref="RecepcionDeCompraRead"/> id.</param>
        /// <returns><see cref="RecepcionDeCompraRead"/></returns>
        [HttpGet("GetRecepcionDeCompra/{id}")]
        public async Task<RecepcionDeCompraSave> GetRecepcionDeCompraAsync(Guid id)
            => await _recepcionDeCompra.GetRecepcionDeCompraAsync(id);

        /// <summary>
        /// Devuelve todos los registros de <see cref="RecepcionDeCompraRead"/>.
        /// </summary>
        /// <returns>Registros de <see cref="RecepcionDeCompraRead"/></returns>
        [HttpGet("GetRecepcionesDeCompras")]
        public async Task<IEnumerable<RecepcionDeCompraSave>> GetRecepcionesDeComprasAsync()
            => await _recepcionDeCompra.GetRecepcionesDeComprasAsync();

        /// <summary>
        /// Devuelve todos los registros de <see cref="RecepcionDeCompraRead"/> por detalle de orden de compra.
        /// </summary>
        /// <param name="detalle_orden_compra_id">Id de detalle de orden de compra.</param>
        /// <returns>Registros de <see cref="RecepcionDeCompraRead"/></returns>
        [HttpGet("GetRecepcionesDeCompraPorDetalle/{detalle_orden_compra_id}")]
        public async Task<IEnumerable<RecepcionDeCompraSave>> GetRecepcionesDeComprasPorDetalleAsync(Guid detalle_orden_compra_id)
            => await _recepcionDeCompra.GetRecepcionesDeComprasPorDetalleAsync(detalle_orden_compra_id);

        /// <summary>
        /// Devuelve todos los registros de <see cref="RecepcionDeCompraRead"/> por codigo de recepción.
        /// </summary>
        /// <param name="codigo">Codigo de recepcion.</param>
        /// <returns>Registros de <see cref="RecepcionDeCompraRead"/></returns>
        [HttpGet("GetRecepcionesDeCompraPorCodigo/{codigo}")]
        public async Task<IEnumerable<RecepcionDeCompraSave>> GetRecepcionesDeComprasPorCodigoAsync(string codigo)
            => await _recepcionDeCompra.GetRecepcionesDeComprasPorCodigoAsync(codigo);
        #endregion

        #region Integraciones
        /// <summary>
        /// Metodo por demanda para sincronizar proveedores.
        /// </summary>
        /// <returns>Sap response.</returns>
        [HttpGet("SyncProveedor")]
        public async Task<IEnumerable<ResponsePopsySAP>> SyncSAPAsync()
            => await _proveedor.SyncSAPAsync();
        /// <summary>
        /// Metodo por demanda para sincronizar ordenes de compra.
        /// </summary>
        /// <returns>Sap response.</returns>
        [HttpGet("SyncOrdenes")]
        public async Task<IEnumerable<ResponseOrdenesPopsySAP>> SyncSAPOrdenes()
            => await _ordenDeCompra.SyncSAPAsync();
        #endregion
    }
}