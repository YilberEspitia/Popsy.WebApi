using AutoMapper;

using Popsy.Common;
using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Business
{
    /// <summary>
    /// Negocio relacionado con la gestión del legado.
    /// </summary>
    public class LegadoBusiness : ApplicationBase, ILegadoBusiness
    {
        private readonly IPuntosVentasRepository _puntosVentaRepository;
        private readonly IRecepcionDeCompraRepository _recepcionDeCompraRepository;
        private readonly IInventarioNuevoRepository _inventarioRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ISapSyncIntegration _sapIntegration;
        private readonly IDetalleOrdenDeCompraRepository _detalleOrdenRepository;
        public LegadoBusiness(IMapper mapper,
            IPuntosVentasRepository puntosVentaRepository,
            IRecepcionDeCompraRepository recepcionDeCompraRepository,
            IInventarioNuevoRepository inventarioRepository,
            IPedidoRepository pedidoRepository,
            ISapSyncIntegration sapIntegration,
            IDetalleOrdenDeCompraRepository detalleOrdenRepository) : base(mapper)
        {
            _puntosVentaRepository = puntosVentaRepository;
            _recepcionDeCompraRepository = recepcionDeCompraRepository;
            _inventarioRepository = inventarioRepository;
            _pedidoRepository = pedidoRepository;
            _sapIntegration = sapIntegration;
            _detalleOrdenRepository = detalleOrdenRepository;
        }

        async Task<IEnumerable<SeguimientoPDVObject>> ILegadoBusiness.GetSeguimientoPDVsAsync()
        {
            List<SeguimientoPDVObject> response = new List<SeguimientoPDVObject>();
            foreach (SeguimientoPDVObjectBase seguimientoBase in await _puntosVentaRepository.GetPuntosPorSeguimientoPDVsAsync())
            {
                response.Add(new SeguimientoPDVObject
                {
                    PuntoDeVenta = seguimientoBase.PuntoDeVenta,
                    Punto_venta_id = seguimientoBase.Punto_venta_id,
                    TicketsICG = seguimientoBase.TicketsICG,
                    FechaUltimaActualizacionICG = seguimientoBase.FechaUltimaActualizacionICG,
                    TicketsTracker = seguimientoBase.TicketsTracker,
                    FechaUltimaActualizacionTracker = seguimientoBase.FechaUltimaActualizacionTracker,
                    PendientesDetalle = seguimientoBase.PendientesDetalle,
                    FechaInventario = await _puntosVentaRepository.GetFechaTomaInventarioAsync(seguimientoBase.Punto_venta_id),
                    TicketsSIPOP = seguimientoBase.PendientesDetalle.PendientesPedidos + seguimientoBase.PendientesDetalle.PendientesInventarios + seguimientoBase.PendientesDetalle.PendientesRecepciones
                });
            }
            return response;
        }

        async Task<IEnumerable<DetalleSeguimientoPDVObject>> ILegadoBusiness.GetSeguimientoPDVDetalleAsync(Guid punto_venta_id)
            => ((await this.GetSeguimientosPDVDetalleAsync(punto_venta_id, SAPType.Pedido)).Concat(await this.GetSeguimientosPDVDetalleAsync(punto_venta_id, SAPType.Inventario))).Concat(await this.GetSeguimientosPDVDetalleAsync(punto_venta_id, SAPType.RecepcionDeCompra));
        async Task<IEnumerable<DetalleSeguimientoPDVObject>> ILegadoBusiness.GetSeguimientoPDVDetalleAsync(Guid punto_venta_id, SAPType tipo)
            => await this.GetSeguimientosPDVDetalleAsync(punto_venta_id, tipo);

        async Task<DetalleSeguimientoPDVObject> ILegadoBusiness.GetSeguimientoPDVDetalleAsync(Guid punto_venta_id, Guid id, SAPType tipo)
        {
            if (!await _puntosVentaRepository.ExistePuntoDeVentaAsync(punto_venta_id))
                throw new PopsyException(ErrorType.PuntoDeVentaNoEncontrado, ErrorSource.NoEncontrado);
            DetalleSeguimientoPDVObject? response = default;
            switch (tipo)
            {
                case SAPType.Pedido:
                    response = await _puntosVentaRepository.GetSeguimientoPDVDetallePedidoAsync(punto_venta_id, id);
                    break;
                case SAPType.Inventario:
                    response = await _puntosVentaRepository.GetSeguimientoPDVDetalleInventarioAsync(punto_venta_id, id);
                    break;
                case SAPType.RecepcionDeCompra:
                    response = await _puntosVentaRepository.GetSeguimientoPDVDetalleRecepcionAsync(punto_venta_id, id);
                    break;
                default:
                    break;
            }
            if (response is null)
                throw new PopsyException(ErrorType.DetalleSeguimientoNoEncontrado, ErrorSource.NoEncontrado);
            return response;
        }

        private async Task<IEnumerable<DetalleSeguimientoPDVObject>> GetSeguimientosPDVDetalleAsync(Guid punto_venta_id, SAPType tipo)
        {
            if (!await _puntosVentaRepository.ExistePuntoDeVentaAsync(punto_venta_id))
                throw new PopsyException(ErrorType.PuntoDeVentaNoEncontrado, ErrorSource.NoEncontrado);
            List<DetalleSeguimientoPDVObject> response = new List<DetalleSeguimientoPDVObject>();

            switch (tipo)
            {
                case SAPType.Pedido:
                    foreach (Guid id in await _puntosVentaRepository.GetSeguimientoPDVDetallePedidosAsync(punto_venta_id))
                    {
                        if (await _puntosVentaRepository.GetSeguimientoPDVDetallePedidoAsync(punto_venta_id, id) is DetalleSeguimientoPDVObject detalle)
                            response.Add(detalle);
                    }
                    break;
                case SAPType.Inventario:
                    foreach (Guid id in await _puntosVentaRepository.GetSeguimientoPDVDetalleInventariosAsync(punto_venta_id))
                    {
                        if (await _puntosVentaRepository.GetSeguimientoPDVDetalleInventarioAsync(punto_venta_id, id) is DetalleSeguimientoPDVObject detalle)
                            response.Add(detalle);
                    }
                    break;
                case SAPType.RecepcionDeCompra:
                    foreach (Guid id in await _puntosVentaRepository.GetSeguimientoPDVDetalleRecepcionesAsync(punto_venta_id))
                    {
                        if (await _puntosVentaRepository.GetSeguimientoPDVDetalleRecepcionAsync(punto_venta_id, id) is DetalleSeguimientoPDVObject detalle)
                            response.Add(detalle);
                    }
                    break;
                default:
                    break;
            }
            return response;
        }

        async Task<bool> ILegadoBusiness.UpdateEstadoAsync(Guid id, SAPType tipo, SAPEstado nuevo_estado)
        {
            bool response = false;
            switch (tipo)
            {
                case SAPType.Pedido:
                    if (!await _pedidoRepository.ExisteAsync(id))
                        throw new PopsyException(ErrorType.PedidoNoEncontrado, ErrorSource.NoEncontrado);
                    response = await _pedidoRepository.UpdateEstadoAsync(id, nuevo_estado);
                    break;
                case SAPType.Inventario:
                    if (!await _inventarioRepository.ExisteAsync(id))
                        throw new PopsyException(ErrorType.InventarioNoEncontrado, ErrorSource.NoEncontrado);
                    response = await _inventarioRepository.UpdateEstadoAsync(id, nuevo_estado);
                    break;
                case SAPType.RecepcionDeCompra:
                    if (!await _recepcionDeCompraRepository.ExisteAsync(id))
                        throw new PopsyException(ErrorType.RecepcionDeCompraNoEncontrada, ErrorSource.NoEncontrado);
                    response = await _recepcionDeCompraRepository.UpdateEstadoAsync(id, nuevo_estado);
                    break;
                default:
                    break;
            }
            return response;
        }

        async Task<ResponseRecepcionDeCompraXMLObject> ILegadoBusiness.EnviarRecepcionDeCompra(Guid punto_venta_id, Guid recepcion_compra_id)
            => await this.EnviarRecepcionDeCompra(punto_venta_id, recepcion_compra_id);

        async Task<ResponseRecepcionDeCompraXMLTotalObject> ILegadoBusiness.EnviarRecepcionesDeCompra()
        {
            ResponseRecepcionDeCompraXMLTotalObject response = new ResponseRecepcionDeCompraXMLTotalObject();
            Int32 envios = 0;
            Int32 errores = 0;
            foreach (PendientesBasicObject pendiente in await _recepcionDeCompraRepository.GetPendientesBasic())
            {
                try
                {
                    response.Detalle.Add(await this.EnviarRecepcionDeCompra(pendiente.Punto_venta_id, pendiente.Id));
                    envios++;
                }
                catch (Exception)
                {
                    errores++;
                }
            }
            response.Envios = envios;
            response.Errores = errores;
            return response;
        }
        async Task<InventarioGestionSAP> ILegadoBusiness.GestionarStockAsync(Guid punto_venta_id, DateTime fecha_stock)
        {
            if (await _puntosVentaRepository.GetPuntoVentasId(punto_venta_id) is TblPuntoVentaEntity puntoDeVenta)
            {
                if (await _inventarioRepository.GetInventarioGestionAsync(punto_venta_id, fecha_stock) is InventarioGestionSAP inventarioGestion)
                {
                    ResponseSAP<ResultStockDia>? response = await _sapIntegration.GetStockDia(fecha_stock.ToString("yyyyMMdd"), puntoDeVenta.codigo);
                    if (response is not null && response.d.results.Any())
                    {
                        inventarioGestion.Detalles = inventarioGestion.Detalles.Select(d =>
                        {
                            Double stock_fecha = 0;
                            Double.TryParse(response.d.results.Where(r => r.idsku.ToUpper().Equals(d.Codigo.ToUpper())).Select(r => r.stockcierre).FirstOrDefault(), out stock_fecha);
                            d.Stock_fecha = stock_fecha;
                            return d;
                        });
                    }
                    return inventarioGestion;
                    //TODO: Enviar a SAP
                    //else
                    //    throw new PopsyException(ErrorType.StockNoEncontrado, ErrorSource.NoEncontrado);
                }
                else
                    throw new PopsyException(ErrorType.InventarioNoEncontrado, ErrorSource.NoEncontrado);
            }
            else
                throw new PopsyException(ErrorType.PuntoDeVentaNoEncontrado, ErrorSource.NoEncontrado);
        }

        #region Private
        async Task<ResponseRecepcionDeCompraXMLObject> EnviarRecepcionDeCompra(Guid punto_venta_id, Guid recepcion_compra_id)
        {
            ResponseRecepcionDeCompraXMLObject response = new ResponseRecepcionDeCompraXMLObject();
            if (!await _puntosVentaRepository.ExistePuntoDeVentaAsync(punto_venta_id))
                throw new PopsyException(ErrorType.PuntoDeVentaNoEncontrado, ErrorSource.NoEncontrado);
            TblRecepcionDeCompraEntity? recepcionDeCompraDB = await _recepcionDeCompraRepository.GetRecepcionDeCompraAsync(recepcion_compra_id, SAPEstado.Pendiente);
            if (recepcionDeCompraDB is null)
                throw new PopsyException(ErrorType.RecepcionDeCompraNoEncontrada, ErrorSource.NoEncontrado);
            else
            {
                if (await _recepcionDeCompraRepository.GetUltimoXml(recepcionDeCompraDB.recepcion_compra_id) is String xml)
                {
                    response = await _sapIntegration.EnviaRecepcionDeCompra(xml, recepcionDeCompraDB.recepcion_compra_id);
                    await _recepcionDeCompraRepository.CrearHistorialAsync(new TblHistorialEnvioRecepcionDeCompraEntity
                    {
                        XML = response.XML,
                        recepcion_compra_id = recepcionDeCompraDB.recepcion_compra_id
                    });
                    if (response.Respuestas.Any())
                    {
                        await _recepcionDeCompraRepository.UpdateEstadoResponseAsync(recepcionDeCompraDB.recepcion_compra_id, false);
                        foreach (ResponseRecepcionDeCompraObject responseSendXML in response.Respuestas)
                        {
                            if (responseSendXML is not null)
                            {
                                Boolean compleado = responseSendXML.Type is not null && !responseSendXML.Type.Equals(PopsyConstants.SAPErrorType);
                                responseSendXML.Activo = !compleado;
                                await _recepcionDeCompraRepository.CreateAsync(_mapper.Map<TblResponseRecepcionDeCompraEntity>(responseSendXML));
                                if (compleado)
                                    await _recepcionDeCompraRepository.UpdateEstadoAsync(recepcionDeCompraDB.recepcion_compra_id, SAPEstado.Enviado);
                            }
                        }
                    }
                }
                else
                    throw new PopsyException(ErrorType.XMLNoEncontrado, ErrorSource.NoEncontrado);
            }
            return response;
        }
        #endregion
    }
}
