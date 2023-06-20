using Microsoft.EntityFrameworkCore;

using Popsy.Common;
using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Repositories
{
    public class PuntosVentasRepository : IPuntosVentasRepository
    {
        private readonly PopsyDbContext _context;

        public PuntosVentasRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<IEnumerable<Guid>> IPuntosVentasRepository.GetAllPuntosVentaAsyn()
            => await _context.PuntosDeVenta.Select(x => x.punto_venta_id).ToListAsync();

        async Task<TblPuntoVentaEntity?> IPuntosVentasRepository.GetPuntoVentasId(Guid punto_venta_id)
            => await _context.PuntosDeVenta.FirstOrDefaultAsync(l => l.punto_venta_id == punto_venta_id);

        async Task<bool> IPuntosVentasRepository.ExistePuntoDeVentaAsync(Guid punto_venta_id)
            => await _context.PuntosDeVenta.Where(x => x.punto_venta_id.Equals(punto_venta_id)).AnyAsync();

        async Task<IEnumerable<SeguimientoPDVObjectBase>> IPuntosVentasRepository.GetPuntosPorSeguimientoPDVsAsync()
        {
            List<SeguimientoPDVObjectBase> response = new List<SeguimientoPDVObjectBase>();
            foreach (TblSeguimientoPDVEntity? seguimiento in await _context.SeguimientosPDV
                        .GroupBy(x => x.PdV)
                        .Select(g => g.OrderBy(x => x.ULTIMA_ACTUALIZACION).FirstOrDefault())
                        .ToListAsync())
            {
                if (seguimiento is not null && seguimiento.PdV is not null && await _context.PuntosDeVenta.Include(x => x.inventarios2).Where(x => x.nombre.ToUpper().Equals(seguimiento.PdV.ToUpper())).FirstOrDefaultAsync() is TblPuntoVentaEntity puntoVenta)
                {
                    Int32 ticketsTracker = 0;
                    DateTime fechaUltimaActualizacionTracker = DateTime.Now;
                    if (await _context.SeguimientosPDVTracker.Where(x => x.COMPAÑIA.ToUpper().Equals(seguimiento.COMPAÑIA) && x.PdV != null && x.PdV.ToUpper().Equals(seguimiento.PdV)).FirstOrDefaultAsync() is TblSeguimientoPDVTrackerEntity tracker)
                    {
                        ticketsTracker = tracker.T_TRACKER;
                        fechaUltimaActualizacionTracker = tracker.ULTIMA_ACTUALIZACION;
                    }
                    PendientesPDVObject pendientes = await this.GetPendientesPDVAsync(puntoVenta.punto_venta_id);
                    if (pendientes.PendientesPedidos > 0 || pendientes.PendientesInventarios > 0 || pendientes.PendientesRecepciones > 0 || seguimiento.T_EN_COLA > 0 || ticketsTracker > 0)
                        response.Add(new SeguimientoPDVObjectBase
                        {
                            PuntoDeVenta = puntoVenta.nombre,
                            Punto_venta_id = puntoVenta.punto_venta_id,
                            TicketsICG = seguimiento.T_EN_COLA,
                            FechaUltimaActualizacionICG = seguimiento.ULTIMA_ACTUALIZACION,
                            TicketsTracker = ticketsTracker,
                            FechaUltimaActualizacionTracker = fechaUltimaActualizacionTracker,
                            PendientesDetalle = pendientes
                        });
                }
            }
            return response;
        }

        async Task<DateTime?> IPuntosVentasRepository.GetFechaTomaInventarioAsync(Guid punto_venta_id)
        {
            DateTime? response = (DateTime?)default;
            if (await _context.PuntosDeVenta.Include(x => x.inventarios2).Where(x => x.punto_venta_id.Equals(punto_venta_id)).FirstOrDefaultAsync() is TblPuntoVentaEntity puntoVenta)
                response = puntoVenta.inventarios2.Where(x => x.estado.Equals(SAPEstado.Pendiente)).OrderByDescending(x => x.fecha_creacion).Select(x => (DateTime?)x.fecha_creacion).FirstOrDefault();
            return response;
        }

        async Task<PendientesPDVObject> IPuntosVentasRepository.GetPendientesPDVAsync(Guid punto_venta_id)
            => await this.GetPendientesPDVAsync(punto_venta_id);

        async Task<PendientesPDVObject> GetPendientesPDVAsync(Guid punto_venta_id)
            =>
            new PendientesPDVObject
            {
                PendientesPedidos = await _context.Pedidos.Include(x => x.respuestas).Where(x => x.punto_venta_id.Equals(punto_venta_id) && x.estado.Equals(SAPEstado.Pendiente) && x.respuestas.Where(r => r.type.Equals(PopsyConstants.SAPErrorType)).Any()).CountAsync(),
                PendientesInventarios = 0,//await _context.Inventarios2.Where(x => x.punto_venta_id.Equals(punto_venta_id) && x.estado.Equals(SAPEstado.Pendiente)).CountAsync(),
                PendientesRecepciones = await _context.RecepcionesDeCompra.Include(x => x.respuestas).Include(x => x.orden_de_compra).Where(x => x.orden_de_compra.punto_venta_id.Equals(punto_venta_id) && x.estado.Equals(SAPEstado.Pendiente) && x.respuestas.Where(r => !String.IsNullOrEmpty(r.Type) && r.Type.Equals(PopsyConstants.SAPErrorType) && r.Activo).Any()).CountAsync(),
            };

        #region Detalles
        async Task<IEnumerable<Guid>> IPuntosVentasRepository.GetSeguimientoPDVDetallePedidosAsync(Guid punto_venta_id)
            => await _context.PedidosResponse.Include(x => x.pedido).ThenInclude(x => x.punto_de_venta)
                .Where(x => x.pedido.punto_venta_id.Equals(punto_venta_id) && x.pedido.estado.Equals(SAPEstado.Pendiente) && x.type.Equals(PopsyConstants.SAPErrorType))
                .Select(x => x.pedido_id).Distinct().ToListAsync();

        async Task<IEnumerable<Guid>> IPuntosVentasRepository.GetSeguimientoPDVDetalleInventariosAsync(Guid punto_venta_id)
            => await Task.FromResult(Array.Empty<Guid>().AsEnumerable());

        async Task<IEnumerable<Guid>> IPuntosVentasRepository.GetSeguimientoPDVDetalleRecepcionesAsync(Guid punto_venta_id)
            => await _context.RespuestasRecepcionDeCompras.Include(x => x.recepcion_compra).ThenInclude(x => x.orden_de_compra).ThenInclude(x => x.punto_de_venta)
                .Where(x => x.recepcion_compra.orden_de_compra.punto_venta_id.Equals(punto_venta_id) && x.recepcion_compra.estado.Equals(SAPEstado.Pendiente))
                .Select(x => x.recepcion_compra_id).Distinct().ToListAsync();

        async Task<DetalleSeguimientoPDVObject?> IPuntosVentasRepository.GetSeguimientoPDVDetallePedidoAsync(Guid punto_venta_id, Guid pedido_id)
            => await _context.Pedidos.Include(x => x.punto_de_venta)
                .Where(x => x.punto_venta_id.Equals(punto_venta_id) && x.pedido_id.Equals(pedido_id) && x.estado.Equals(SAPEstado.Pendiente)).Select(x => new DetalleSeguimientoPDVObject
                {
                    Id = x.pedido_id,
                    Codigo = x.pedido_id.ToString(),
                    FechaCreacion = x.fecha_creacion,
                    FechaModificacion = x.fecha_modificacion,
                    Mensaje_error = x.respuestas.Where(r => r.type.Equals(PopsyConstants.SAPErrorType)).OrderBy(r => r.fecha_creacion).Select(r => r.message).FirstOrDefault(),
                    Mensajes = x.respuestas.Where(r => r.type.Equals(PopsyConstants.SAPErrorType)).OrderBy(r => r.fecha_creacion).Select(r => r.message).AsEnumerable(),
                    Estado = x.estado,
                    Tipo = SAPType.Pedido,
                }).FirstOrDefaultAsync();

        async Task<DetalleSeguimientoPDVObject?> IPuntosVentasRepository.GetSeguimientoPDVDetalleInventarioAsync(Guid punto_venta_id, Guid inventario_id)
            => await Task.FromResult(new DetalleSeguimientoPDVObject());

        async Task<DetalleSeguimientoPDVObject?> IPuntosVentasRepository.GetSeguimientoPDVDetalleRecepcionAsync(Guid punto_venta_id, Guid recepcion_id)
            => await _context.RecepcionesDeCompra.Include(x => x.orden_de_compra).ThenInclude(x => x.punto_de_venta).Include(x => x.respuestas)
                .Where(x => x.orden_de_compra.punto_venta_id.Equals(punto_venta_id) && x.recepcion_compra_id.Equals(recepcion_id)).Select(x => new DetalleSeguimientoPDVObject
                {
                    Id = x.recepcion_compra_id,
                    Codigo = x.codigo_recepcion_compra,
                    FechaCreacion = x.fecha_creacion,
                    FechaModificacion = x.fecha_modificacion,
                    Mensaje_error = x.respuestas.Where(r => r.Activo && !String.IsNullOrEmpty(r.Type) && r.Type.Equals(PopsyConstants.SAPErrorType)).OrderBy(r => r.Orden).Select(r => r.Message).FirstOrDefault(),
                    Mensajes = x.respuestas.Where(r => r.Activo && !String.IsNullOrEmpty(r.Type) && r.Type.Equals(PopsyConstants.SAPErrorType)).OrderBy(r => r.Orden).Select(r => r.Message).AsEnumerable(),
                    Estado = x.estado,
                    Tipo = SAPType.RecepcionDeCompra,
                }).FirstOrDefaultAsync();
        #endregion
    }
}