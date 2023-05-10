using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IVistaPuntosVentaBodegasRepository
    {
        Task<IEnumerable<VistaPuntosVentaBodegasEntity>> GetVistaPuntosVentaBodegasByPuntoVenta(Guid punto_venta_id);
    }
}