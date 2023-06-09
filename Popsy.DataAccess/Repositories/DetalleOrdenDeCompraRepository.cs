using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    /// <summary>
    /// Implementa los metodos relacionados con la entidad <see cref="TblDetalleOrdenDeCompraEntity"/>.
    /// </summary>
    public class DetalleOrdenDeCompraRepository : IDetalleOrdenDeCompraRepository
    {
        /// <summary>
        /// Contexto.
        /// </summary>
        private readonly PopsyDbContext _context;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Contexto.</param>
        public DetalleOrdenDeCompraRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<Guid> IDetalleOrdenDeCompraRepository.CreateAsync(TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra)
        {
            detalleOrdenDeCompra.fecha_modificacion = DateTime.Now;
            await _context.AddAsync(detalleOrdenDeCompra);
            await _context.SaveChangesAsync();
            return detalleOrdenDeCompra.detalle_orden_compra_id;
        }

        async Task<bool> IDetalleOrdenDeCompraRepository.UpdateAsync(TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra)
        {
            detalleOrdenDeCompra.fecha_modificacion = DateTime.Now;
            TblDetalleOrdenDeCompraEntity detalleOrdenDeCompraDb = await this._context.DetallesOrdenesDeCompra.SingleAsync(r => r.detalle_orden_compra_id.Equals(detalleOrdenDeCompra.detalle_orden_compra_id));
            this._context.Entry(detalleOrdenDeCompraDb).CurrentValues.SetValues(detalleOrdenDeCompra);
            await this._context.SaveChangesAsync();
            return true;
        }

        async Task<TblDetalleOrdenDeCompraEntity?> IDetalleOrdenDeCompraRepository.GetDetalleOrdenDeCompraAsync(Guid id)
            => await _context.DetallesOrdenesDeCompra.Include(x => x.producto).Include(x => x.orden_de_compra).Where(x => x.detalle_orden_compra_id.Equals(id)).FirstOrDefaultAsync();

        async Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> IDetalleOrdenDeCompraRepository.GetDetallesDeOrdenesDeCompraAsync()
            => await _context.DetallesOrdenesDeCompra.Include(x => x.producto).Include(x => x.orden_de_compra).ToListAsync();

        async Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> IDetalleOrdenDeCompraRepository.GetDetallesDeOrdenesDeCompraPorOrdenAsync(Guid orden_compra_id)
            => await _context.DetallesOrdenesDeCompra.Include(x => x.producto).Include(x => x.orden_de_compra).Where(x => x.orden_compra_id.Equals(orden_compra_id)).ToListAsync();

        async Task<IEnumerable<TblDetalleOrdenDeCompraEntity>> IDetalleOrdenDeCompraRepository.GetDetallesDeOrdenesDeCompraPorProductoAsync(Guid producto_id)
            => await _context.DetallesOrdenesDeCompra.Include(x => x.producto).Include(x => x.orden_de_compra).Where(x => x.producto_id.Equals(producto_id)).ToListAsync();

        async Task<bool> IDetalleOrdenDeCompraRepository.ExisteAsync(Guid id)
            => await _context.DetallesOrdenesDeCompra.Where(x => x.detalle_orden_compra_id.Equals(id)).AnyAsync();

        async Task<bool> IDetalleOrdenDeCompraRepository.ExisteProductoAsync(Guid producto_id)
            => await _context.Productos.Where(x => x.producto_id.Equals(producto_id)).AnyAsync();

        async Task<bool> IDetalleOrdenDeCompraRepository.ExisteProductoAsync(string codigo)
            => await _context.Productos.Where(x => x.codigo.Equals(codigo)).AnyAsync();

        async Task<Guid> IDetalleOrdenDeCompraRepository.GetProductoPorCodigoAsync(string codigo)
            => await _context.Productos.Where(x => x.codigo.Equals(codigo)).Select(x => x.producto_id).FirstOrDefaultAsync();

        async Task IDetalleOrdenDeCompraRepository.UpdateEstadoDetalles(Guid orden_compra_id, bool activo)
        {
            foreach (TblDetalleOrdenDeCompraEntity detalleDb in await _context.DetallesOrdenesDeCompra.Where(x => x.orden_compra_id.Equals(orden_compra_id)).ToListAsync())
            {
                detalleDb.activo = activo;
            }
            await _context.SaveChangesAsync();
        }

        async Task IDetalleOrdenDeCompraRepository.UpdateEstadoDetalle(Guid detalle_orden_compra_id, bool activo)
        {
            if (await _context.DetallesOrdenesDeCompra.Where(x => x.detalle_orden_compra_id.Equals(detalle_orden_compra_id)).FirstOrDefaultAsync() is TblDetalleOrdenDeCompraEntity detalleDb)
            {
                detalleDb.activo = activo;
                await _context.SaveChangesAsync();
            }
        }

        async Task<TblDetalleOrdenDeCompraEntity?> IDetalleOrdenDeCompraRepository.GetDetalleAsync(Guid orden_compra_id, Guid producto_id, string unidad_presentacion_solicitada)
            => await _context.DetallesOrdenesDeCompra.Include(x => x.producto).Include(x => x.orden_de_compra)
            .Where(x => x.orden_compra_id.Equals(orden_compra_id) && x.producto_id.Equals(producto_id) && x.unidad_presentacion_solicitada.Equals(unidad_presentacion_solicitada)).FirstOrDefaultAsync();
    }
}