using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    /// <summary>
    /// Implementa los metodos relacionados con la entidad <see cref="TblRecepcionDeCompraDetalleEntity"/>.
    /// </summary>
    public class RecepcionDeCompraDetalleRepository : IRecepcionDeCompraDetalleRepository
    {
        /// <summary>
        /// Contexto.
        /// </summary>
        private readonly PopsyDbContext _context;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Contexto.</param>
        public RecepcionDeCompraDetalleRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<bool> IRecepcionDeCompraDetalleRepository.CreateAsync(TblRecepcionDeCompraDetalleEntity detalleRecepcionDeCompra)
        {
            detalleRecepcionDeCompra.fecha_modificacion = DateTime.Now;
            await _context.AddAsync(detalleRecepcionDeCompra);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<bool> IRecepcionDeCompraDetalleRepository.UpdateAsync(TblRecepcionDeCompraDetalleEntity detalleRecepcionDeCompra)
        {
            detalleRecepcionDeCompra.fecha_modificacion = DateTime.Now;
            TblRecepcionDeCompraDetalleEntity detalleRecepcionDeCompraDb = await this._context.RecepcionesDeCompraDetalles.SingleAsync(r => r.recepcion_compra_detalle_id.Equals(detalleRecepcionDeCompra.recepcion_compra_detalle_id));
            this._context.Entry(detalleRecepcionDeCompraDb).CurrentValues.SetValues(detalleRecepcionDeCompra);
            await this._context.SaveChangesAsync();
            return true;
        }

        async Task<TblRecepcionDeCompraDetalleEntity?> IRecepcionDeCompraDetalleRepository.GetDetalleRecepcionDeCompraAsync(Guid id)
            => await _context.RecepcionesDeCompraDetalles.Include(x => x.producto).Include(x => x.recepcion_compra).Where(x => x.recepcion_compra_detalle_id.Equals(id)).FirstOrDefaultAsync();

        async Task<IEnumerable<TblRecepcionDeCompraDetalleEntity>> IRecepcionDeCompraDetalleRepository.GetDetallesDeRecepcionesDeCompraAsync()
            => await _context.RecepcionesDeCompraDetalles.Include(x => x.producto).Include(x => x.recepcion_compra).ToListAsync();

        async Task<IEnumerable<TblRecepcionDeCompraDetalleEntity>> IRecepcionDeCompraDetalleRepository.GetDetallesDeRecepcionesDeCompraPorRecepcionAsync(Guid recepcion_compra_id)
            => await _context.RecepcionesDeCompraDetalles.Include(x => x.producto).Include(x => x.recepcion_compra).Where(x => x.recepcion_compra_id.Equals(recepcion_compra_id)).ToListAsync();

        async Task<IEnumerable<TblRecepcionDeCompraDetalleEntity>> IRecepcionDeCompraDetalleRepository.GetDetallesDeRecepcionesDeCompraPorProductoAsync(Guid producto_id)
            => await _context.RecepcionesDeCompraDetalles.Include(x => x.producto).Include(x => x.recepcion_compra).Where(x => x.producto_id.Equals(producto_id)).ToListAsync();

        async Task<bool> IRecepcionDeCompraDetalleRepository.ExisteAsync(Guid id)
            => await _context.RecepcionesDeCompraDetalles.Where(x => x.recepcion_compra_detalle_id.Equals(id)).AnyAsync();

        async Task<bool> IRecepcionDeCompraDetalleRepository.ExisteProductoAsync(Guid producto_id)
            => await _context.Productos.Where(x => x.producto_id.Equals(producto_id)).AnyAsync();

        async Task<bool> IRecepcionDeCompraDetalleRepository.ExisteProductoAsync(string codigo)
            => await _context.Productos.Where(x => x.codigo.Equals(codigo)).AnyAsync();

        async Task<Guid> IRecepcionDeCompraDetalleRepository.GetProductoPorCodigoAsync(string codigo)
            => await _context.Productos.Where(x => x.codigo.Equals(codigo)).Select(x => x.producto_id).FirstOrDefaultAsync();

    }
}