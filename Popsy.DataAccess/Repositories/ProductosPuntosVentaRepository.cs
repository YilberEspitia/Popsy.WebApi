using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class ProductosPuntosVentaRepository : IProductosPuntosVentaRepository
    {
        private readonly PopsyDbContext _context;

        public ProductosPuntosVentaRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<TblProductosPuntosVentaEntity> IProductosPuntosVentaRepository.GetProductoPuntoVentaId(Guid producto_id, Guid punto_venta_id)
        {
            TblProductosPuntosVentaEntity vista = await _context.TblProductosPuntosVenta.FirstOrDefaultAsync(l => l.producto_id == producto_id && l.punto_venta_id == punto_venta_id);
            return vista;
        }
    }
}