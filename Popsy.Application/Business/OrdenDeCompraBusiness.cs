using System.Text.RegularExpressions;

using AutoMapper;

using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Business
{
    /// <summary>
    /// Implementa la lógica de negocio relacionada con el módulo de ordenes de compra.
    /// </summary>
    public class OrdenDeCompraBusiness : ApplicationBase, IOrdenDeCompraBusiness
    {
        /// <summary>
        /// <see cref="IProveedorRecepcionRepository"/> repositorio.
        /// </summary>
        private readonly IOrdenDeCompraRepository _ordenRepository;
        /// <summary>
        /// <see cref="IDetalleOrdenDeCompraRepository"/> repositorio.
        /// </summary>
        private readonly IDetalleOrdenDeCompraRepository _detalleOrdenRepository;
        /// <summary>
        /// <see cref="IRecepcionDeCompraRepository"/> repositorio.
        /// </summary>
        private readonly IRecepcionDeCompraRepository _recepcionRepository;
        /// <summary>
        /// <see cref="ISapSyncIntegration"/> repositorio.
        /// </summary>
        private readonly ISapSyncIntegration _sapIntegration;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mapper">mapper.</param>
        /// <param name="ordenRepository"><see cref="IOrdenDeCompraRepository"/> repositorio.</param>
        /// <param name="detalleOrdenRepository"><see cref="IDetalleOrdenDeCompraRepository"/> repositorio.</param>
        /// <param name="recepcionRepository"><see cref="IRecepcionDeCompraRepository"/> repositorio.</param>
        public OrdenDeCompraBusiness(IMapper mapper,
            IOrdenDeCompraRepository ordenRepository,
            IDetalleOrdenDeCompraRepository detalleOrdenRepository,
            IRecepcionDeCompraRepository recepcionRepository,
            ISapSyncIntegration sapIntegration) : base(mapper)
        {
            _ordenRepository = ordenRepository;
            _detalleOrdenRepository = detalleOrdenRepository;
            _recepcionRepository = recepcionRepository;
            _sapIntegration = sapIntegration;
        }

        #region OrdenDeCompra
        async Task<bool> IOrdenDeCompraBusiness.CreateAsync(OrdenDeCompraSave ordenDeCompraSave)
        {
            Boolean response;
            if (!await _ordenRepository.ExisteProveedorRecepcionAsync(ordenDeCompraSave.proveedor_recepcion_id))
                throw new PopsyException(ErrorType.ProveedorNoEncontrado);
            if (!await _ordenRepository.ExistePuntoDeVentaAsync(ordenDeCompraSave.punto_venta_id))
                throw new PopsyException(ErrorType.PuntoDeVentaNoEncontrado);
            TblOrdenDeCompraEntity ordenDeCompra = _mapper.Map<TblOrdenDeCompraEntity>(ordenDeCompraSave);
            Guid orden_id = ordenDeCompra.orden_compra_id;
            TblOrdenDeCompraEntity? ordenDeCompraDb = default;
            if (ordenDeCompra.orden_compra_id != default)
                ordenDeCompraDb = await _ordenRepository.GetOrdenDeCompraAsync(ordenDeCompra.orden_compra_id);
            if (ordenDeCompraDb is null)
            {
                orden_id = await _ordenRepository.CreateAsync(ordenDeCompra);
                response = true;
            }
            else
            {
                ordenDeCompra.orden_compra_id = ordenDeCompraDb.orden_compra_id;
                orden_id = ordenDeCompra.orden_compra_id;
                await _ordenRepository.UpdateAsync(ordenDeCompra);
                response = false;
            }
            if (ordenDeCompraSave.detalles_ordenes_de_compra.Any())
            {
                IEnumerable<TblDetalleOrdenDeCompraEntity> detalles = _mapper.Map<IEnumerable<TblDetalleOrdenDeCompraEntity>>(ordenDeCompraSave.detalles_ordenes_de_compra);
                foreach (TblDetalleOrdenDeCompraEntity detalle in detalles)
                {
                    detalle.orden_compra_id = orden_id;
                    await this.CrearDetalleAsync(detalle);
                }
            }
            return response;
        }

        async Task<OrdenDeCompraRead> IOrdenDeCompraBusiness.GetOrdenDeCompraAsync(string ordenDeCompra)
        {
            TblOrdenDeCompraEntity? ordenDeCompraDb = await _ordenRepository.GetOrdenDeCompraAsync(ordenDeCompra);
            if (ordenDeCompraDb is null)
                throw new PopsyException(ErrorType.OrdenDeCompraNoEncontrada);
            else
                return _mapper.Map<OrdenDeCompraRead>(ordenDeCompraDb);
        }

        async Task<OrdenDeCompraRead> IOrdenDeCompraBusiness.GetOrdenDeCompraAsync(Guid id)
        {
            TblOrdenDeCompraEntity? ordenDeCompraDb = await _ordenRepository.GetOrdenDeCompraAsync(id);
            if (ordenDeCompraDb is null)
                throw new PopsyException(ErrorType.OrdenDeCompraNoEncontrada);
            else
                return _mapper.Map<OrdenDeCompraRead>(ordenDeCompraDb);
        }

        async Task<IEnumerable<OrdenDeCompraRead>> IOrdenDeCompraBusiness.GetOrdenesDeCompraAsync()
            => _mapper.Map<IEnumerable<OrdenDeCompraRead>>(await _ordenRepository.GetOrdenesDeCompraAsync());

        async Task<IEnumerable<OrdenDeCompraRead>> IOrdenDeCompraBusiness.GetOrdenesDeCompraPorProveedorAsync(Guid proveedor_recepcion_id)
            => _mapper.Map<IEnumerable<OrdenDeCompraRead>>(await _ordenRepository.GetOrdenesDeCompraPorProveedorAsync(proveedor_recepcion_id));

        async Task<IEnumerable<OrdenDeCompraRead>> IOrdenDeCompraBusiness.GetOrdenesDeCompraPorPuntoAsync(Guid punto_venta_id)
            => _mapper.Map<IEnumerable<OrdenDeCompraRead>>(await _ordenRepository.GetOrdenesDeCompraPorPuntoAsync(punto_venta_id));
        #endregion

        #region Detalle
        async Task<bool> IOrdenDeCompraBusiness.CreateAsync(DetalleOrdenDeCompraSave detalleOrdenDeCompraSave)
        {
            Boolean response;
            if (!await _ordenRepository.ExisteAsync(detalleOrdenDeCompraSave.orden_compra_id))
                throw new PopsyException(ErrorType.OrdenDeCompraNoEncontrada);
            if (!await _detalleOrdenRepository.ExisteProductoAsync(detalleOrdenDeCompraSave.producto_id))
                throw new PopsyException(ErrorType.ProveedorNoEncontrado);
            TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra = _mapper.Map<TblDetalleOrdenDeCompraEntity>(detalleOrdenDeCompraSave);
            TblDetalleOrdenDeCompraEntity? detalleOrdenDeCompraDb = default;
            if (detalleOrdenDeCompra.detalle_orden_compra_id != default)
                detalleOrdenDeCompraDb = await _detalleOrdenRepository.GetDetalleOrdenDeCompraAsync(detalleOrdenDeCompra.detalle_orden_compra_id);
            if (detalleOrdenDeCompraDb is null)
            {
                await _detalleOrdenRepository.CreateAsync(detalleOrdenDeCompra);
                response = true;
            }
            else
            {
                detalleOrdenDeCompra.detalle_orden_compra_id = detalleOrdenDeCompraDb.detalle_orden_compra_id;
                await _detalleOrdenRepository.UpdateAsync(detalleOrdenDeCompra);
                response = false;
            }
            return response;
        }

        async Task<bool> IOrdenDeCompraBusiness.CreateManyAsync(IEnumerable<DetalleOrdenDeCompraSave> detalleOrdenDeCompra)
        {
            bool response = false;
            IEnumerable<TblDetalleOrdenDeCompraEntity> detalles = _mapper.Map<IEnumerable<TblDetalleOrdenDeCompraEntity>>(detalleOrdenDeCompra);
            foreach (TblDetalleOrdenDeCompraEntity detalle in detalles)
            {
                await this.CrearDetalleAsync(detalle);
                response = true;
            }
            return response;
        }

        async Task<DetalleOrdenDeCompraRead> IOrdenDeCompraBusiness.GetDetalleOrdenDeCompraAsync(Guid id)
        {
            TblDetalleOrdenDeCompraEntity? detalle = await _detalleOrdenRepository.GetDetalleOrdenDeCompraAsync(id);
            if (detalle is null)
                throw new PopsyException(ErrorType.DetalleDeVentaNoEncontrado);
            else
                return _mapper.Map<DetalleOrdenDeCompraRead>(detalle);
        }

        async Task<IEnumerable<DetalleOrdenDeCompraRead>> IOrdenDeCompraBusiness.GetDetallesDeOrdenesDeCompraAsync()
            => _mapper.Map<IEnumerable<DetalleOrdenDeCompraRead>>(await _detalleOrdenRepository.GetDetallesDeOrdenesDeCompraAsync());

        async Task<IEnumerable<DetalleOrdenDeCompraRead>> IOrdenDeCompraBusiness.GetDetallesDeOrdenesDeCompraPorProductoAsync(Guid producto_id)
            => _mapper.Map<IEnumerable<DetalleOrdenDeCompraRead>>(await _detalleOrdenRepository.GetDetallesDeOrdenesDeCompraPorProductoAsync(producto_id));

        async Task<IEnumerable<DetalleOrdenDeCompraRead>> IOrdenDeCompraBusiness.GetDetallesDeOrdenesDeCompraPorOrdenAsync(Guid orden_compra_id)
            => _mapper.Map<IEnumerable<DetalleOrdenDeCompraRead>>(await _detalleOrdenRepository.GetDetallesDeOrdenesDeCompraPorOrdenAsync(orden_compra_id));
        #endregion

        #region Integraciones
        async Task<IEnumerable<ResponseOrdenesPopsySAP>> IOrdenDeCompraBusiness.SyncSAPAsync()
        {
            ISet<ResponseOrdenesPopsySAP> responsePopsy = new HashSet<ResponseOrdenesPopsySAP>();
            IEnumerable<PuntoDeVentaBasicRead> puntosDeVenta = await _ordenRepository.GetAllPuntosDeVentaAsync();
            foreach (PuntoDeVentaBasicRead puntoDeVenta in puntosDeVenta)
            {
                ResponseSAP<ResultOrdenDeCompra>? response = await _sapIntegration.GetOrdenesDeCompra(puntoDeVenta.codigo);
                if (response is not null && response.d.results.Any())
                {
                    ISet<ResponsePopsyOrdenesSAP> ordenesResponse = new HashSet<ResponsePopsyOrdenesSAP>();
                    foreach (ResultOrdenDeCompra ordenDeCompra in response.d.results.DistinctBy(x => x.DocOC))
                    {
                        try
                        {
                            int posicion_producto = 0;
                            int cantidad_solicitada = 0;
                            ordenDeCompra.Cant_Pedida = ordenDeCompra.Cant_Pedida.Replace(".", "");
                            int.TryParse(ordenDeCompra.PositionDoc, out posicion_producto);
                            int.TryParse(ordenDeCompra.Cant_Pedida, out cantidad_solicitada);
                            DateTime fecha_orden_compra = this.ConvertirFecha(ordenDeCompra.Date_Solped);
                            ResponsePopsyOrdenesSAP responseSapOrden = await this.CrearOrdenesAsync(new OrdenDeCompraSave()
                            {
                                orden_compra = ordenDeCompra.DocOC,
                                punto_venta_id = puntoDeVenta.punto_venta_id,
                                fecha_orden_compra = fecha_orden_compra,
                            }, ordenDeCompra.Proveedor, response.d.results.Where(x => x.DocOC.Equals(ordenDeCompra.DocOC)).Select(x => new DetalleOrdenDeCompraSave()
                            {
                                cantidad_solicitada = cantidad_solicitada,
                                unidad_presentacion_solicitada = ordenDeCompra.UndCompra,
                                posicion_producto = posicion_producto,
                                codigo_producto = ordenDeCompra.CodMaterial
                            }));
                            ordenesResponse.Add(responseSapOrden);
                        }
                        catch (Exception ex)
                        {
                            ordenesResponse.Add(new ResponsePopsyOrdenesSAP()
                            {
                                Codigo = ordenDeCompra.DocOC,
                                Accion = AccionesBD.Error,
                                Error = ex.Message
                            });
                        }
                    }
                    responsePopsy.Add(new ResponseOrdenesPopsySAP()
                    {
                        Punto_venta_id = puntoDeVenta.punto_venta_id,
                        Codigo = puntoDeVenta.codigo,
                        Ordenes = ordenesResponse
                    });
                }
            }
            return responsePopsy;
        }
        #endregion

        #region Private
        private async Task<ResponsePopsyOrdenesSAP> CrearOrdenesAsync(OrdenDeCompraSave ordenDeCompraSave, string proveedor, IEnumerable<DetalleOrdenDeCompraSave> detalles)
        {
            ResponsePopsyOrdenesSAP response = new ResponsePopsyOrdenesSAP()
            {
                Codigo = ordenDeCompraSave.orden_compra,
                Accion = AccionesBD.NoCreado,
                Detalles = new HashSet<ResponsePopsyOrdenesDetallesSAP>()
            };
            if (string.IsNullOrEmpty(proveedor) || !await _ordenRepository.ExisteProveedorRecepcionPorCodigoAsync(proveedor))
                throw new PopsyException(ErrorType.ProveedorNoEncontrado);
            if (!await _ordenRepository.ExistePuntoDeVentaAsync(ordenDeCompraSave.punto_venta_id))
                throw new PopsyException(ErrorType.PuntoDeVentaNoEncontrado);
            Guid ordenId;
            ordenDeCompraSave.proveedor_recepcion_id = await _ordenRepository.GetIdProveedorRecepcionPorCodigoAsync(proveedor);
            TblOrdenDeCompraEntity ordenDeCompra = _mapper.Map<TblOrdenDeCompraEntity>(ordenDeCompraSave);
            TblOrdenDeCompraEntity? ordenDeCompraDb = default;
            if (ordenDeCompra.orden_compra != default)
                ordenDeCompraDb = await _ordenRepository.GetOrdenDeCompraPorCodigoAsync(ordenDeCompra.orden_compra);
            if (ordenDeCompraDb == default && ordenDeCompra.orden_compra_id != default)
                ordenDeCompraDb = await _ordenRepository.GetOrdenDeCompraAsync(ordenDeCompra.orden_compra_id);
            if (ordenDeCompraDb is null)
            {
                ordenId = await _ordenRepository.CreateAsync(ordenDeCompra);
                response.Accion = AccionesBD.Creado;
            }
            else
            {
                ordenDeCompra.orden_compra_id = ordenDeCompraDb.orden_compra_id;
                ordenId = ordenDeCompra.orden_compra_id;
                if (this.TieneCambios(ordenDeCompraDb, ordenDeCompra))
                {
                    await _ordenRepository.UpdateAsync(ordenDeCompra);
                    response.Accion = AccionesBD.Actualizado;
                }
                else
                    response.Accion = AccionesBD.NoActualizado;
            }
            await _detalleOrdenRepository.UpdateEstadoDetalles(ordenId, false);
            foreach (DetalleOrdenDeCompraSave detalle in detalles)
            {
                if (!string.IsNullOrEmpty(detalle.codigo_producto) && await _detalleOrdenRepository.ExisteProductoAsync(detalle.codigo_producto))
                {
                    Guid detalle_id = default;
                    try
                    {
                        AccionesBD accionDetalle = AccionesBD.NoCreado;
                        detalle.orden_compra_id = ordenId;
                        detalle.producto_id = await _detalleOrdenRepository.GetProductoPorCodigoAsync(detalle.codigo_producto);
                        TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra = _mapper.Map<TblDetalleOrdenDeCompraEntity>(detalle);
                        detalleOrdenDeCompra.activo = true;
                        TblDetalleOrdenDeCompraEntity? detalleOrdenDeCompraDb = await _detalleOrdenRepository.GetDetalleAsync(detalle.orden_compra_id, detalle.producto_id, detalle.unidad_presentacion_solicitada);
                        if (detalleOrdenDeCompraDb is null)
                        {
                            detalle_id = await _detalleOrdenRepository.CreateAsync(detalleOrdenDeCompra);
                            accionDetalle = AccionesBD.Creado;
                        }
                        else
                        {
                            detalleOrdenDeCompra.detalle_orden_compra_id = detalleOrdenDeCompraDb.detalle_orden_compra_id;
                            detalle_id = detalleOrdenDeCompra.detalle_orden_compra_id;
                            if (this.DetalleTieneCambios(detalleOrdenDeCompra, detalleOrdenDeCompraDb))
                            {
                                await _detalleOrdenRepository.UpdateAsync(detalleOrdenDeCompra);
                                accionDetalle = AccionesBD.Actualizado;
                            }
                            else
                            {
                                await _detalleOrdenRepository.UpdateEstadoDetalle(detalleOrdenDeCompra.detalle_orden_compra_id, true);
                                accionDetalle = AccionesBD.NoActualizado;
                            }
                        }
                        response.Detalles.Add(new ResponsePopsyOrdenesDetallesSAP
                        {
                            detalle_orden_compra_id = detalle_id,
                            Accion = accionDetalle
                        });
                    }
                    catch (Exception ex)
                    {
                        response.Detalles.Add(new ResponsePopsyOrdenesDetallesSAP
                        {
                            detalle_orden_compra_id = detalle_id,
                            Accion = AccionesBD.Error,
                            Error = ex.Message
                        });
                    }
                }
            }
            return response;
        }

        private bool TieneCambios(TblOrdenDeCompraEntity ordenDeCompra, TblOrdenDeCompraEntity ordenDeCompraDb)
            => ordenDeCompra.orden_compra != ordenDeCompraDb.orden_compra ||
            ordenDeCompra.punto_venta_id != ordenDeCompraDb.punto_venta_id ||
            ordenDeCompra.fecha_orden_compra != ordenDeCompraDb.fecha_orden_compra ||
            ordenDeCompra.proveedor_recepcion_id != ordenDeCompraDb.proveedor_recepcion_id;

        private bool DetalleTieneCambios(TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra, TblDetalleOrdenDeCompraEntity detalleOrdenDeCompraDb)
            => detalleOrdenDeCompra.cantidad_solicitada != detalleOrdenDeCompraDb.cantidad_solicitada ||
            detalleOrdenDeCompra.unidad_presentacion_solicitada != detalleOrdenDeCompraDb.unidad_presentacion_solicitada ||
            detalleOrdenDeCompra.posicion_producto != detalleOrdenDeCompraDb.posicion_producto;

        public DateTime ConvertirFecha(string fecha)
        {
            DateTime fechaConvertida = default;
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(fecha);
            if (match.Success)
            {
                long milisegundos;
                if (long.TryParse(match.Value, out milisegundos))
                {
                    DateTimeOffset fechaOffset = DateTimeOffset.FromUnixTimeMilliseconds(milisegundos);
                    fechaConvertida = fechaOffset.DateTime;
                }
            }
            return fechaConvertida;
        }

        private async Task CrearDetalleAsync(TblDetalleOrdenDeCompraEntity detalle)
        {
            if (await _ordenRepository.ExisteAsync(detalle.orden_compra_id) && await _detalleOrdenRepository.ExisteProductoAsync(detalle.producto_id))
            {
                TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra = detalle;
                TblDetalleOrdenDeCompraEntity? detalleOrdenDeCompraDb = default;
                if (detalleOrdenDeCompra.detalle_orden_compra_id != default)
                    detalleOrdenDeCompraDb = await _detalleOrdenRepository.GetDetalleOrdenDeCompraAsync(detalleOrdenDeCompra.detalle_orden_compra_id);
                if (detalleOrdenDeCompraDb is null)
                    await _detalleOrdenRepository.CreateAsync(detalleOrdenDeCompra);
                else
                    await _detalleOrdenRepository.UpdateAsync(detalleOrdenDeCompra);
            }
        }
        #endregion
    }
}
