using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IOrdenDeCompraRepository
    {
        Task<bool> CreateAsync(TblOrdenDeCompraEntity ordenDeCompra);
        Task<bool> UpdateAsync(TblOrdenDeCompraEntity ordenDeCompra);
        Task<TblOrdenDeCompraEntity?> GetOrdenDeCompraAsync(String ordenDeCompra);
        Task<TblOrdenDeCompraEntity?> GetOrdenDeCompraAsync(Guid id);
        Task<IEnumerable<TblOrdenDeCompraEntity>> GetOrdenesDeCompraAsync();
        Task<IEnumerable<TblOrdenDeCompraEntity>> GetOrdenesDeCompraPorProveedorAsync(Guid proveedor_recepcion_id);
        Task<IEnumerable<TblOrdenDeCompraEntity>> GetOrdenesDeCompraPorPuntoAsync(Guid punto_venta_id);
        Task<bool> ExisteProveedorRecepcionAsync(Guid proveedor_recepcion_id);
        Task<bool> ExisteAsync(Guid id);
        Task<bool> ExistePuntoDeVentaAsync(Guid punto_venta_id);
    }
}
