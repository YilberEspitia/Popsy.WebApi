using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class VistaCategoriasProductosRepository : IVistaCategoriasProductosRepository
    {
        private readonly PopsyDbContext _context;

        public VistaCategoriasProductosRepository(PopsyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VistaCategoriasProductosEntity>> GetVistaCategoriasProductos()
        {
            IEnumerable<VistaCategoriasProductosEntity> categorias = await _context.VistaCategoriasProductos.ToListAsync();
            return categorias;
        }
    }
}