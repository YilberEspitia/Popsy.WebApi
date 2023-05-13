using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class DetalleOrdenDeCompraRepository : IDetalleOrdenDeCompraRepository
    {
        private readonly PopsyDbContext _context;

        public DetalleOrdenDeCompraRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<bool> IDetalleOrdenDeCompraRepository.CreateAsync(TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra)
        {
            await _context.AddAsync(detalleOrdenDeCompra);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<bool> IDetalleOrdenDeCompraRepository.CreateManyAsync(IEnumerable<TblDetalleOrdenDeCompraEntity> detallesOrdenesDeCompra)
        {
            await _context.AddRangeAsync(detallesOrdenesDeCompra);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<bool> IDetalleOrdenDeCompraRepository.UpdateAsync(TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra)
        {
            TblDetalleOrdenDeCompraEntity detalleOrdenDeCompraDb = await this._context.DetallesOrdenesDeCompra.SingleAsync(r => r.detalle_orden_compra_id.Equals(detalleOrdenDeCompra.detalle_orden_compra_id));
            this._context.Entry(detalleOrdenDeCompraDb).CurrentValues.SetValues(detalleOrdenDeCompra);
            await this._context.SaveChangesAsync();
            return true;
        }

        async Task<TblDetalleOrdenDeCompraEntity?> IDetalleOrdenDeCompraRepository.GetDetalleOrdenDeCompraAsync(Guid id)
            => await _context.DetallesOrdenesDeCompra.Include(x => x.orden_de_compra).Where(x => x.detalle_orden_compra_id.Equals(id)).FirstOrDefaultAsync();

        async Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> IDetalleOrdenDeCompraRepository.GetDetallesDeOrdenesDeCompraAsync()
            => await _context.DetallesOrdenesDeCompra.Include(x => x.orden_de_compra).ToListAsync();

        async Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> IDetalleOrdenDeCompraRepository.GetDetallesDeOrdenesDeCompraPorOrdenAsync(Guid orden_compra_id)
            => await _context.DetallesOrdenesDeCompra.Include(x => x.orden_de_compra).Where(x => x.orden_compra_id.Equals(orden_compra_id)).ToListAsync();

        async Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> IDetalleOrdenDeCompraRepository.GetDetallesDeOrdenesDeCompraPorProductoAsync(Guid producto_id)
            => await _context.DetallesOrdenesDeCompra.Include(x => x.orden_de_compra).Where(x => x.producto_id.Equals(producto_id)).ToListAsync();
    }
}