using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class TipoInventariosRepository : ITipoInventariosRepository
    {
        private readonly PopsyDbContext _context;

        public TipoInventariosRepository(PopsyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TblTipoInventarioEntity>> GetTipoInventario()
        {
            var vista = await _context.TblTipoInventario.ToListAsync();
            return vista;
        }

        public async Task<TblTipoInventarioEntity> GetTipoInventarioById(Guid tipo_inventarios_id)
        {
            TblTipoInventarioEntity vista = await _context.TblTipoInventario.FirstOrDefaultAsync(l => l.tipo_inventario_id == tipo_inventarios_id);
            return vista;
        }
    }
}