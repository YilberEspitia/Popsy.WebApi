using Popsy.Entities;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Business
{
    public class CreateInventarioBaseBusiness : ICreateInventarioBaseBusiness
    {
        private readonly IInventariosRepository _repoInventarios;
        private readonly IInventarioDetalleRepository _repoInventarioDetalle;
        private readonly IVistaResumenInventarioRepository _repoVistaInventarioDetalle;
        private readonly IUsuariosPuntosVentasRepository _repoUsuariosPuntosVentas;
        private readonly IProductosPuntosVentaRepository _repoProductosPuntosVentas;

        public CreateInventarioBaseBusiness(IInventariosRepository repoInventarios, IInventarioDetalleRepository repoInventarioDetalle
        , IVistaResumenInventarioRepository repoVistaInventarioDetalle
        , IUsuariosPuntosVentasRepository repoUsuariosPuntosVentas
        , IProductosPuntosVentaRepository repoProductosPuntosVentas)
        {
            _repoInventarios = repoInventarios;
            _repoInventarioDetalle = repoInventarioDetalle;
            _repoVistaInventarioDetalle = repoVistaInventarioDetalle;
            _repoUsuariosPuntosVentas = repoUsuariosPuntosVentas;
            _repoProductosPuntosVentas = repoProductosPuntosVentas;
        }
        async Task<RespuestaServicioEntity> ICreateInventarioBaseBusiness.CreateInventarioBase(CreateInventarioBaseEntity inventario_base)
        {
            RespuestaServicioEntity respuesta = new RespuestaServicioEntity();
            TblInventarioEntity inventarioBase = new TblInventarioEntity();
            IEnumerable<TblUsuarioPuntoVentaEntity> puntoVentaList = await _repoUsuariosPuntosVentas.GetUsuariosPuntosVentas(inventario_base.usuario_id);
            TblUsuarioPuntoVentaEntity puntoVenta = new TblUsuarioPuntoVentaEntity();
            if (puntoVentaList.Count() > 0)
            {
                puntoVenta = puntoVentaList.FirstOrDefault();
            }
            inventarioBase.punto_venta_id = puntoVenta.punto_venta_id;
            inventarioBase.usuario_id = inventario_base.usuario_id;
            inventarioBase.tipo_inventario_id = inventario_base.tipo_inventario_id;
            inventarioBase.codigo_inventario = "I-" + DateTime.Now.ToString("yyyyMMddHHss");
            inventarioBase.fecha_toma_fisica = DateTime.Now;
            inventarioBase.fecha_registro = inventario_base.fecha_registro;
            _repoInventarios.Add(inventarioBase);
            foreach (CreateInventarioBaseDetalleEntity detalle in inventario_base.inventario_detalle)
            {
                TblProductoPuntoVentaEntity productoPuntoVentaList = await _repoProductosPuntosVentas.GetProductoPuntoVentaId(detalle.producto_id, puntoVenta.punto_venta_id);
                TblInventarioDetalleEntity inventarioDetalle = new TblInventarioDetalleEntity();
                inventarioDetalle.inventario_id = inventarioBase.inventario_id;
                inventarioDetalle.producto_punto_venta_id = productoPuntoVentaList.producto_punto_venta_id;
                inventarioDetalle.bodega_id = detalle.bodega_id;
                inventarioDetalle.minima_unidad = detalle.minima_unidad;
                inventarioDetalle.cantidad = detalle.cantidad;
                _repoInventarioDetalle.Add(inventarioDetalle);
            }
            respuesta.Respuesta = "Inventario creado : " + inventarioBase.codigo_inventario;
            return respuesta;
        }

        public async Task<UpdateInventarioBaseEntity> UpdateInventarioBase(UpdateInventarioBaseEntity inventario_base)
        {
            IEnumerable<VistaResumenInventarioEntity> infoDetalle = await _repoVistaInventarioDetalle.GetVistaResumenInventarioById(inventario_base.inventario_id);
            IEnumerable<TblUsuarioPuntoVentaEntity> puntoVentaList = await _repoUsuariosPuntosVentas.GetUsuariosPuntosVentas(inventario_base.usuario_id);
            TblUsuarioPuntoVentaEntity puntoVenta = new TblUsuarioPuntoVentaEntity();
            if (puntoVentaList.Count() > 0)
            {
                puntoVenta = puntoVentaList.FirstOrDefault();
            }

            foreach (VistaResumenInventarioEntity detalleEliminar in infoDetalle)
            {

            }

            foreach (CreateInventarioBaseDetalleEntity detalleCrear in inventario_base.inventario_detalle)
            {
                TblProductoPuntoVentaEntity productoPuntoVentaList = await _repoProductosPuntosVentas.GetProductoPuntoVentaId(detalleCrear.producto_id, puntoVenta.punto_venta_id);
                TblInventarioDetalleEntity inventarioDetalle = new TblInventarioDetalleEntity();
                inventarioDetalle.inventario_id = inventario_base.inventario_id;
                inventarioDetalle.producto_punto_venta_id = productoPuntoVentaList.producto_punto_venta_id;
                inventarioDetalle.bodega_id = detalleCrear.bodega_id;
                inventarioDetalle.minima_unidad = detalleCrear.minima_unidad;
                inventarioDetalle.cantidad = detalleCrear.cantidad;
                _repoInventarioDetalle.Add(inventarioDetalle);
            }
            return inventario_base;
        }

    }
}