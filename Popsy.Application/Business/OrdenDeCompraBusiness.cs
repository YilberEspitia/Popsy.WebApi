using System;
using System.Text.RegularExpressions;

using AutoMapper;

using Popsy.Common;
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
        /// <see cref="ISapRecepcionDeComprasIntegration"/> repositorio.
        /// </summary>
        private readonly ISapRecepcionDeComprasIntegration _sapIntegration;

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
            ISapRecepcionDeComprasIntegration sapIntegration) : base(mapper)
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

        #region RecepcionDeCompra
        async Task<string> IOrdenDeCompraBusiness.CreateAsync(RecepcionDeCompraSave recepcionDeCompraSave)
        {
            if (!await _detalleOrdenRepository.ExisteAsync(recepcionDeCompraSave.detalle_orden_compra_id))
                throw new PopsyException(ErrorType.DetalleDeVentaNoEncontrado);
            TblRecepcionDeCompraEntity recepcionDeCompra = _mapper.Map<TblRecepcionDeCompraEntity>(recepcionDeCompraSave);
            TblRecepcionDeCompraEntity? recepcionDeCompraDb = default;
            if (recepcionDeCompra.recepcion_compra_id != default)
                recepcionDeCompraDb = await _recepcionRepository.GetRecepcionDeCompraAsync(recepcionDeCompra.recepcion_compra_id);
            if (recepcionDeCompraDb is null)
            {
                recepcionDeCompra.codigo_recepcion_compra = this.GetConsecutivo(await _recepcionRepository.GetConstante());
                await _recepcionRepository.CreateAsync(recepcionDeCompra);
            }
            else
            {
                recepcionDeCompra.codigo_recepcion_compra = recepcionDeCompraDb.codigo_recepcion_compra;
                recepcionDeCompra.constante = recepcionDeCompraDb.constante;
                await _recepcionRepository.UpdateAsync(recepcionDeCompra);
            }
            return recepcionDeCompra.codigo_recepcion_compra;
        }

        async Task<RecepcionDeCompraRead> IOrdenDeCompraBusiness.GetRecepcionDeCompraAsync(Guid id)
        {
            TblRecepcionDeCompraEntity? recepcionDeCompra = await _recepcionRepository.GetRecepcionDeCompraAsync(id);
            if (recepcionDeCompra is null)
                throw new PopsyException(ErrorType.RecepcionDeCompraNoEncontrada);
            else
                return _mapper.Map<RecepcionDeCompraRead>(recepcionDeCompra);
        }

        async Task<IEnumerable<RecepcionDeCompraRead>> IOrdenDeCompraBusiness.GetRecepcionesDeComprasAsync()
            => _mapper.Map<IEnumerable<RecepcionDeCompraRead>>(await _recepcionRepository.GetRecepcionesDeComprasAsync());

        async Task<IEnumerable<RecepcionDeCompraRead>> IOrdenDeCompraBusiness.GetRecepcionesDeComprasPorDetalleAsync(Guid detalle_orden_compra_id)
            => _mapper.Map<IEnumerable<RecepcionDeCompraRead>>(await _recepcionRepository.GetRecepcionesDeComprasPorDetalleAsync(detalle_orden_compra_id));

        async Task<IEnumerable<RecepcionDeCompraRead>> IOrdenDeCompraBusiness.GetRecepcionesDeComprasPorCodigoAsync(string codigo)
            => _mapper.Map<IEnumerable<RecepcionDeCompraRead>>(await _recepcionRepository.GetRecepcionesDeComprasPorCodigoAsync(codigo));
        #endregion

        #region Integraciones
        async Task<IEnumerable<ResponseOrdenesPopsySAP>> IOrdenDeCompraBusiness.SyncSAPAsync()
        {
            ISet<ResponseOrdenesPopsySAP> responsePopsy = new HashSet<ResponseOrdenesPopsySAP>();
            IEnumerable<PuntoDeVentaBasicRead> puntosDeVenta = await _ordenRepository.GetAllPuntosDeVentaAsync();
            foreach (PuntoDeVentaBasicRead puntoDeVenta in puntosDeVenta)
            {
                ResponseSAP<ResultOrdenDeCompra>? response = await _sapIntegration.SyncOrdenesDeCompra(puntoDeVenta.codigo);
                if (response is not null && response.d.results.Any())
                {
                    ISet<ResponsePopsySAP> ordenesResponse = new HashSet<ResponsePopsySAP>();
                    foreach (ResultOrdenDeCompra ordenDeCompra in response.d.results)
                    {
                        try
                        {
                            int posicion_producto = 0;
                            int.TryParse(ordenDeCompra.PositionDoc, out posicion_producto);
                            DateTime fecha_orden_compra = this.ConvertirFecha(ordenDeCompra.Date_Solped);
                            AccionesBD accion = await this.CrearOrdenesAsync(new OrdenDeCompraSave()
                            {
                                orden_compra = ordenDeCompra.DocOC,
                                posicion_producto = posicion_producto,
                                punto_venta_id = puntoDeVenta.punto_venta_id,
                                fecha_orden_compra = fecha_orden_compra,
                            }, ordenDeCompra.Proveedor);
                            ordenesResponse.Add(new ResponsePopsySAP()
                            {
                                Codigo = ordenDeCompra.DocOC,
                                Accion = accion,
                            });
                        }
                        catch (Exception ex)
                        {
                            ordenesResponse.Add(new ResponsePopsySAP()
                            {
                                Codigo = ordenDeCompra.DocOC,
                                Accion = AccionesBD.NoCreado,
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
        private async Task<AccionesBD> CrearOrdenesAsync(OrdenDeCompraSave ordenDeCompraSave, string proveedor)
        {
            AccionesBD response = AccionesBD.NoCreado;
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
                response = AccionesBD.Creado;
            }
            else
            {
                ordenDeCompra.orden_compra_id = ordenDeCompraDb.orden_compra_id;
                ordenId = ordenDeCompra.orden_compra_id;
                if (this.TieneCambios(ordenDeCompraDb, ordenDeCompra))
                {
                    await _ordenRepository.UpdateAsync(ordenDeCompra);
                    response = AccionesBD.Actualizado;
                }
                else
                    response = AccionesBD.NoActualizado;
            }
            return response;
        }

        private bool TieneCambios(TblOrdenDeCompraEntity ordenDeCompra, TblOrdenDeCompraEntity ordenDeCompraDb)
            => ordenDeCompra.orden_compra != ordenDeCompraDb.orden_compra ||
            ordenDeCompra.posicion_producto != ordenDeCompraDb.posicion_producto ||
            ordenDeCompra.punto_venta_id != ordenDeCompraDb.punto_venta_id ||
            ordenDeCompra.fecha_orden_compra != ordenDeCompraDb.fecha_orden_compra ||
            ordenDeCompra.proveedor_recepcion_id != ordenDeCompraDb.proveedor_recepcion_id;

        private string GetConsecutivo(int constante)
        {
            DateTime fechaActual = DateTime.Now;

            string año = fechaActual.Year.ToString().Substring(2);
            string mes = fechaActual.Month.ToString("D2");
            string dia = fechaActual.Day.ToString("D2");

            string numeroFormateado = (constante + 1).ToString("D6");

            return $"{PopsyConstants.AbrevOrdenDeCompra}-{año}{mes}{dia}{numeroFormateado}"; ;
        }

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
                TblDetalleOrdenDeCompraEntity detalleOrdenDeCompra = _mapper.Map<TblDetalleOrdenDeCompraEntity>(detalle);
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
