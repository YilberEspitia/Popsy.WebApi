using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    /// <summary>
    /// Implementa los metodos relacionados con la entidad <see cref="TblRecepcionDeCompraEntity"/>.
    /// </summary>
    public class RecepcionDeCompraRepository : IRecepcionDeCompraRepository
    {
        /// <summary>
        /// Contexto.
        /// </summary>
        private readonly PopsyDbContext _context;


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Contexto.</param>
        public RecepcionDeCompraRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<bool> IRecepcionDeCompraRepository.CreateAsync(TblRecepcionDeCompraEntity recepcionDeCompra)
        {
            recepcionDeCompra.fecha_modificacion = DateTime.UtcNow;
            await _context.AddAsync(recepcionDeCompra);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<bool> IRecepcionDeCompraRepository.UpdateAsync(TblRecepcionDeCompraEntity recepcionDeCompra)
        {
            recepcionDeCompra.fecha_modificacion = DateTime.UtcNow;
            TblRecepcionDeCompraEntity recepcionDeCompraDb = await this._context.RecepcionesDeCompra.SingleAsync(r => r.recepcion_compra_id.Equals(recepcionDeCompra.recepcion_compra_id));
            this._context.Entry(recepcionDeCompraDb).CurrentValues.SetValues(recepcionDeCompra);
            await this._context.SaveChangesAsync();
            return true;
        }

        async Task<TblRecepcionDeCompraEntity?> IRecepcionDeCompraRepository.GetRecepcionDeCompraAsync(Guid id)
            => await _context.RecepcionesDeCompra.Where(x => x.recepcion_compra_id.Equals(id)).FirstOrDefaultAsync();

        async Task<IEnumerable<TblRecepcionDeCompraEntity>> IRecepcionDeCompraRepository.GetRecepcionesDeComprasAsync()
            => await _context.RecepcionesDeCompra.OrderBy(x => x.codigo_recepcion_compra).ToListAsync();

        async Task<IEnumerable<TblRecepcionDeCompraEntity>> IRecepcionDeCompraRepository.GetRecepcionesDeComprasPorDetalleAsync(Guid detalle_orden_compra_id)
            => await _context.RecepcionesDeCompra.Where(x => x.detalle_orden_compra_id.Equals(detalle_orden_compra_id)).OrderBy(x => x.codigo_recepcion_compra).ToListAsync();

        async Task<IEnumerable<TblRecepcionDeCompraEntity>> IRecepcionDeCompraRepository.GetRecepcionesDeComprasPorCodigoAsync(string codigo)
            => await _context.RecepcionesDeCompra.Where(x => x.codigo_recepcion_compra.ToUpper().Equals(codigo.ToUpper())).OrderBy(x => x.codigo_recepcion_compra).ToListAsync();

        async Task<int> IRecepcionDeCompraRepository.GetConstante()
        {
            int response = 0;
            if (await _context.RecepcionesDeCompra.AnyAsync())
                response = await _context.RecepcionesDeCompra.OrderBy(x => x.constante).Select(x => x.constante).LastAsync();
            return response;
        }

        async Task<bool> IRecepcionDeCompraRepository.ExisteAsync(Guid id)
            => await _context.RecepcionesDeCompra.Where(x => x.recepcion_compra_id.Equals(id)).AnyAsync();
    }
}