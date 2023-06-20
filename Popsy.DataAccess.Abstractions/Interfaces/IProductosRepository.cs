using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IProductosRepository
    {
        Task<TblProductoEntity?> GetProductosByCodigo(string codigo);
        Task<TblProductoEntity?> GetProductosById(Guid producto_id);
    }
}