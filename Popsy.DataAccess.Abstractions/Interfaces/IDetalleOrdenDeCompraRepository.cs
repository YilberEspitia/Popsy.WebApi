using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IDetalleOrdenDeCompraRepository
    {
        Task<bool> CreateAsync(TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra);
        Task<bool> CreateManyAsync(IEnumerable<TblDetalleOrdenDeCompraEntity> detalleOrdenDeCompra);
        Task<bool> UpdateAsync(TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra);
        Task<TblDetalleOrdenDeCompraEntity?> GetDetalleOrdenDeCompraAsync(Guid id);
        Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> GetDetallesDeOrdenesDeCompraAsync();
        Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> GetDetallesDeOrdenesDeCompraPorProductoAsync(Guid producto_id);
        Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> GetDetallesDeOrdenesDeCompraPorOrdenAsync(Guid orden_compra_id);
        Task<bool> ExisteAsync(Guid id);
        Task<bool> ExisteProductoAsync(Guid producto_id);
    }
}
