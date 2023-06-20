using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IVistaProductoFactoresConversionRepository
    {
        Task<VistaProductoFactoresConversionEntity?> GetProductoFactoresConversion(Guid producto_id);
    }
}