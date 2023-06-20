using Microsoft.EntityFrameworkCore;

using Popsy.Common;
using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

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

        async Task<Guid> IRecepcionDeCompraRepository.CreateAsync(TblRecepcionDeCompraEntity recepcionDeCompra)
        {
            recepcionDeCompra.fecha_modificacion = DateTime.Now;
            await _context.AddAsync(recepcionDeCompra);
            await _context.SaveChangesAsync();
            return recepcionDeCompra.recepcion_compra_id;
        }

        async Task<bool> IRecepcionDeCompraRepository.CreateAsync(TblResponseRecepcionDeCompraEntity responseRecepcionDeCompra)
        {
            responseRecepcionDeCompra.fecha_modificacion = DateTime.Now;
            await _context.AddAsync(responseRecepcionDeCompra);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<bool> IRecepcionDeCompraRepository.UpdateAsync(TblRecepcionDeCompraEntity recepcionDeCompra)
        {
            recepcionDeCompra.fecha_modificacion = DateTime.Now;
            TblRecepcionDeCompraEntity recepcionDeCompraDb = await this._context.RecepcionesDeCompra.SingleAsync(r => r.recepcion_compra_id.Equals(recepcionDeCompra.recepcion_compra_id));
            this._context.Entry(recepcionDeCompraDb).CurrentValues.SetValues(recepcionDeCompra);
            await this._context.SaveChangesAsync();
            return true;
        }

        async Task<TblRecepcionDeCompraEntity?> IRecepcionDeCompraRepository.GetRecepcionDeCompraAsync(Guid id)
            => await _context.RecepcionesDeCompra.Include(x => x.recepciones_compras_detalles).Where(x => x.recepcion_compra_id.Equals(id)).FirstOrDefaultAsync();

        async Task<TblRecepcionDeCompraEntity?> IRecepcionDeCompraRepository.GetRecepcionDeCompraAsync(Guid id, SAPEstado estado)
            => await _context.RecepcionesDeCompra.Include(x => x.recepciones_compras_detalles).Where(x => x.recepcion_compra_id.Equals(id) && x.estado.Equals(estado)).FirstOrDefaultAsync();

        async Task<IEnumerable<TblRecepcionDeCompraEntity>> IRecepcionDeCompraRepository.GetRecepcionesDeComprasAsync()
            => await _context.RecepcionesDeCompra.Include(x => x.recepciones_compras_detalles).OrderBy(x => x.codigo_recepcion_compra).ToListAsync();

        async Task<IEnumerable<TblRecepcionDeCompraEntity>> IRecepcionDeCompraRepository.GetRecepcionesDeComprasPorDetalleAsync(Guid orden_compra_id)
            => await _context.RecepcionesDeCompra.Include(x => x.recepciones_compras_detalles).Where(x => x.orden_compra_id.Equals(orden_compra_id)).OrderBy(x => x.codigo_recepcion_compra).ToListAsync();

        async Task<IEnumerable<TblRecepcionDeCompraEntity>> IRecepcionDeCompraRepository.GetRecepcionesDeComprasPorCodigoAsync(string codigo)
            => await _context.RecepcionesDeCompra.Include(x => x.recepciones_compras_detalles).Where(x => x.codigo_recepcion_compra.ToUpper().Equals(codigo.ToUpper())).OrderBy(x => x.codigo_recepcion_compra).ToListAsync();

        async Task<int> IRecepcionDeCompraRepository.GetConstante()
        {
            int response = 0;
            if (await _context.RecepcionesDeCompra.AnyAsync())
                response = await _context.RecepcionesDeCompra.OrderBy(x => x.constante).Select(x => x.constante).LastAsync();
            return response;
        }

        async Task<bool> IRecepcionDeCompraRepository.ExisteAsync(Guid id)
            => await _context.RecepcionesDeCompra.Where(x => x.recepcion_compra_id.Equals(id)).AnyAsync();

        async Task<bool> IRecepcionDeCompraRepository.UpdateEstadoAsync(Guid recepcion_compra_id, SAPEstado nuevo_estado)
        {
            bool response = false;
            if (await _context.RecepcionesDeCompra.Where(x => x.recepcion_compra_id.Equals(recepcion_compra_id)).FirstOrDefaultAsync() is TblRecepcionDeCompraEntity recepcionDeCompra)
            {
                if (!recepcionDeCompra.estado.Equals(nuevo_estado))
                {
                    recepcionDeCompra.estado = nuevo_estado;
                    await _context.SaveChangesAsync();
                    response = true;
                }
            }
            return response;
        }

        async Task IRecepcionDeCompraRepository.UpdateEstadoResponseAsync(Guid recepcion_compra_id, Boolean activo)
        {
            bool response = false;
            foreach (TblResponseRecepcionDeCompraEntity respuesta in await _context.RespuestasRecepcionDeCompras.Where(x => x.recepcion_compra_id.Equals(recepcion_compra_id)).ToListAsync())
            {
                respuesta.Activo = activo;
                response = true;
            }
            if (response)
                await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<PendientesBasicObject>> IRecepcionDeCompraRepository.GetPendientesBasic()
            => await _context.RespuestasRecepcionDeCompras.Include(x => x.recepcion_compra).ThenInclude(x => x.orden_de_compra).Where(x => !String.IsNullOrEmpty(x.Type) && x.Type.Equals(PopsyConstants.SAPErrorType) && x.recepcion_compra.estado.Equals(SAPEstado.Pendiente) && x.Activo)
                .Select(x => new PendientesBasicObject
                {
                    Id = x.recepcion_compra.recepcion_compra_id,
                    Punto_venta_id = x.recepcion_compra.orden_de_compra.punto_venta_id
                }).ToListAsync();

        async Task<Boolean> IRecepcionDeCompraRepository.CrearHistorialAsync(TblHistorialEnvioRecepcionDeCompraEntity historial)
        {
            historial.fecha_modificacion = DateTime.Now;
            await _context.AddAsync(historial);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<TblHistorialEnvioRecepcionDeCompraEntity?> IRecepcionDeCompraRepository.GetUltimoHistorial(Guid recepcion_compra_id)
            => await _context.HistorialEnviosRecepcionDeCompra.Where(x => x.recepcion_compra_id.Equals(recepcion_compra_id)).OrderBy(x => x.fecha_creacion).LastOrDefaultAsync();
        async Task<String?> IRecepcionDeCompraRepository.GetUltimoXml(Guid recepcion_compra_id)
            => await _context.HistorialEnviosRecepcionDeCompra.Where(x => x.recepcion_compra_id.Equals(recepcion_compra_id)).OrderBy(x => x.fecha_creacion).Select(x => x.XML).LastOrDefaultAsync();
    }
}