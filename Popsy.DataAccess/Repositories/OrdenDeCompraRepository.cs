using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class OrdenDeCompraRepository : IOrdenDeCompraRepository
    {
        private readonly PopsyDbContext _context;

        public OrdenDeCompraRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<bool> IOrdenDeCompraRepository.CreateAsync(TblOrdenDeCompraEntity ordenDeCompra)
        {
            ordenDeCompra.fecha_modificacion = DateTime.UtcNow;
            await _context.AddAsync(ordenDeCompra);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<bool> IOrdenDeCompraRepository.UpdateAsync(TblOrdenDeCompraEntity ordenDeCompra)
        {
            ordenDeCompra.fecha_modificacion = DateTime.UtcNow;
            TblOrdenDeCompraEntity ordenDeCompraDb = await this._context.OrdenesDeCompra.SingleAsync(r => r.orden_compra_id.Equals(ordenDeCompra.orden_compra_id));
            this._context.Entry(ordenDeCompraDb).CurrentValues.SetValues(ordenDeCompra);
            await this._context.SaveChangesAsync();
            return true;
        }

        async Task<TblOrdenDeCompraEntity?> IOrdenDeCompraRepository.GetOrdenDeCompraAsync(string ordenDeCompra)
            => await _context.OrdenesDeCompra.Include(x => x.detalles_ordenes_de_compra).Where(x => x.orden_compra.Equals(ordenDeCompra)).FirstOrDefaultAsync();

        async Task<TblOrdenDeCompraEntity?> IOrdenDeCompraRepository.GetOrdenDeCompraAsync(Guid id)
            => await _context.OrdenesDeCompra.Include(x => x.detalles_ordenes_de_compra).Where(x => x.orden_compra_id.Equals(id)).FirstOrDefaultAsync();

        async Task<IEnumerable<TblOrdenDeCompraEntity>> IOrdenDeCompraRepository.GetOrdenesDeCompraAsync()
            => await _context.OrdenesDeCompra.Include(x => x.detalles_ordenes_de_compra).ToListAsync();

        async Task<IEnumerable<TblOrdenDeCompraEntity>> IOrdenDeCompraRepository.GetOrdenesDeCompraPorProveedorAsync(Guid proveedor_recepcion_id)
            => await _context.OrdenesDeCompra.Include(x => x.detalles_ordenes_de_compra).Where(x => x.proveedor_recepcion_id.Equals(proveedor_recepcion_id)).ToListAsync();

        async Task<IEnumerable<TblOrdenDeCompraEntity>> IOrdenDeCompraRepository.GetOrdenesDeCompraPorPuntoAsync(Guid punto_venta_id)
            => await _context.OrdenesDeCompra.Include(x => x.detalles_ordenes_de_compra).Where(x => x.punto_venta_id.Equals(punto_venta_id)).ToListAsync();
    }
}