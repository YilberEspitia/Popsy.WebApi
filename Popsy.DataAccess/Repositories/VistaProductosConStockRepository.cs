using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class VistaProductosConStockRepository : IVistaProductosConStockRepository
    {
        private readonly PopsyDbContext _context;

        public VistaProductosConStockRepository(PopsyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VistaProductosConStockEntity>> GetVistaProductosConStock()
        {
            IEnumerable<VistaProductosConStockEntity> vista = await _context.VistaProductosConStock.ToListAsync();
            return vista;
        }
    }
}