using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class VistaMonitorInventarioRepository : IVistaMonitorInventarioRepository
    {
        private readonly PopsyDbContext _context;

        public VistaMonitorInventarioRepository(PopsyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VistaMonitorInventarioEntity>> GetInventarioMonitor(Guid punto_venta_id)
        {
            IEnumerable<VistaMonitorInventarioEntity> vista = await _context.VistaMonitorInventario.Where(l => l.punto_venta_id == punto_venta_id).ToListAsync();
            return vista;
        }
    }
}