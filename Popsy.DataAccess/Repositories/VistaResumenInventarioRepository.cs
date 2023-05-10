using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class VistaResumenInventarioRepository : IVistaResumenInventarioRepository
    {
        private readonly PopsyDbContext _context;

        public VistaResumenInventarioRepository(PopsyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VistaResumenInventarioEntity>> GetVistaResumenInventario()
        {
            IEnumerable<VistaResumenInventarioEntity> vista = await _context.VistaResumenInventario.ToListAsync();
            return vista;
        }

        public async Task<IEnumerable<VistaResumenInventarioEntity>> GetVistaResumenInventarioById(Guid inventario_id)
        {
            IEnumerable<VistaResumenInventarioEntity> vista = await _context.VistaResumenInventario.Where(l => l.inventario_id == inventario_id).ToListAsync();
            return vista;
        }
    }
}