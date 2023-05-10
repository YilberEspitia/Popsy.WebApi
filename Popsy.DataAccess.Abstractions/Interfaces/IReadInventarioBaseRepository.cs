using Popsy.Objects;

namespace Popsy.Interfaces
{
    public interface IReadInventarioBaseRepository
    {
        Task<List<ReadInventarioBaseEntity>> GetInventarioBase(Guid punto_venta_id);
    }
}