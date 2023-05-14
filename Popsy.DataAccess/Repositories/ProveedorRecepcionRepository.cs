using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    /// <summary>
    /// Implementa los metodos relacionados con la entidad <see cref="TblProveedorRecepcionEntity"/>.
    /// </summary>
    public class ProveedorRecepcionRepository : IProveedorRecepcionRepository
    {
        /// <summary>
        /// Contexto.
        /// </summary>
        private readonly PopsyDbContext _context;


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Contexto.</param>
        public ProveedorRecepcionRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<bool> IProveedorRecepcionRepository.CreateAsync(TblProveedorRecepcionEntity proveedorRecepcion)
        {
            proveedorRecepcion.fecha_modificacion = DateTime.UtcNow;
            await _context.AddAsync(proveedorRecepcion);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<bool> IProveedorRecepcionRepository.UpdateAsync(TblProveedorRecepcionEntity proveedorRecepcion)
        {
            proveedorRecepcion.fecha_modificacion = DateTime.UtcNow;
            TblProveedorRecepcionEntity proveedorRecepcionDb = await this._context.ProveedoresRecepcion.SingleAsync(r => r.proveedor_recepcion_id.Equals(proveedorRecepcion.proveedor_recepcion_id));
            this._context.Entry(proveedorRecepcionDb).CurrentValues.SetValues(proveedorRecepcion);
            await this._context.SaveChangesAsync();
            return true;
        }

        async Task<TblProveedorRecepcionEntity?> IProveedorRecepcionRepository.GetProveedorRecepcionAsync(string codigoSap)
            => await _context.ProveedoresRecepcion.Include(x => x.ordenes_de_compra).Where(x => x.codigo_sap_proveedor.Equals(codigoSap)).FirstOrDefaultAsync();

        async Task<TblProveedorRecepcionEntity?> IProveedorRecepcionRepository.GetProveedorRecepcionAsync(Guid id)
            => await _context.ProveedoresRecepcion.Include(x => x.ordenes_de_compra).Where(x => x.proveedor_recepcion_id.Equals(id)).FirstOrDefaultAsync();

        async Task<IEnumerable<TblProveedorRecepcionEntity>> IProveedorRecepcionRepository.GetProveedoresRecepcionAsync()
            => await _context.ProveedoresRecepcion.Include(x => x.ordenes_de_compra).ToListAsync();

        async Task<bool> IProveedorRecepcionRepository.ExisteAsync(Guid id)
            => await _context.ProveedoresRecepcion.Where(x => x.proveedor_recepcion_id.Equals(id)).AnyAsync();
    }
}