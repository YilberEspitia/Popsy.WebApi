using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    /// <summary>
    /// Implementa los metodos relacionados con la entidad <see cref="TblOrdenDeCompraEntity"/>.
    /// </summary>
    public class OrdenDeCompraRepository : IOrdenDeCompraRepository
    {
        /// <summary>
        /// Contexto.
        /// </summary>
        private readonly PopsyDbContext _context;


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Contexto.</param>
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
            => await _context.OrdenesDeCompra.Include(x => x.punto_de_venta).Include(x => x.proveedor_recepcion).Where(x => x.orden_compra.Equals(ordenDeCompra)).FirstOrDefaultAsync();

        async Task<TblOrdenDeCompraEntity?> IOrdenDeCompraRepository.GetOrdenDeCompraAsync(Guid id)
            => await _context.OrdenesDeCompra.Include(x => x.punto_de_venta).Include(x => x.proveedor_recepcion).Where(x => x.orden_compra_id.Equals(id)).FirstOrDefaultAsync();

        async Task<IEnumerable<TblOrdenDeCompraEntity>> IOrdenDeCompraRepository.GetOrdenesDeCompraAsync()
            => await _context.OrdenesDeCompra.Include(x => x.punto_de_venta).Include(x => x.proveedor_recepcion).ToListAsync();

        async Task<IEnumerable<TblOrdenDeCompraEntity>> IOrdenDeCompraRepository.GetOrdenesDeCompraPorProveedorAsync(Guid proveedor_recepcion_id)
            => await _context.OrdenesDeCompra.Include(x => x.punto_de_venta).Include(x => x.proveedor_recepcion).Where(x => x.proveedor_recepcion_id.Equals(proveedor_recepcion_id)).ToListAsync();

        async Task<IEnumerable<TblOrdenDeCompraEntity>> IOrdenDeCompraRepository.GetOrdenesDeCompraPorPuntoAsync(Guid punto_venta_id)
            => await _context.OrdenesDeCompra.Include(x => x.punto_de_venta).Include(x => x.proveedor_recepcion).Where(x => x.punto_venta_id.Equals(punto_venta_id)).ToListAsync();
        async Task<bool> IOrdenDeCompraRepository.ExisteProveedorRecepcionAsync(Guid proveedor_recepcion_id)
            => await _context.ProveedoresRecepcion.Where(x => x.proveedor_recepcion_id.Equals(proveedor_recepcion_id)).AnyAsync();

        async Task<bool> IOrdenDeCompraRepository.ExisteAsync(Guid id)
            => await _context.OrdenesDeCompra.Where(x => x.orden_compra_id.Equals(id)).AnyAsync();

        async Task<bool> IOrdenDeCompraRepository.ExistePuntoDeVentaAsync(Guid punto_venta_id)
            => await _context.PuntosDeVenta.Where(x => x.punto_venta_id.Equals(punto_venta_id)).AnyAsync();
    }
}