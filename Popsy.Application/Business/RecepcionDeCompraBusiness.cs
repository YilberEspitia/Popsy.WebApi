using AutoMapper;

using Popsy.Common;
using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Business
{
    public class RecepcionDeCompraBusiness : ApplicationBase, IRecepcionDeCompraBusiness
    {
        /// <see cref="IProveedorRecepcionRepository"/> repositorio.
        /// </summary>
        private readonly IOrdenDeCompraRepository _ordenRepository;
        /// <summary>
        /// <see cref="IRecepcionDeCompraRepository"/> repositorio.
        /// </summary>
        private readonly IRecepcionDeCompraRepository _recepcionRepository;
        /// <summary>
        /// <see cref="IRecepcionDeCompraDetalleRepository"/> repositorio.
        /// </summary>
        private readonly IRecepcionDeCompraDetalleRepository _detalleRepository;
        /// <summary>
        /// <see cref="IDetalleOrdenDeCompraRepository"/> repositorio.
        /// </summary>
        private readonly IDetalleOrdenDeCompraRepository _detalleOrdenRepository;
        /// <summary>
        /// <see cref="ISapSyncIntegration"/> repositorio.
        /// </summary>
        private readonly ISapSyncIntegration _sapIntegration;
        /// <summary>
        /// <see cref="IEmailService"/> repositorio.
        /// </summary>
        private readonly IEmailService _email;
        /// <summary>
        /// <see cref="IEmailInfoRepository"/> repositorio.
        /// </summary>
        private readonly IEmailInfoRepository _emailInfo;

        public RecepcionDeCompraBusiness(IMapper mapper, IOrdenDeCompraRepository ordenRepository, IRecepcionDeCompraRepository recepcionRepository, IRecepcionDeCompraDetalleRepository detalle, ISapSyncIntegration sapIntegration, IDetalleOrdenDeCompraRepository detalleOrdenRepository, IEmailService email, IEmailInfoRepository emailInfo) : base(mapper)
        {
            _ordenRepository = ordenRepository;
            _recepcionRepository = recepcionRepository;
            _detalleRepository = detalle;
            _sapIntegration = sapIntegration;
            _detalleOrdenRepository = detalleOrdenRepository;
            _email = email;
            _emailInfo = emailInfo;
        }

        #region RecepcionDeCompra
        async Task<string> IRecepcionDeCompraBusiness.CreateAsync(RecepcionDeCompraSave recepcionDeCompraSave)
        {
            if (!await _ordenRepository.ExisteAsync(recepcionDeCompraSave.orden_compra_id))
                throw new PopsyException(ErrorType.OrdenDeCompraNoEncontrada);
            TblRecepcionDeCompraEntity recepcionDeCompra = _mapper.Map<TblRecepcionDeCompraEntity>(recepcionDeCompraSave);
            DateTime fecha_creacion = DateTime.Now;
            Guid recepcion_id = recepcionDeCompra.recepcion_compra_id;
            TblRecepcionDeCompraEntity? recepcionDeCompraDb = default;
            if (recepcionDeCompra.recepcion_compra_id != default)
                recepcionDeCompraDb = await _recepcionRepository.GetRecepcionDeCompraAsync(recepcionDeCompra.recepcion_compra_id);
            if (recepcionDeCompraDb is null)
            {
                recepcionDeCompra.codigo_recepcion_compra = this.GetConsecutivo(await _recepcionRepository.GetConstante());
                recepcion_id = await _recepcionRepository.CreateAsync(recepcionDeCompra);
            }
            else
            {
                fecha_creacion = recepcionDeCompraDb.fecha_creacion;
                recepcionDeCompra.recepcion_compra_id = recepcionDeCompra.recepcion_compra_id;
                recepcion_id = recepcionDeCompra.recepcion_compra_id;
                recepcionDeCompra.codigo_recepcion_compra = recepcionDeCompraDb.codigo_recepcion_compra;
                recepcionDeCompra.constante = recepcionDeCompraDb.constante;
                await _recepcionRepository.UpdateAsync(recepcionDeCompra);
            }
            ISet<Guid> productos_ids = new HashSet<Guid>();
            ISet<int> cantidades_pedidas = new HashSet<int>();
            ISet<int> cantidades_recibidas = new HashSet<int>();
            ISet<string> unidades_de_medida = new HashSet<string>();
            if (recepcionDeCompraSave.recepciones_compras_detalles.Any())
            {
                IEnumerable<TblRecepcionDeCompraDetalleEntity> detalles = _mapper.Map<IEnumerable<TblRecepcionDeCompraDetalleEntity>>(recepcionDeCompraSave.recepciones_compras_detalles);
                foreach (TblRecepcionDeCompraDetalleEntity detalle in detalles)
                {
                    detalle.recepcion_compra_id = recepcion_id;
                    await this.CrearDetalleAsync(detalle);
                }
                List<ItemOrdenDeCompraSAP> items = new List<ItemOrdenDeCompraSAP>();
                foreach (DetalleRecepcionObject detalle in detalles.Select(x => new DetalleRecepcionObject
                {
                    producto_id = x.producto_id,
                    orden_compra_id = recepcionDeCompra.orden_compra_id,
                    unidad_presentacion = x.unidad_presentacion_recibida,
                    cantidad_recibida = x.cantidad_recibida
                }))
                {
                    productos_ids.Add(detalle.producto_id);
                    cantidades_recibidas.Add(detalle.cantidad_recibida);
                    unidades_de_medida.Add(detalle.unidad_presentacion);
                    TblDetalleOrdenDeCompraEntity? detalleOrdenDeCompraDb = await _detalleOrdenRepository.GetDetalleAsync(detalle.orden_compra_id, detalle.producto_id, detalle.unidad_presentacion);
                    if (detalleOrdenDeCompraDb is not null)
                    {
                        cantidades_pedidas.Add(detalleOrdenDeCompraDb.cantidad_solicitada);
                        items.Add(new ItemOrdenDeCompraSAP
                        {
                            PoNumber = detalleOrdenDeCompraDb.orden_de_compra.orden_compra,
                            PoItem = detalleOrdenDeCompraDb.posicion_producto.ToString(),
                            MoveType = "Y01",
                            EntryQnt = detalle.cantidad_recibida.ToString(),
                            EntryUom = detalle.unidad_presentacion,
                            MvtInd = "B"
                        });
                    }
                    else
                        cantidades_pedidas.Add(0);
                }
                ResponseRecepcionDeCompraXMLObject responseXML = await _sapIntegration.EnviaRecepcionDeCompra(new XMLSoMvt()
                {
                    SoMvt = new ItemSoMvt
                    {
                        item = new ItemRecepcionDeCompraSAP
                        {
                            Consecutivo = "001",
                            GoodsmvtCode = "01",
                            PstngDate = fecha_creacion.ToString("yyyy-MM-dd"),
                            VerGrGiSlip = "3",
                            VerGrGiSlipx = "X",
                            SoItem = new ItemSoItem
                            {
                                item = items
                            }
                        }
                    }
                }, recepcion_id);
                await _recepcionRepository.CrearHistorialAsync(new TblHistorialEnvioRecepcionDeCompraEntity
                {
                    XML = responseXML.XML,
                    recepcion_compra_id = recepcion_id
                });
                if (responseXML.Respuestas.Any())
                {
                    await _recepcionRepository.UpdateEstadoResponseAsync(recepcion_id, false);
                    foreach (ResponseRecepcionDeCompraObject responseSendXML in responseXML.Respuestas)
                    {
                        if (responseSendXML is not null)
                        {
                            Boolean compleado = responseSendXML.Type is not null && !responseSendXML.Type.Equals(PopsyConstants.SAPErrorType);
                            responseSendXML.Activo = !compleado;
                            await _recepcionRepository.CreateAsync(_mapper.Map<TblResponseRecepcionDeCompraEntity>(responseSendXML));
                            if (compleado)
                                await _recepcionRepository.UpdateEstadoAsync(recepcion_id, SAPEstado.Enviado);
                        }
                    }
                }
            }
            RecepcionEmailObject recepcionEmail = new RecepcionEmailObject
            {
                Fecha = fecha_creacion.ToString("yyyy-MM-dd"),
                Usuario = await _emailInfo.GetUsuarioMail(recepcionDeCompraSave.usuario_id),
                PuntoDeVenta = await _emailInfo.GetNombrePuntoDeVentaPorRecepcion(recepcion_id),
                Proveedor = await _emailInfo.GetProveedorRepcionPorRecepcion(recepcion_id),
                Factura = recepcionDeCompra.numero_factura,
                Codigo = recepcionDeCompra.codigo_recepcion_compra,
                Productos = await this.GetProductos(productos_ids),
                CantidadesPedidas = this.GetCantidades(cantidades_pedidas),
                CantidadesRecibidas = this.GetCantidades(cantidades_recibidas),
                Unidades = this.GetUnidades(unidades_de_medida)
            };
            this.EnviarCorreoRecepcion(recepcionEmail);
            await _ordenRepository.ActualizarRecepcionDeOrden(recepcionDeCompra.orden_compra_id, true);
            return recepcionDeCompra.codigo_recepcion_compra;
        }

        async Task<RecepcionDeCompraRead> IRecepcionDeCompraBusiness.GetRecepcionDeCompraAsync(Guid id)
        {
            TblRecepcionDeCompraEntity? recepcionDeCompra = await _recepcionRepository.GetRecepcionDeCompraAsync(id);
            if (recepcionDeCompra is null)
                throw new PopsyException(ErrorType.RecepcionDeCompraNoEncontrada);
            else
                return _mapper.Map<RecepcionDeCompraRead>(recepcionDeCompra);
        }

        async Task<IEnumerable<RecepcionDeCompraRead>> IRecepcionDeCompraBusiness.GetRecepcionesDeComprasAsync()
            => _mapper.Map<IEnumerable<RecepcionDeCompraRead>>(await _recepcionRepository.GetRecepcionesDeComprasAsync());

        async Task<IEnumerable<RecepcionDeCompraRead>> IRecepcionDeCompraBusiness.GetRecepcionesDeComprasPorDetalleAsync(Guid detalle_orden_compra_id)
            => _mapper.Map<IEnumerable<RecepcionDeCompraRead>>(await _recepcionRepository.GetRecepcionesDeComprasPorDetalleAsync(detalle_orden_compra_id));

        async Task<IEnumerable<RecepcionDeCompraRead>> IRecepcionDeCompraBusiness.GetRecepcionesDeComprasPorCodigoAsync(string codigo)
            => _mapper.Map<IEnumerable<RecepcionDeCompraRead>>(await _recepcionRepository.GetRecepcionesDeComprasPorCodigoAsync(codigo));
        #endregion

        #region Metodos privados
        private string GetConsecutivo(int constante)
        {
            DateTime fechaActual = DateTime.Now;

            string año = fechaActual.Year.ToString().Substring(2);
            string mes = fechaActual.Month.ToString("D2");
            string dia = fechaActual.Day.ToString("D2");

            string numeroFormateado = (constante + 1).ToString("D6");

            return $"{PopsyConstants.AbrevOrdenDeCompra}-{año}{mes}{dia}{numeroFormateado}"; ;
        }

        private async Task CrearDetalleAsync(TblRecepcionDeCompraDetalleEntity detalle)
        {
            if (await _detalleRepository.ExisteProductoAsync(detalle.producto_id))
            {
                TblRecepcionDeCompraDetalleEntity detalleRecepcionDeCompra = detalle;
                TblRecepcionDeCompraDetalleEntity? detalleRecepcionDeCompraDb = default;
                if (detalleRecepcionDeCompra.recepcion_compra_detalle_id != default)
                    detalleRecepcionDeCompraDb = await _detalleRepository.GetDetalleRecepcionDeCompraAsync(detalleRecepcionDeCompra.recepcion_compra_detalle_id);
                if (detalleRecepcionDeCompraDb is null)
                    await _detalleRepository.CreateAsync(detalleRecepcionDeCompra);
                else
                {
                    detalleRecepcionDeCompra.recepcion_compra_detalle_id = detalleRecepcionDeCompraDb.recepcion_compra_detalle_id;
                    await _detalleRepository.UpdateAsync(detalleRecepcionDeCompra);
                }
            }
        }

        #region Email
        private void EnviarCorreoRecepcion(RecepcionEmailObject recepcionEmail)
        {
            string body = this.ReemplazarParametros(PopsyConstants.RecepcionDeCompraHTMLBody,
                recepcionEmail.Fecha,
                recepcionEmail.Usuario,
                recepcionEmail.PuntoDeVenta,
                recepcionEmail.Proveedor,
                recepcionEmail.Factura,
                recepcionEmail.Codigo,
                recepcionEmail.Productos,
                recepcionEmail.CantidadesPedidas,
                recepcionEmail.CantidadesRecibidas,
                recepcionEmail.Unidades);
            _email.SendEmail(recepcionEmail.Usuario, body, EmailType.RecepcionDeCompra);
        }

        private async Task<string> GetProductos(IEnumerable<Guid> productos_ids)
        {
            string response = String.Empty;
            foreach (Guid producto_id in productos_ids)
            {
                response += await _emailInfo.GetNombreProducto(producto_id) + "<br/>";
            }
            return response;
        }

        private string GetUnidades(IEnumerable<string> unidades)
        {
            string response = String.Empty;
            foreach (string unidad in unidades)
            {
                response += unidad + "<br/>";
            }
            return response;
        }

        private string GetCantidades(IEnumerable<int> cantidades)
        {
            string response = String.Empty;
            foreach (int cantidad in cantidades)
            {
                response += cantidad + "<br/>";
            }
            return response;
        }

        private string ReemplazarParametros(string htmlBody, params String[] parametros)
        {
            string body = htmlBody;
            for (Int16 i = 0; i < parametros.Length; i++)
                body = body.Replace($"{{{i}}}", parametros[i]);
            return body;
        }
        #endregion
        #endregion
    }
}
