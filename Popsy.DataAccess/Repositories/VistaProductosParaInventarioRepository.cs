using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class VistaProductosParaInventarioRepository : IVistaProductosParaInventarioRepository
    {
        private readonly PopsyDbContext _context;

        public VistaProductosParaInventarioRepository(PopsyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VistaProductosParaInventarioEntity>> GetVistaProductosParaInventario()
        {
            IEnumerable<VistaProductosParaInventarioEntity> vista = await _context.VistaProductosParaInventario.ToListAsync();
            return vista;
        }

        public async Task<IEnumerable<VistaProductosParaInventarioEntity>> GetVistaProductosParaInventarioByCategoria(string categoria_id)
        {
            IEnumerable<VistaProductosParaInventarioEntity> vista = await _context.VistaProductosParaInventario.Where(l => l.categoria_id == categoria_id).ToListAsync();
            return vista;
        }
    }
}