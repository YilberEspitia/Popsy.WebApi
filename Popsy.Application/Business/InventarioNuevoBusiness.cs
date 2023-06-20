using AutoMapper;

using Popsy.Common;
using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Business
{
    /// <summary>
    /// Implementa la lógica de negocio relacionada con el nuevo modulo de inventarios.
    /// </summary>
    public class InventarioNuevoBusiness : ApplicationBase, IInventarioNuevoBusiness
    {
        private readonly IInventarioNuevoRepository _repository;
        private readonly ISapSyncIntegration _sapIntegration;
        private readonly IEmailService _email;
        private readonly IEmailInfoRepository _emailInfo;
        private readonly IUsuariosRepository _usuarioRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mapper">mapper.</param>
        /// <param name="sapIntegration"><see cref="ISapSyncIntegration"/> instancia.</param>
        /// <param name="repository"><see cref="IInventarioNuevoRepository"/> instancia.</param>
        /// <param name="email"><see cref="IEmailService"/> instancia.</param>
        /// <param name="emailInfo"><see cref="IEmailInfoRepository"/> instancia.</param>
        public InventarioNuevoBusiness(IMapper mapper,
            ISapSyncIntegration sapIntegration,
            IInventarioNuevoRepository repository,
            IEmailService email,
            IEmailInfoRepository emailInfo,
            IUsuariosRepository usuarioRepository) : base(mapper)
        {
            _sapIntegration = sapIntegration;
            _repository = repository;
            _email = email;
            _emailInfo = emailInfo;
            _usuarioRepository = usuarioRepository;
        }

        #region Integraciones
        async Task<IEnumerable<ResponsePuntoDeVentaPopsySAP>> IInventarioNuevoBusiness.SyncSAPAsync()
        {
            ISet<ResponsePuntoDeVentaPopsySAP> responsePopsy = new HashSet<ResponsePuntoDeVentaPopsySAP>();
            IEnumerable<PuntoDeVentaBasicRead> puntosDeVenta = await _repository.GetAllPuntosDeVentaAsync();
            foreach (PuntoDeVentaBasicRead puntoDeVenta in puntosDeVenta)
            {
                ResponseSAP<ResultStockTeoricoDeInventario>? response = await _sapIntegration.GetStockTeoricoDeInventario(puntoDeVenta.codigo);
                if (response is not null && response.d.results.Any())
                {
                    ISet<ResponsePopsySAP> responseSAP = new HashSet<ResponsePopsySAP>();
                    foreach (ResultStockTeoricoDeInventario stockResult in response.d.results.GroupBy(p => new { p.almacen, p.Material }).Select(g => g.First()))
                    {
                        try
                        {
                            double stock_teorico = 0;
                            double.TryParse(stockResult.LibreUtiliza, out stock_teorico);
                            ResponsePopsySAP responseSapOrden = await this.CrearStockAsync(new StockTeoricoInventarioObject()
                            {
                                stock_teorico = stock_teorico,
                                punto_venta_id = puntoDeVenta.punto_venta_id
                            }, stockResult.Material, stockResult.almacen);
                            responseSAP.Add(responseSapOrden);
                        }
                        catch (Exception ex)
                        {
                            responseSAP.Add(new ResponsePopsySAP()
                            {
                                Codigo = $"{stockResult.Material}-{stockResult.almacen}",
                                Accion = AccionesBD.Error,
                                Error = ex.Message
                            });
                        }
                    }
                    responsePopsy.Add(new ResponsePuntoDeVentaPopsySAP()
                    {
                        Punto_venta_id = puntoDeVenta.punto_venta_id,
                        Codigo = puntoDeVenta.codigo,
                        Stocks = responseSAP
                    });
                }
            }
            return responsePopsy;
        }
        async Task<IEnumerable<ResponsePuntoDeVentaPopsySAP>> IInventarioNuevoBusiness.SyncStockFechaAsync()
        {
            ISet<ResponsePuntoDeVentaPopsySAP> responsePopsy = new HashSet<ResponsePuntoDeVentaPopsySAP>();
            IEnumerable<PuntoDeVentaBasicRead> puntosDeVenta = await _repository.GetAllPuntosDeVentaAsync();
            foreach (PuntoDeVentaBasicRead puntoDeVenta in puntosDeVenta)
            {
                ResponseSAP<ResultStockDia>? response = await _sapIntegration.GetStockDia(DateTime.Now.ToString("yyyyMMdd"), puntoDeVenta.codigo);
                if (response is not null && response.d.results.Any())
                {
                    ISet<ResponsePopsySAP> responseSAP = new HashSet<ResponsePopsySAP>();
                    foreach (ResultStockDia stockResult in response.d.results.GroupBy(p => new { p.codepdv, p.idsku }).Select(g => g.First()))
                    {
                        try
                        {
                            double stock = 0;
                            double.TryParse(stockResult.stockcierre, out stock);
                            DateTime fecha_stock = DateTime.Now;
                            DateTime.TryParse(stockResult.fechadestock, out fecha_stock);
                            ResponsePopsySAP responseSapOrden = await this.CrearStockFechaAsync(new StockFechaObject()
                            {
                                cantidad = stock,
                                punto_venta_id = puntoDeVenta.punto_venta_id,
                                fecha = fecha_stock
                            }, stockResult.idsku, stockResult.codepdv);
                            responseSAP.Add(responseSapOrden);
                        }
                        catch (Exception ex)
                        {
                            responseSAP.Add(new ResponsePopsySAP()
                            {
                                Codigo = $"{stockResult.idsku}-{stockResult.codepdv}",
                                Accion = AccionesBD.Error,
                                Error = ex.Message
                            });
                        }
                    }
                    responsePopsy.Add(new ResponsePuntoDeVentaPopsySAP()
                    {
                        Punto_venta_id = puntoDeVenta.punto_venta_id,
                        Codigo = puntoDeVenta.codigo,
                        Stocks = responseSAP
                    });
                }
            }
            return responsePopsy;
        }
        async Task<IEnumerable<ResponsePopsySAP>> IInventarioNuevoBusiness.SyncUnidadesDeInventariosSAPAsync()
        {
            ISet<ResponsePopsySAP> responsePopsy = new HashSet<ResponsePopsySAP>();
            ResponseSAP<ResultUnidadInventarioDos>? response = await _sapIntegration.GetUnidadInventarioDos();
            if (response is not null)
            {
                foreach (ResultUnidadInventarioDos factorConversion in response.d.results)
                {
                    try
                    {
                        AccionesBD accion = await this.CrearFactorConversionAsync(new UnidadInventarioDosObject()
                        {
                            unidad_consumo = factorConversion.UndConsumo,
                            unidad_despacho = factorConversion.undDespacho,
                            unidad_conteo = factorConversion.UndConteo
                        }, factorConversion.Material);
                        responsePopsy.Add(new ResponsePopsySAP()
                        {
                            Codigo = $"{factorConversion.Material}-{factorConversion.UndConsumo}-{factorConversion.UndConteo}-{factorConversion.undDespacho}",
                            Accion = accion,
                        });
                    }
                    catch (Exception ex)
                    {
                        responsePopsy.Add(new ResponsePopsySAP()
                        {
                            Codigo = $"{factorConversion.Material}-{factorConversion.UndConsumo}-{factorConversion.UndConteo}-{factorConversion.undDespacho}",
                            Accion = AccionesBD.Error,
                            Error = ex.Message
                        });
                    }
                }
            }
            return responsePopsy;
        }
        #endregion
        async Task<UnidadInventarioDosRead> IInventarioNuevoBusiness.GetAllUnidadesInventariosPorProductoAsync(Guid producto_id)
        {
            UnidadInventarioDosRead? response = await _repository.GetAllUnidadesInventariosPorProductoAsync(producto_id);
            if (response is null)
                throw new PopsyException(ErrorType.UnidadesDeConversionNoEncontradas, ErrorSource.NoEncontrado);
            return response;
        }

        async Task<IEnumerable<UnidadInventarioDosRead>> IInventarioNuevoBusiness.GetAllUnidadesInventariosAsync()
            => await _repository.GetAllUnidadesInventariosAsync();

        #region Metodos de inventarios
        async Task<InventarioResponse> IInventarioNuevoBusiness.CreateInventarioBaseAsync(InventarioBaseSave inventario_base)
        {
            IEnumerable<Guid> puntos_venta_id = await _repository.GetUsuariosPuntosVentasAsync(inventario_base.usuario_id, true);
            if (!puntos_venta_id.Any())
                throw new PopsyException(ErrorType.PuntoDeVentaNoEncontrado, ErrorSource.NoEncontrado);
            TicketsSeguimientoPDVObject ticketsRepresados = await _repository.GetTicketsPDVAsync(puntos_venta_id.FirstOrDefault());
            Boolean tieneTickets = ticketsRepresados.TicketsICG > 0 || ticketsRepresados.TicketsSIPOP > 0 || ticketsRepresados.TicketsTracker > 0;
            Boolean validarCantidades = !tieneTickets;
            InventarioCreadoResponse response = await _repository.CreateInventarioBaseAsync(inventario_base, puntos_venta_id.FirstOrDefault(), validarCantidades);
            if (response.Reconteo)
            {
                foreach (DetalleInventarioCreadoResponse detalle in response.Detalles.Where(x => x.Reconteo))
                {
                    await _repository.SaveConteoAsync(this._mapper.Map<TblInventarioConteo2Entity>(new InventarioConteoObject
                    {
                        cantidad = detalle.Cantidad,
                        inicial = true,
                        final = false,
                        inventario_detalle_id = detalle.Inventario_detalle_id
                    }));
                    await _repository.UpdateEstadoReconteoAsync(detalle.Inventario_detalle_id, true);
                }
            }
            InventarioEmailObject inventarioEmail = new InventarioEmailObject
            {
                Fecha = response.Fecha_registro.ToString("yyyy-MM-dd"),
                Usuario = await _emailInfo.GetUsuarioMail(response.Usuario_id),
                PuntoDeVenta = await _emailInfo.GetNombrePuntoDeVenta(response.Punto_venta_id),
                TipoDePedido = await _emailInfo.GetTipoDeInventario(response.Tipo_inventario_id),
                Codigo = response.Codigo_inventario,
                Productos = await this.GetProductos(response.Detalles.Select(x => x.Producto_id)),
                Bodegas = await this.GetBodegas(response.Detalles.Select(x => x.Bodega_id)),
                Cantidades = this.GetCantidades(response.Detalles.Select(x => x.Cantidad)),
                Unidades = this.GetUnidades(response.Detalles.Select(x => x.Unidad))
            };
            this.EnviarCorreoInventario(inventarioEmail);
            return new InventarioResponse
            {
                Respuesta = String.Format(PopsyConstants.InventarioCreado, response.Codigo_inventario),
                Reconteo = response.Reconteo,
                Inventario_id = response.Inventario_id,
                Detalles = response.Detalles,
                TieneTickets = tieneTickets
            };
        }

        async Task<InventarioBaseUpdate> IInventarioNuevoBusiness.UpdateInventarioBaseAsync(InventarioBaseUpdate inventario_base)
        {
            IEnumerable<Guid> puntos_venta_id = await _repository.GetUsuariosPuntosVentasAsync(inventario_base.usuario_id, true);
            if (!puntos_venta_id.Any())
                throw new PopsyException(ErrorType.PuntoDeVentaNoEncontrado, ErrorSource.NoEncontrado);
            return await _repository.UpdateInventarioBaseAsync(inventario_base, puntos_venta_id.FirstOrDefault());
        }


        async Task<IEnumerable<InventarioBaseRead>> IInventarioNuevoBusiness.GetInventarioBaseAsync(Guid punto_venta_id)
            => await _repository.GetInventarioBaseAsync(punto_venta_id);

        async Task<EncabezadoInventarioRead> IInventarioNuevoBusiness.GetEncabezadoInventarioAsync(Guid usuario_id)
        {
            if (await _usuarioRepository.GetNombreDeUsuarioAsync(usuario_id) is String nombre_usuario)
            {
                Boolean superUsuario = await _usuarioRepository.EsSuperUsuario(usuario_id);
                return new EncabezadoInventarioRead
                {
                    Usuario_id = usuario_id,
                    Usuario_nombre = nombre_usuario,
                    Puntos_venta = superUsuario ? await _usuarioRepository.GetAllPuntosDeVentaInfoAsync() :
                    await _usuarioRepository.GetPuntosDeVentaInfoAsync(usuario_id),
                    Tipo_inventario = base._mapper.Map<IEnumerable<TipoInventarioRead>>(await _usuarioRepository.GetTipoInventariosAsync())
                };
            }
            else
                throw new PopsyException(ErrorType.UsuarioNoEncontrado, ErrorSource.NoEncontrado);
        }

        async Task<Boolean> IInventarioNuevoBusiness.RequiereReconteoAsync(Guid inventario_id)
        {
            if (!await _repository.ExisteAsync(inventario_id))
                throw new PopsyException(ErrorType.InventarioNoEncontrado, ErrorSource.NoEncontrado);
            return await _repository.RequiereReconteoAsync(inventario_id);
        }

        async Task<InventarioReconteoObject> IInventarioNuevoBusiness.GetInventarioReconteoAsync(Guid inventario_id)
        {
            if (!await _repository.ExisteAsync(inventario_id))
                throw new PopsyException(ErrorType.InventarioNoEncontrado, ErrorSource.NoEncontrado);
            else if (!await _repository.RequiereReconteoAsync(inventario_id))
                throw new PopsyException(ErrorType.ReconteoNoEncontrado, ErrorSource.NoEncontrado);
            else if (await _repository.GetInventarioReconteoAsync(inventario_id) is InventarioReconteoObject inventarioReconteo)
                return inventarioReconteo;
            else
                throw new PopsyException(ErrorType.ReconteoNoEncontrado, ErrorSource.NoEncontrado);
        }

        async Task<InventarioReconteoRead> IInventarioNuevoBusiness.ReconteoAsync(InventarioReconteoSave inventarioReconteo)
        {
            if (!await _repository.ExisteAsync(inventarioReconteo.Inventario_id))
                throw new PopsyException(ErrorType.InventarioNoEncontrado, ErrorSource.NoEncontrado);
            else if (!await _repository.RequiereReconteoAsync(inventarioReconteo.Inventario_id))
                throw new PopsyException(ErrorType.ReconteoNoEncontrado, ErrorSource.NoEncontrado);
            IEnumerable<InventarioConteoRead> reconteos = await _repository.ReconteoAsync(inventarioReconteo.Detalles);
            return new InventarioReconteoRead
            {
                Inventario_id = inventarioReconteo.Inventario_id,
                Detalles = reconteos,
                RequiereReconteo = reconteos.Where(x => x.RequiereReconteo).Any()
            };
        }

        async Task<InventarioReconteoExportable> IInventarioNuevoBusiness.GetReconteosAsync(Guid inventario_id)
        {
            if (!await _repository.ExisteAsync(inventario_id))
                throw new PopsyException(ErrorType.InventarioNoEncontrado, ErrorSource.NoEncontrado);
            else if (await _repository.GetReconteosAsync(inventario_id) is InventarioReconteoExportable inventarioReconteo)
                return inventarioReconteo;
            else
                throw new PopsyException(ErrorType.ReconteoNoEncontrado, ErrorSource.NoEncontrado);
        }
        #endregion

        #region Private
        private async Task<ResponsePopsySAP> CrearStockAsync(StockTeoricoInventarioObject stockSave, string producto, string almacen)
        {
            ResponsePopsySAP response = new ResponsePopsySAP()
            {
                Codigo = $"{producto}-{almacen}",
                Accion = AccionesBD.NoCreado,
            };
            if (string.IsNullOrEmpty(producto) || !await _repository.ExisteProductoAsync(producto))
                throw new PopsyException(ErrorType.ProductoNoEncontrado);
            Guid stockId;
            stockSave.producto_id = await _repository.GetProductoPorCodigoAsync(producto);
            TblStockTeoricoInventariosDos stockTeorico = _mapper.Map<TblStockTeoricoInventariosDos>(stockSave);
            TblStockTeoricoInventariosDos? stockTeoricoDb = default;
            if (stockTeorico.producto_id != default && stockTeorico.punto_venta_id != default)
                stockTeoricoDb = await _repository.GetStockTeoricoInventarioAsync(stockTeorico.punto_venta_id, stockTeorico.producto_id);
            if (stockTeoricoDb == default && stockTeorico.stock_teorico_inventarios_dos_id != default)
                stockTeoricoDb = await _repository.GetStockTeoricoInventarioAsync(stockTeorico.stock_teorico_inventarios_dos_id);
            if (stockTeoricoDb is null)
            {
                stockId = await _repository.CreateAsync(stockTeorico);
                response.Accion = AccionesBD.Creado;
            }
            else
            {
                stockTeorico.stock_teorico_inventarios_dos_id = stockTeoricoDb.stock_teorico_inventarios_dos_id;
                stockId = stockTeorico.stock_teorico_inventarios_dos_id;
                if (this.TieneCambios(stockTeoricoDb, stockTeorico))
                {
                    await _repository.UpdateAsync(stockTeorico);
                    response.Accion = AccionesBD.Actualizado;
                }
                else
                    response.Accion = AccionesBD.NoActualizado;
            }
            return response;
        }

        private bool TieneCambios(TblStockTeoricoInventariosDos stockTeorico, TblStockTeoricoInventariosDos stockTeoricoDb)
            => stockTeorico.stock_teorico != stockTeoricoDb.stock_teorico ||
            stockTeorico.punto_venta_id != stockTeoricoDb.punto_venta_id ||
            stockTeorico.producto_id != stockTeoricoDb.producto_id;
        private async Task<ResponsePopsySAP> CrearStockFechaAsync(StockFechaObject stockSave, string producto, string almacen)
        {
            ResponsePopsySAP response = new ResponsePopsySAP()
            {
                Codigo = $"{producto}-{almacen}",
                Accion = AccionesBD.NoCreado,
            };
            if (string.IsNullOrEmpty(producto) || !await _repository.ExisteProductoAsync(producto))
                throw new PopsyException(ErrorType.ProductoNoEncontrado);
            Guid stockId;
            stockSave.producto_id = await _repository.GetProductoPorCodigoAsync(producto);
            TblStockAFechaEntity stockFecha = _mapper.Map<TblStockAFechaEntity>(stockSave);
            TblStockAFechaEntity? stockFechaDb = default;
            if (stockFecha.producto_id != default && stockFecha.punto_venta_id != default)
                stockFechaDb = await _repository.GetStockFechaInventarioAsync(stockFecha.punto_venta_id, stockFecha.producto_id);
            if (stockFechaDb == default && stockFecha.stock_fecha_id != default)
                stockFechaDb = await _repository.GetStockFechaInventarioAsync(stockFecha.stock_fecha_id);
            if (stockFechaDb is null)
            {
                stockId = await _repository.CreateAsync(stockFecha);
                response.Accion = AccionesBD.Creado;
            }
            else
            {
                stockFecha.stock_fecha_id = stockFechaDb.stock_fecha_id;
                stockId = stockFecha.stock_fecha_id;
                if (this.TieneCambios(stockFechaDb, stockFecha))
                {
                    await _repository.UpdateAsync(stockFecha);
                    response.Accion = AccionesBD.Actualizado;
                }
                else
                    response.Accion = AccionesBD.NoActualizado;
            }
            return response;
        }

        private bool TieneCambios(TblStockAFechaEntity stockFecha, TblStockAFechaEntity stockFechaDb)
            => stockFecha.fecha != stockFechaDb.fecha ||
            stockFecha.cantidad != stockFechaDb.cantidad ||
            stockFecha.producto_id != stockFechaDb.producto_id ||
            stockFecha.punto_venta_id != stockFechaDb.punto_venta_id;

        private async Task<AccionesBD> CrearFactorConversionAsync(UnidadInventarioDosObject factInvetarioDosSave, string codigo_producto)
        {
            AccionesBD response = AccionesBD.NoCreado;
            if (string.IsNullOrEmpty(codigo_producto) || !await _repository.ExisteProductoAsync(codigo_producto))
                throw new PopsyException(ErrorType.ProductoNoEncontrado, ErrorSource.NoEncontrado);
            factInvetarioDosSave.producto_id = await _repository.GetProductoPorCodigoAsync(codigo_producto);
            TblUnidadInventarioDos unidadInventario = _mapper.Map<TblUnidadInventarioDos>(factInvetarioDosSave);
            TblUnidadInventarioDos? unidadInventarioDb = default;
            if (unidadInventario.producto_id != default)
                unidadInventarioDb = await _repository.GetUnidadInventarioPorProductoAsync(unidadInventario.producto_id);
            if (unidadInventarioDb == default && unidadInventario.unidad_inventario_dos_id != default)
                unidadInventarioDb = await _repository.GetUnidadInventarioAsync(unidadInventario.unidad_inventario_dos_id);
            if (unidadInventarioDb is null)
            {
                await _repository.CreateUnidadInventarioAsync(unidadInventario);
                response = AccionesBD.Creado;
            }
            else
            {
                unidadInventario.unidad_inventario_dos_id = unidadInventarioDb.unidad_inventario_dos_id;
                if (this.TieneCambios(unidadInventarioDb, unidadInventario))
                {
                    await _repository.UpdateUnidadInventarioAsync(unidadInventario);
                    response = AccionesBD.Actualizado;
                }
                else
                    response = AccionesBD.NoActualizado;
            }
            return response;
        }

        private bool TieneCambios(TblUnidadInventarioDos unidadInventarioDb, TblUnidadInventarioDos unidadInventario)
            => unidadInventario.unidad_consumo != unidadInventarioDb.unidad_consumo ||
            unidadInventario.unidad_despacho != unidadInventarioDb.unidad_despacho ||
            unidadInventario.unidad_conteo != unidadInventarioDb.unidad_conteo ||
            unidadInventario.producto_id != unidadInventarioDb.producto_id;

        #region Email
        private void EnviarCorreoInventario(InventarioEmailObject inventarioEmail)
        {
            string body = this.ReemplazarParametros(PopsyConstants.InventarioBaseHTMLBody,
                inventarioEmail.Fecha,
                inventarioEmail.Usuario,
                inventarioEmail.PuntoDeVenta,
                inventarioEmail.TipoDePedido,
                inventarioEmail.Codigo,
                inventarioEmail.Productos,
                inventarioEmail.Bodegas,
                inventarioEmail.Cantidades,
                inventarioEmail.Unidades);
            _email.SendEmail(inventarioEmail.Usuario, body, EmailType.Inventario);
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

        private async Task<string> GetBodegas(IEnumerable<Guid> bodegas_ids)
        {
            string response = String.Empty;
            foreach (Guid bodega_id in bodegas_ids)
            {
                response += await _emailInfo.GetNombreBodega(bodega_id) + "<br/>";
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

        private string GetCantidades(IEnumerable<double> cantidades)
        {
            string response = String.Empty;
            foreach (double cantidad in cantidades)
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
