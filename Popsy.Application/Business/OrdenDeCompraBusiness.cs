﻿using AutoMapper;

using Popsy.Common;
using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Business
{
    public class OrdenDeCompraBusiness : ApplicationBase, IOrdenDeCompraBusiness
    {
        private readonly IOrdenDeCompraRepository _ordenRepository;
        private readonly IDetalleOrdenDeCompraRepository _detalleOrdenRepository;
        private readonly IRecepcionDeCompraRepository _recepcionRepository;

        public OrdenDeCompraBusiness(IMapper mapper,
            IOrdenDeCompraRepository ordenRepository,
            IDetalleOrdenDeCompraRepository detalleOrdenRepository,
            IRecepcionDeCompraRepository recepcionRepository) : base(mapper)
        {
            _ordenRepository = ordenRepository;
            _detalleOrdenRepository = detalleOrdenRepository;
            _recepcionRepository = recepcionRepository;
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
            TblOrdenDeCompraEntity? ordenDeCompraDb = await _ordenRepository.GetOrdenDeCompraAsync(ordenDeCompra.orden_compra_id);
            if (ordenDeCompraDb is null)
            {
                await _ordenRepository.CreateAsync(ordenDeCompra);
                response = true;
            }
            else
            {
                await _ordenRepository.UpdateAsync(ordenDeCompra);
                response = false;
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
            TblDetalleOrdenDeCompraEntity? detalleOrdenDeCompraDb = await _detalleOrdenRepository.GetDetalleOrdenDeCompraAsync(detalleOrdenDeCompra.detalle_orden_compra_id);
            if (detalleOrdenDeCompraDb is null)
            {
                await _detalleOrdenRepository.CreateAsync(detalleOrdenDeCompra);
                response = true;
            }
            else
            {
                await _detalleOrdenRepository.UpdateAsync(detalleOrdenDeCompra);
                response = false;
            }
            return response;
        }

        async Task<bool> IOrdenDeCompraBusiness.CreateManyAsync(IEnumerable<DetalleOrdenDeCompraSave> detalleOrdenDeCompra)
            => await _detalleOrdenRepository.CreateManyAsync(_mapper.Map<IEnumerable<TblDetalleOrdenDeCompraEntity>>(detalleOrdenDeCompra));

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
            TblRecepcionDeCompraEntity? recepcionDeCompraDb = await _recepcionRepository.GetRecepcionDeCompraAsync(recepcionDeCompra.recepcion_compra_id);
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

        #region Private
        private string GetConsecutivo(int constante)
        {
            DateTime fechaActual = DateTime.Now;

            string año = fechaActual.Year.ToString().Substring(2);
            string mes = fechaActual.Month.ToString("D2");
            string dia = fechaActual.Day.ToString("D2");

            string numeroFormateado = (constante + 1).ToString("D6");

            return $"{PopsyConstants.AbrevOrdenDeCompra}-{año}{mes}{dia}{numeroFormateado}"; ;
        }
        #endregion
    }
}
