using Microsoft.EntityFrameworkCore;

using Popsy.Common;
using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Repositories
{
    /// <summary>
    /// Implementa los metodos relacionados con la entidad <see cref="TblStockTeoricoInventariosDos"/>.
    /// </summary>
    public class InventarioNuevoRepository : IInventarioNuevoRepository
    {
        /// <summary>
        /// Contexto.
        /// </summary>
        private readonly PopsyDbContext _context;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Contexto.</param>
        public InventarioNuevoRepository(PopsyDbContext context)
        {
            _context = context;
        }

        #region Stock teórico.
        async Task<Guid> IInventarioNuevoRepository.CreateAsync(TblStockTeoricoInventariosDos stockTeoricoInventario)
        {
            stockTeoricoInventario.fecha_modificacion = DateTime.Now;
            await _context.AddAsync(stockTeoricoInventario);
            await _context.SaveChangesAsync();
            return stockTeoricoInventario.stock_teorico_inventarios_dos_id;
        }

        async Task<bool> IInventarioNuevoRepository.UpdateAsync(TblStockTeoricoInventariosDos stockTeoricoInventario)
        {
            stockTeoricoInventario.fecha_modificacion = DateTime.Now;
            TblStockTeoricoInventariosDos stockTeoricoInventarioDb = await this._context.StockTeoricoInventariosDos.SingleAsync(r => r.stock_teorico_inventarios_dos_id.Equals(stockTeoricoInventario.stock_teorico_inventarios_dos_id));
            this._context.Entry(stockTeoricoInventarioDb).CurrentValues.SetValues(stockTeoricoInventario);
            await this._context.SaveChangesAsync();
            return true;
        }

        async Task<TblStockTeoricoInventariosDos?> IInventarioNuevoRepository.GetStockTeoricoInventarioAsync(Guid id)
            => await _context.StockTeoricoInventariosDos.Include(x => x.producto).Include(x => x.punto_de_venta).Where(x => x.stock_teorico_inventarios_dos_id.Equals(id)).FirstOrDefaultAsync();

        async Task<TblStockTeoricoInventariosDos?> IInventarioNuevoRepository.GetStockTeoricoInventarioAsync(Guid punto_venta_id, Guid producto_id)
            => await _context.StockTeoricoInventariosDos.Include(x => x.producto).Include(x => x.punto_de_venta).Where(x => x.punto_venta_id.Equals(punto_venta_id) && x.producto_id.Equals(producto_id)).FirstOrDefaultAsync();
        #endregion

        #region Stock fecha.
        async Task<Guid> IInventarioNuevoRepository.CreateAsync(TblStockAFechaEntity stockFecha)
        {
            stockFecha.fecha_modificacion = DateTime.Now;
            await _context.AddAsync(stockFecha);
            await _context.SaveChangesAsync();
            return stockFecha.stock_fecha_id;
        }

        async Task<bool> IInventarioNuevoRepository.UpdateAsync(TblStockAFechaEntity stockFecha)
        {
            stockFecha.fecha_modificacion = DateTime.Now;
            TblStockAFechaEntity stockFechaDb = await this._context.StocksFecha.SingleAsync(r => r.stock_fecha_id.Equals(stockFecha.stock_fecha_id));
            this._context.Entry(stockFechaDb).CurrentValues.SetValues(stockFecha);
            await this._context.SaveChangesAsync();
            return true;
        }

        async Task<TblStockAFechaEntity?> IInventarioNuevoRepository.GetStockFechaInventarioAsync(Guid id)
            => await _context.StocksFecha.Include(x => x.producto).Include(x => x.punto_de_venta).Where(x => x.stock_fecha_id.Equals(id)).FirstOrDefaultAsync();

        async Task<TblStockAFechaEntity?> IInventarioNuevoRepository.GetStockFechaInventarioAsync(Guid punto_venta_id, Guid producto_id)
            => await _context.StocksFecha.Include(x => x.producto).Include(x => x.punto_de_venta).Where(x => x.punto_venta_id.Equals(punto_venta_id) && x.producto_id.Equals(producto_id) && x.fecha.Date.Equals(DateTime.Today)).FirstOrDefaultAsync();
        #endregion

        async Task<IEnumerable<TblStockTeoricoInventariosDos>> IInventarioNuevoRepository.GetStockTeoricoInventarioAsync()
            => await _context.StockTeoricoInventariosDos.Include(x => x.producto).Include(x => x.punto_de_venta).ToListAsync();

        async Task<IEnumerable<TblStockTeoricoInventariosDos>> IInventarioNuevoRepository.GetStockTeoricoInventarioPorProductoAsync(Guid producto_id)
            => await _context.StockTeoricoInventariosDos.Include(x => x.producto).Include(x => x.punto_de_venta).Where(x => x.producto_id.Equals(producto_id)).ToListAsync();

        async Task<IEnumerable<TblStockTeoricoInventariosDos>> IInventarioNuevoRepository.GetStockTeoricoInventarioPorPuntoAsync(Guid punto_venta_id)
            => await _context.StockTeoricoInventariosDos.Include(x => x.producto).Include(x => x.punto_de_venta).Where(x => x.punto_venta_id.Equals(punto_venta_id)).ToListAsync();

        async Task<bool> IInventarioNuevoRepository.ExisteStockAsync(Guid id)
            => await _context.StockTeoricoInventariosDos.Where(x => x.stock_teorico_inventarios_dos_id.Equals(id)).AnyAsync();

        async Task<bool> IInventarioNuevoRepository.ExisteProductoAsync(Guid producto_id)
            => await _context.Productos.Where(x => x.producto_id.Equals(producto_id)).AnyAsync();

        async Task<bool> IInventarioNuevoRepository.ExisteProductoAsync(string codigo)
            => await _context.Productos.Where(x => x.codigo.Equals(codigo)).AnyAsync();

        async Task<Guid> IInventarioNuevoRepository.GetProductoPorCodigoAsync(string codigo)
            => await _context.Productos.Where(x => x.codigo.Equals(codigo)).Select(x => x.producto_id).FirstOrDefaultAsync();

        async Task<Guid> IInventarioNuevoRepository.GetPuntoDeVentaPorCodigoAsync(string codigo)
            => await _context.PuntosDeVenta.Where(x => x.codigo.Equals(codigo)).Select(x => x.punto_venta_id).FirstOrDefaultAsync();


        async Task<IEnumerable<PuntoDeVentaBasicRead>> IInventarioNuevoRepository.GetAllPuntosDeVentaAsync()
            => await _context.PuntosDeVenta.Select(x => new PuntoDeVentaBasicRead()
            {
                punto_venta_id = x.punto_venta_id,
                codigo = x.codigo
            }).ToListAsync();

        #region Unidad de inventario
        async Task<Guid> IInventarioNuevoRepository.CreateUnidadInventarioAsync(TblUnidadInventarioDos unidadInventario)
        {
            unidadInventario.fecha_modificacion = DateTime.Now;
            await _context.AddAsync(unidadInventario);
            await _context.SaveChangesAsync();
            return unidadInventario.unidad_inventario_dos_id;
        }

        async Task<bool> IInventarioNuevoRepository.UpdateUnidadInventarioAsync(TblUnidadInventarioDos unidadInventario)
        {
            unidadInventario.fecha_modificacion = DateTime.Now;
            TblUnidadInventarioDos unidadInventarioDb = await this._context.UnidadesDeInventariosDos.SingleAsync(r => r.unidad_inventario_dos_id.Equals(unidadInventario.unidad_inventario_dos_id));
            this._context.Entry(unidadInventarioDb).CurrentValues.SetValues(unidadInventario);
            await this._context.SaveChangesAsync();
            return true;
        }

        async Task<TblUnidadInventarioDos?> IInventarioNuevoRepository.GetUnidadInventarioAsync(Guid id)
            => await _context.UnidadesDeInventariosDos.Include(x => x.producto)
            .Where(x => x.unidad_inventario_dos_id.Equals(id)).FirstOrDefaultAsync();

        async Task<TblUnidadInventarioDos?> IInventarioNuevoRepository.GetUnidadInventarioPorProductoAsync(Guid producto_id)
            => await _context.UnidadesDeInventariosDos.Include(x => x.producto)
            .Where(x => x.producto_id.Equals(producto_id)).FirstOrDefaultAsync();

        async Task<UnidadInventarioDosRead?> IInventarioNuevoRepository.GetAllUnidadesInventariosPorProductoAsync(Guid producto_id)
            => await this.GetUnidadInventarioPorProductoAsync(producto_id);

        async Task<IEnumerable<UnidadInventarioDosRead>> IInventarioNuevoRepository.GetAllUnidadesInventariosAsync()
            => await _context.UnidadesDeInventariosDos.Include(x => x.producto).Include(x => x.producto).ThenInclude(x => x.factores_de_conversion).ThenInclude(x => x.factor_conversion)
            .Select(x => new UnidadInventarioDosRead
            {
                unidad_inventario_dos_id = x.unidad_inventario_dos_id,
                producto_id = x.producto_id,
                unidad_consumo = x.unidad_consumo,
                unidad_consumo_contador = x.producto.factores_de_conversion.Where(f => f.factor_conversion.unidad_base.ToUpper().Equals(x.unidad_consumo.ToUpper())).Select(f => f.factor_conversion.contador).FirstOrDefault(),
                unidad_despacho = x.unidad_despacho,
                unidad_despacho_contador = x.producto.factores_de_conversion.Where(f => f.factor_conversion.unidad_base.ToUpper().Equals(x.unidad_despacho.ToUpper())).Select(f => f.factor_conversion.contador).FirstOrDefault(),
                unidad_conteo = x.unidad_conteo,
                unidad_conteo_contador = x.producto.factores_de_conversion.Where(f => f.factor_conversion.unidad_base.ToUpper().Equals(x.unidad_conteo.ToUpper())).Select(f => f.factor_conversion.contador).FirstOrDefault(),
            }).ToListAsync();
        #endregion

        #region Metodos de inventarios
        async Task<InventarioCreadoResponse> IInventarioNuevoRepository.CreateInventarioBaseAsync(InventarioBaseSave inventario_base, Guid punto_venta_id, Boolean validarCantidades)
        {
            Boolean reconteo = false;
            TblInventario2Entity inventarioBase = new TblInventario2Entity
            {
                punto_venta_id = punto_venta_id,
                usuario_id = inventario_base.usuario_id,
                tipo_inventario_id = inventario_base.tipo_inventario_id,
                codigo_inventario = "I-" + DateTime.Now.ToString("yyyyMMddHHss"),
            };
            await _context.AddAsync(inventarioBase);
            await _context.SaveChangesAsync();
            List<DetalleInventarioCreadoResponse> detalles_response = new List<DetalleInventarioCreadoResponse>();
            foreach (DetalleInventarioBaseSave detalle in inventario_base.inventario_detalle)
            {
                AccionesBD accion = AccionesBD.NoCreado;
                TblProductoPuntoVentaEntity? productoPuntoVentaList = await this.GetProductoPuntoVentaId(detalle.producto_id, punto_venta_id);
                if (productoPuntoVentaList is not null)
                {
                    TblInventarioDetalle2Entity detalleSave = new TblInventarioDetalle2Entity
                    {
                        inventario_id = inventarioBase.inventario_id,
                        producto_punto_venta_id = productoPuntoVentaList.producto_punto_venta_id,
                        bodega_id = detalle.bodega_id,
                        unidad = detalle.unidad,
                        cantidad = detalle.cantidad,
                        unidad_consumo = detalle.unidad_inventario.unidad_consumo,
                        unidad_consumo_total = detalle.unidad_inventario.unidad_consumo_total,
                        unidad_despacho = detalle.unidad_inventario.unidad_despacho,
                        unidad_despacho_total = detalle.unidad_inventario.unidad_despacho_total,
                        unidad_conteo = detalle.unidad_inventario.unidad_conteo,
                        unidad_conteo_total = detalle.unidad_inventario.unidad_conteo_total
                    };
                    await _context.AddAsync(detalleSave);
                    await _context.SaveChangesAsync();
                    accion = AccionesBD.Creado;
                    ReconteoBaseObject reconteoBase = validarCantidades ?
                        await this.ValidarCantidadStock(detalle.producto_id, punto_venta_id, detalle.cantidad)
                        : new ReconteoBaseObject
                        {
                            CantidadValidacion = StockValidaciones.SinValidar,
                            Reconteo = false
                        };
                    if (reconteoBase.Reconteo)
                        reconteo = true;
                    detalles_response.Add(new DetalleInventarioCreadoResponse
                    {
                        Inventario_detalle_id = detalleSave.inventario_detalle_id,
                        Producto_id = detalle.producto_id,
                        Bodega_id = detalle.bodega_id,
                        Cantidad = detalle.cantidad,
                        Unidad = detalle.unidad,
                        CantidadValidacion = reconteoBase.CantidadValidacion,
                        Reconteo = reconteoBase.Reconteo,
                        Accion = accion
                    });
                }
            }
            InventarioCreadoResponse respuesta = new InventarioCreadoResponse
            {
                Inventario_id = inventarioBase.inventario_id,
                Usuario_id = inventarioBase.usuario_id,
                Punto_venta_id = inventarioBase.punto_venta_id,
                Tipo_inventario_id = inventarioBase.tipo_inventario_id,
                Codigo_inventario = inventarioBase.codigo_inventario,
                Reconteo = reconteo,
                Detalles = detalles_response
            };
            return respuesta;
        }

        async Task<InventarioBaseUpdate> IInventarioNuevoRepository.UpdateInventarioBaseAsync(InventarioBaseUpdate inventario_base, Guid punto_venta_id)
        {
            foreach (DetalleInventarioBaseSave detalle in inventario_base.inventario_detalle)
            {
                TblProductoPuntoVentaEntity? productoPuntoVentaList = await this.GetProductoPuntoVentaId(detalle.producto_id, punto_venta_id);
                if (productoPuntoVentaList is not null)
                {
                    await _context.AddAsync(new TblInventarioDetalle2Entity
                    {
                        inventario_id = inventario_base.inventario_id,
                        producto_punto_venta_id = productoPuntoVentaList.producto_punto_venta_id,
                        bodega_id = detalle.bodega_id,
                        unidad = detalle.unidad,
                        cantidad = detalle.cantidad,
                        unidad_consumo = detalle.unidad_inventario.unidad_consumo,
                        unidad_consumo_total = detalle.unidad_inventario.unidad_consumo_total,
                        unidad_despacho = detalle.unidad_inventario.unidad_despacho,
                        unidad_despacho_total = detalle.unidad_inventario.unidad_despacho_total,
                        unidad_conteo = detalle.unidad_inventario.unidad_conteo,
                        unidad_conteo_total = detalle.unidad_inventario.unidad_conteo_total
                    });
                    await _context.SaveChangesAsync();
                }
            }
            return inventario_base;
        }
        async Task<IEnumerable<InventarioBaseRead>> IInventarioNuevoRepository.GetInventarioBaseAsync(Guid punto_venta_id)
        {
            List<InventarioBaseRead> infoList = new List<InventarioBaseRead>();
            List<VistaCategoriasProductosEntity> vistaCategorias = await _context.VistaCategoriasProductos.ToListAsync();

            foreach (VistaCategoriasProductosEntity categoria in vistaCategorias)
            {
                InventarioBaseRead info = new InventarioBaseRead();
                List<InventarioProductosRead> productoList = new List<InventarioProductosRead>();
                info.categoria_id = categoria.categoria_id;
                info.categoria_nombre = categoria.categoria_nombre;
                var productosPuntoVenta = _context.VistaProductosParaInventario.Where(l => l.categoria_id == categoria.categoria_id && l.punto_venta_id == punto_venta_id).Select(i => new { i.producto_id, i.nombre_producto, i.categoria_producto }).Distinct().ToList();
                foreach (var producto in productosPuntoVenta)
                {
                    if (await this.GetUnidadInventarioPorProductoAsync(producto.producto_id) is UnidadInventarioDosRead unidadInentario)
                    {
                        productoList.Add(new InventarioProductosRead
                        {
                            producto_id = producto.producto_id,
                            producto_nombre = producto.nombre_producto,
                            cantidad = 0,
                            categoria_producto = producto.categoria_producto,
                            unidad_inventario = unidadInentario
                        });
                    }
                }
                info.productos = productoList;
                infoList.Add(info);
            }
            return infoList;
        }

        async Task<bool> IInventarioNuevoRepository.ExisteAsync(Guid inventario_id)
            => await _context.Inventarios2.Where(x => x.inventario_id.Equals(inventario_id)).AnyAsync();

        async Task<bool> IInventarioNuevoRepository.UpdateEstadoAsync(Guid inventario_id, SAPEstado nuevo_estado)
        {
            bool response = false;
            if (await _context.Inventarios2.Where(x => x.inventario_id.Equals(inventario_id)).FirstOrDefaultAsync() is TblInventario2Entity inventario)
            {
                if (!inventario.estado.Equals(nuevo_estado))
                {
                    inventario.estado = nuevo_estado;
                    await _context.SaveChangesAsync();
                    response = true;
                }
            }
            return response;
        }

        async Task<InventarioGestionSAP?> IInventarioNuevoRepository.GetInventarioGestionAsync(Guid punto_venta_id, DateTime fecha_stock)
            => await _context.Inventarios2.Where(x => x.punto_venta_id.Equals(punto_venta_id) && x.fecha_creacion.Date.Equals(fecha_stock.Date)).Include(x => x.punto_de_venta)
                .Include(x => x.detalles)
                .Select(x => new InventarioGestionSAP
                {
                    Inventario_id = x.inventario_id,
                    Codigo_inventario = x.codigo_inventario,
                    Punto_venta_id = x.punto_venta_id,
                    Codigo_punto_venta = x.punto_de_venta.codigo,
                    Fecha_creacion = x.fecha_creacion,
                    Estado = x.estado,
                    Detalles = x.detalles.Select(d => new DetalleInventarioGestionSAP
                    {
                        Producto_id = _context.ProductosPuntoDeVenta.Find(d.producto_punto_venta_id)!.producto_id,
                        Codigo = _context.ProductosPuntoDeVenta.Find(d.producto_punto_venta_id)!.producto.codigo,
                        Unidad = d.unidad,
                        Cantidad = d.cantidad,
                        Unidad_consumo = d.unidad_consumo,
                        Unidad_consumo_total = d.unidad_consumo_total,
                        Unidad_despacho = d.unidad_despacho,
                        Unidad_despacho_total = d.unidad_despacho_total,
                        Unidad_conteo = d.unidad_conteo,
                        Unidad_conteo_total = d.unidad_conteo_total,
                    })
                }).FirstOrDefaultAsync();
        #endregion

        async Task<IEnumerable<Guid>> IInventarioNuevoRepository.GetUsuariosPuntosVentasAsync(Guid usuario_id, bool activos)
            => activos ? await _context.UsuariosPuntoDeVenta.Where(l => l.usuario_id.Equals(usuario_id) && !l.fecha_eliminacion.HasValue).Select(x => x.punto_venta_id).ToListAsync() :
            await _context.UsuariosPuntoDeVenta.Where(l => l.usuario_id == usuario_id).Select(x => x.punto_venta_id).ToListAsync();

        #region Conteo
        async Task<TicketsSeguimientoPDVObject> IInventarioNuevoRepository.GetTicketsPDVAsync(Guid punto_venta_id)
        {
            Int32 ticketsICG = 0;
            Int32 ticketsTracker = 0;
            Int32 ticketsSIPOP = 0;
            if (await _context.PuntosDeVenta.Where(x => x.punto_venta_id.Equals(punto_venta_id)).FirstOrDefaultAsync() is TblPuntoVentaEntity puntoVenta)
            {
                if ((await _context.SeguimientosPDV.GroupBy(x => x.PdV).Select(g => g.OrderBy(x => x.ULTIMA_ACTUALIZACION).FirstOrDefault()).ToListAsync())
                    .Where(x => !String.IsNullOrEmpty(x.PdV) && x.PdV.ToUpper().Equals(puntoVenta.nombre.ToUpper())).FirstOrDefault() is TblSeguimientoPDVEntity seguimiento)
                {
                    ticketsICG = seguimiento.T_EN_COLA;
                    if (await _context.SeguimientosPDVTracker.Where(x => x.COMPAÑIA.ToUpper().Equals(seguimiento.COMPAÑIA.ToUpper()) && !String.IsNullOrEmpty(x.PdV) && x.PdV.ToUpper().Equals(seguimiento.PdV)).FirstOrDefaultAsync() is TblSeguimientoPDVTrackerEntity tracker)
                        ticketsTracker = tracker.T_TRACKER;
                }
                PendientesPDVObject pendientes = await this.GetPendientesPDVAsync(puntoVenta.punto_venta_id);
                ticketsSIPOP = pendientes.PendientesInventarios + pendientes.PendientesRecepciones + pendientes.PendientesPedidos;
            }
            return new TicketsSeguimientoPDVObject
            {
                TicketsICG = ticketsICG,
                TicketsTracker = ticketsTracker,
                TicketsSIPOP = ticketsSIPOP
            };
        }
        async Task<Guid> IInventarioNuevoRepository.SaveConteoAsync(TblInventarioConteo2Entity inventario_conteo)
        {
            inventario_conteo.fecha_modificacion = DateTime.Now;
            await _context.AddAsync(inventario_conteo);
            await _context.SaveChangesAsync();
            return inventario_conteo.inventario_conteo_id;
        }

        async Task<Boolean> IInventarioNuevoRepository.UpdateEstadoReconteoAsync(Guid detalle_id, bool estado)
        {
            if (await _context.InventarioDetalless2.Where(x => x.inventario_detalle_id.Equals(detalle_id)).FirstOrDefaultAsync() is TblInventarioDetalle2Entity detalle)
            {
                detalle.requiere_conteo = estado;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        async Task<Boolean> IInventarioNuevoRepository.RequiereReconteoAsync(Guid inventario_id)
            => await _context.InventarioDetalless2.Where(x => x.inventario_id.Equals(inventario_id) && x.requiere_conteo).AnyAsync();

        async Task<Boolean> IInventarioNuevoRepository.DetalleRequiereReconteoAsync(Guid detalle_id)
            => await _context.InventarioDetalless2.Where(x => x.inventario_detalle_id.Equals(detalle_id) && x.requiere_conteo).AnyAsync();
        async Task<InventarioReconteoObject?> IInventarioNuevoRepository.GetInventarioReconteoAsync(Guid inventario_id)
            => await _context.Inventarios2.Include(x => x.detalles).Where(x => x.inventario_id.Equals(inventario_id))
            .Select(x => new InventarioReconteoObject
            {
                Inventario_id = x.inventario_id,
                Codigo = x.codigo_inventario,
                Reconteos = x.detalles.Where(d => d.requiere_conteo).Select(d => new InventarioConteoObjectBasic
                {
                    Producto_id = _context.ProductosPuntoDeVenta.Include(p => p.producto).Where(p => p.producto_punto_venta_id.Equals(d.producto_punto_venta_id)).Select(d => d.producto_id).FirstOrDefault(),
                    Nombre = _context.ProductosPuntoDeVenta.Include(p => p.producto).Where(p => p.producto_punto_venta_id.Equals(d.producto_punto_venta_id)).Select(d => d.producto.nombre).FirstOrDefault(),
                    Cantidad = d.cantidad,
                    Inventario_detalle_id = d.inventario_detalle_id
                })
            }).FirstOrDefaultAsync();
        async Task<IEnumerable<InventarioConteoRead>> IInventarioNuevoRepository.ReconteoAsync(IEnumerable<InventarioConteoSave> reconteos)
        {
            List<InventarioConteoRead> response = new List<InventarioConteoRead>();
            foreach (InventarioConteoSave reconteo in reconteos)
            {
                if (await _context.InventarioDetalless2.Where(x => x.inventario_detalle_id.Equals(reconteo.Inventario_detalle_id) && x.requiere_conteo).FirstOrDefaultAsync() is TblInventarioDetalle2Entity detalle)
                {
                    if (await _context.ProductosPuntoDeVenta.Include(p => p.producto).Where(p => p.producto_punto_venta_id.Equals(detalle.producto_punto_venta_id)).FirstOrDefaultAsync() is TblProductoPuntoVentaEntity productoPuntoVenta)
                    {
                        ReconteoBaseObject reconteoObject = await this.ValidarCantidadStock(productoPuntoVenta.producto_id, productoPuntoVenta.punto_venta_id, reconteo.Cantidad);
                        await _context.AddAsync(new TblInventarioConteo2Entity
                        {
                            cantidad = reconteo.Cantidad,
                            inicial = false,
                            final = !reconteoObject.Reconteo,
                            inventario_detalle_id = reconteo.Inventario_detalle_id
                        });
                        await _context.SaveChangesAsync();
                        response.Add(new InventarioConteoRead
                        {
                            Inventario_detalle_id = reconteo.Inventario_detalle_id,
                            Cantidad = reconteo.Cantidad,
                            RequiereReconteo = reconteoObject.Reconteo
                        });
                        if (!reconteoObject.Reconteo)
                        {
                            detalle.requiere_conteo = false;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
            return response;
        }
        async Task<InventarioReconteoExportable?> IInventarioNuevoRepository.GetReconteosAsync(Guid inventario_id)
            => await _context.Inventarios2.Include(x => x.detalles).ThenInclude(x => x.conteos).Where(x => x.inventario_id.Equals(inventario_id))
            .Select(x => new InventarioReconteoExportable
            {
                Inventario_id = x.inventario_id,
                Codigo = x.codigo_inventario,
                Detalles = x.detalles.Where(d => d.requiere_conteo).Select(d => new InventarioConteoObjectExportable
                {
                    Producto_id = _context.ProductosPuntoDeVenta.Include(p => p.producto).Where(p => p.producto_punto_venta_id.Equals(d.producto_punto_venta_id)).Select(d => d.producto_id).FirstOrDefault(),
                    Nombre = _context.ProductosPuntoDeVenta.Include(p => p.producto).Where(p => p.producto_punto_venta_id.Equals(d.producto_punto_venta_id)).Select(d => d.producto.nombre).FirstOrDefault(),
                    Reconteos = d.conteos.Select(r => new ReconteoObjectExportable
                    {
                        Cantidad = r.cantidad,
                        Inicial = r.inicial,
                        Final = r.final,
                    }),
                    Inventario_detalle_id = d.inventario_detalle_id
                })
            }).FirstOrDefaultAsync();
        #endregion

        #region Private
        private async Task<UnidadInventarioDosRead?> GetUnidadInventarioPorProductoAsync(Guid producto_id)
            => await _context.UnidadesDeInventariosDos.Include(x => x.producto).Include(x => x.producto).ThenInclude(x => x.factores_de_conversion).ThenInclude(x => x.factor_conversion)
            .Where(x => x.producto_id.Equals(producto_id)).Select(x => new UnidadInventarioDosRead
            {
                unidad_inventario_dos_id = x.unidad_inventario_dos_id,
                producto_id = producto_id,
                unidad_consumo = x.unidad_consumo,
                unidad_consumo_contador = x.producto.factores_de_conversion.Where(f => f.factor_conversion.unidad_base.ToUpper().Equals(x.unidad_consumo.ToUpper())).Select(f => f.factor_conversion.contador).FirstOrDefault(),
                unidad_despacho = x.unidad_despacho,
                unidad_despacho_contador = x.producto.factores_de_conversion.Where(f => f.factor_conversion.unidad_base.ToUpper().Equals(x.unidad_despacho.ToUpper())).Select(f => f.factor_conversion.contador).FirstOrDefault(),
                unidad_conteo = x.unidad_conteo,
                unidad_conteo_contador = x.producto.factores_de_conversion.Where(f => f.factor_conversion.unidad_base.ToUpper().Equals(x.unidad_conteo.ToUpper())).Select(f => f.factor_conversion.contador).FirstOrDefault(),
            }).FirstOrDefaultAsync();

        private async Task<IEnumerable<TblUsuarioPuntoVentaEntity>> GetUsuariosPuntosVentas(Guid usuario_id, bool activos = false)
        {
            IEnumerable<TblUsuarioPuntoVentaEntity> vista = activos ? await _context.UsuariosPuntoDeVenta.Where(l => l.usuario_id.Equals(usuario_id) && !l.fecha_eliminacion.HasValue).ToListAsync() : await _context.UsuariosPuntoDeVenta.Where(l => l.usuario_id == usuario_id).ToListAsync();
            return vista;
        }

        private async Task<TblProductoPuntoVentaEntity?> GetProductoPuntoVentaId(Guid producto_id, Guid punto_venta_id)
            => await _context.ProductosPuntoDeVenta.FirstOrDefaultAsync(l => l.producto_id == producto_id && l.punto_venta_id == punto_venta_id);

        private async Task<ReconteoBaseObject> ValidarCantidadStock(Guid producto_id, Guid punto_venta_id, double cantidad)
        {
            StockValidaciones validacion = StockValidaciones.SinValidar;
            Boolean reconteo = false;
            double cantidadStock = await _context.StockTeoricoInventariosDos.Where(x => x.producto_id.Equals(producto_id) && x.punto_venta_id.Equals(punto_venta_id))
                .Select(x => x.stock_teorico).FirstOrDefaultAsync();
            if (cantidad < cantidadStock)
                validacion = StockValidaciones.Inferior;
            else if (cantidad == cantidadStock)
                validacion = StockValidaciones.Igual;
            else if (cantidad > cantidadStock)
            {
                validacion = StockValidaciones.Superior;
                reconteo = (cantidadStock + (cantidadStock * PopsyConstants.PorcentajeToleranciaReconteo / 100)) < cantidad;
            }
            return new ReconteoBaseObject
            {
                CantidadValidacion = validacion,
                Reconteo = reconteo
            };
        }

        async Task<PendientesPDVObject> GetPendientesPDVAsync(Guid punto_venta_id)
            =>
            new PendientesPDVObject
            {
                PendientesPedidos = await _context.Pedidos.Include(x => x.respuestas).Where(x => x.punto_venta_id.Equals(punto_venta_id) && x.estado.Equals(SAPEstado.Pendiente) && x.respuestas.Where(r => r.type.Equals(PopsyConstants.SAPErrorType)).Any()).CountAsync(),
                PendientesInventarios = 0,//await _context.Inventarios2.Where(x => x.punto_venta_id.Equals(punto_venta_id) && x.estado.Equals(SAPEstado.Pendiente)).CountAsync(),
                PendientesRecepciones = await _context.RecepcionesDeCompra.Include(x => x.respuestas).Include(x => x.orden_de_compra).Where(x => x.orden_de_compra.punto_venta_id.Equals(punto_venta_id) && x.estado.Equals(SAPEstado.Pendiente) && x.respuestas.Where(r => !String.IsNullOrEmpty(r.Type) && r.Type.Equals(PopsyConstants.SAPErrorType) && r.Activo).Any()).CountAsync(),
            };
        #endregion
    }
}