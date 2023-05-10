using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IVistaResumenInventarioRepository
    {
        Task<IEnumerable<VistaResumenInventarioEntity>> GetVistaResumenInventarioById(Guid inventario_id);
        Task<IEnumerable<VistaResumenInventarioEntity>> GetVistaResumenInventario();
    }
}