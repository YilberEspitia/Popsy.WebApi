using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class VistaPuntosVentaBodegasRepository : IVistaPuntosVentaBodegasRepository
    {
        private readonly PopsyDbContext _context;

        public VistaPuntosVentaBodegasRepository(PopsyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VistaPuntosVentaBodegasEntity>> GetVistaPuntosVentaBodegasByPuntoVenta(Guid punto_venta_id)
        {
            IEnumerable<VistaPuntosVentaBodegasEntity> vista = await _context.VistaPuntosVentaBodegas.Where(l => l.punto_venta_id == punto_venta_id).ToListAsync();
            return vista;
        }
    }
}