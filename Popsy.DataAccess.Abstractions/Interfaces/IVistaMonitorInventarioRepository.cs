using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IVistaMonitorInventarioRepository
    {
        Task<IEnumerable<VistaMonitorInventarioEntity>> GetInventarioMonitor(Guid punto_venta_id);
        Task<IEnumerable<VistaMonitorInventarioEntity>> GetAllInventarioMonitor();
        Task<TblInventarioEntity?> GetUltimoInventarioAsync(Guid punto_venta_id);
    }
}