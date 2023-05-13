using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface IDetalleOrdenDeCompraBusiness
    {
        Task<bool> CreateAsync(DetalleOrdenDeCompraSave detalleOrdenDeCompra);
        Task<bool> CreateManyAsync(IEnumerable<DetalleOrdenDeCompraSave> detalleOrdenDeCompra);
        Task<DetalleOrdenDeCompraRead?> GetDetalleOrdenDeCompraAsync(Guid id);
        Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraAsync();
        Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraPorProductoAsync(Guid producto_id);
        Task<IEnumerable<DetalleOrdenDeCompraRead>> GetDetallesDeOrdenesDeCompraPorOrdenAsync(Guid orden_compra_id);
    }
}
