using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class PuntosVentasRepository : IPuntosVentasRepository
    {
        private readonly PopsyDbContext _context;

        public PuntosVentasRepository(PopsyDbContext context)
        {
            _context = context;
        }

        public async Task<TblPuntoVentaEntity> GetPuntoVentasId(Guid punto_venta_id)
        {
            TblPuntoVentaEntity vista = await _context.PuntosDeVenta.FirstOrDefaultAsync(l => l.punto_venta_id == punto_venta_id);
            return vista;
        }
    }
}