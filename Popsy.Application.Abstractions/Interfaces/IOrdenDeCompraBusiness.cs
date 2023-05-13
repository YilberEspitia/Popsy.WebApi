using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface IOrdenDeCompraBusiness
    {
        Task<string> CreateAsync(OrdenDeCompraSave ordenDeCompra);
        Task<OrdenDeCompraRead?> GetOrdenDeCompraAsync(String ordenDeCompra);
        Task<OrdenDeCompraRead?> GetOrdenDeCompraAsync(Guid id);
        Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraAsync();
        Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraPorProveedorAsync(Guid proveedor_recepcion_id);
        Task<IEnumerable<OrdenDeCompraRead>> GetOrdenesDeCompraPorPuntoAsync(Guid punto_venta_id);
    }
}
