using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class VistaProductoFactoresConversionRepository : IVistaProductoFactoresConversionRepository
    {
        private readonly PopsyDbContext _context;

        public VistaProductoFactoresConversionRepository(PopsyDbContext context)
        {
            _context = context;
        }

        public async Task<VistaProductoFactoresConversionEntity?> GetProductoFactoresConversion(Guid producto_id)
        {
            VistaProductoFactoresConversionEntity? vista = await _context.VistaProductoFactoresConversion.FirstOrDefaultAsync(l => l.producto_id == producto_id);
            return vista;
        }
    }
}