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

        async Task<IEnumerable<VistaMonitorInventarioEntity>> IVistaMonitorInventarioRepository.GetAllInventarioMonitor()
            => await _context.VistaMonitorInventario.ToListAsync();

        async Task<IEnumerable<VistaMonitorInventarioEntity>> IVistaMonitorInventarioRepository.GetInventarioMonitor(Guid punto_venta_id)
        {
            IEnumerable<VistaMonitorInventarioEntity> vista = await _context.VistaMonitorInventario.Where(l => l.punto_venta_id == punto_venta_id).ToListAsync();
            return vista;
        }
        async Task<TblInventarioEntity?> IVistaMonitorInventarioRepository.GetUltimoInventarioAsync(Guid punto_venta_id)
            => await _context.Inventarios.Include(x => x.tipo_inventario).Where(x => x.punto_venta_id.Equals(punto_venta_id)).OrderByDescending(l => l.fecha_toma_fisica).FirstOrDefaultAsync();
    }
}