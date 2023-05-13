using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface IOrdenDeCompraBusiness
    {
        #region OrdenDeCompra
        Task<bool> CreateAsync(OrdenDeCompraSave ordenDeCompra);
        Task<OrdenDeCompraRead> GetOrdenDeCompraAsync(String ordenDeCompra);
        Task<OrdenDeCompraRead> GetOrdenDeCompraAsync(Guid id);
        Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraAsync();
        Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraPorProveedorAsync(Guid proveedor_recepcion_id);
        Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraPorPuntoAsync(Guid punto_venta_id);
        #endregion

        #region Detalle
        Task<bool> CreateAsync(DetalleOrdenDeCompraSave detalleOrdenDeCompra);
        Task<bool> CreateManyAsync(IEnumerable<DetalleOrdenDeCompraSave> detalleOrdenDeCompra);
        Task<DetalleOrdenDeCompraRead> GetDetalleOrdenDeCompraAsync(Guid id);
        Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraAsync();
        Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraPorProductoAsync(Guid producto_id);
        Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraPorOrdenAsync(Guid orden_compra_id);
        #endregion

        #region RecepcionDeCompra
        Task<string> CreateAsync(RecepcionDeCompraSave recepcionDeCompra);
        Task<RecepcionDeCompraRead> GetRecepcionDeCompraAsync(Guid id);
        Task<IEnumerable<RecepcionDeCompraRead>> GetRecepcionesDeComprasAsync();
        Task<IEnumerable<RecepcionDeCompraRead>> GetRecepcionesDeComprasPorDetalleAsync(Guid detalle_orden_compra_id);
        Task<IEnumerable<RecepcionDeCompraRead>> GetRecepcionesDeComprasPorCodigoAsync(string codigo);
        #endregion
    }
}
