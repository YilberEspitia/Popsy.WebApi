using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class VistaPedidosPuntoVentaRepository : IVistaPedidosPuntoVentaRepository
    {
        private readonly PopsyDbContext _context;

        public VistaPedidosPuntoVentaRepository(PopsyDbContext context)
        {
            _context = context;
        }

        public async Task<VistaPedidosPuntoVentaEntity?> GetVistaPedidosPuntoVenta(Guid pedido_id)
        {
            VistaPedidosPuntoVentaEntity? vista = await _context.VistaPedidosPuntoVenta.FirstOrDefaultAsync(l => l.pedido_id == pedido_id);
            return vista;
        }
    }
}