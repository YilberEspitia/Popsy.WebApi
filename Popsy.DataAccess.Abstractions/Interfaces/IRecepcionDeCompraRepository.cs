using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IRecepcionDeCompraRepository
    {
        Task<bool> CreateAsync(TblRecepcionDeCompraEntity recepcionDeCompra);
        Task<bool> UpdateAsync(TblRecepcionDeCompraEntity recepcionDeCompra);
        Task<TblRecepcionDeCompraEntity?> GetRecepcionDeCompraAsync(Guid id);
        Task<IEnumerable<TblRecepcionDeCompraEntity>> GetRecepcionesDeComprasAsync();
        Task<IEnumerable<TblRecepcionDeCompraEntity>> GetRecepcionesDeComprasPorDetalleAsync(Guid detalle_orden_compra_id);
        Task<IEnumerable<TblRecepcionDeCompraEntity>> GetRecepcionesDeComprasPorCodigoAsync(string codigo);
        Task<int> GetConstante();
        Task<bool> ExisteAsync(Guid id);
    }
}
