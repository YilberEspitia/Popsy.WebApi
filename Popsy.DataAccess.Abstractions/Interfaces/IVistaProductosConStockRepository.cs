using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IVistaProductosConStockRepository
    {
        Task<IEnumerable<VistaProductosConStockEntity>> GetVistaProductosConStock();
    }
}