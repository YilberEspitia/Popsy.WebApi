using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class ProductosPedidosRepository : IProductosPedidosRepository
    {
        private readonly PopsyDbContext _context;

        public ProductosPedidosRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<List<TblProductoPedidoEntity>> IProductosPedidosRepository.GetProductoPedidoId(Guid pedido_id)
        {
            List<TblProductoPedidoEntity> vista = await _context.PropuctosPorPedido.Where(l => l.pedido_id == pedido_id).ToListAsync();
            return vista;
        }
    }
}