using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IProductosRepository
    {
        Task<TblProductosEntity> GetProductosByCodigo(string codigo);
        Task<TblProductosEntity> GetProductosById(Guid producto_id);
    }
}