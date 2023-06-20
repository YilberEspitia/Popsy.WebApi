using Popsy.Common;
using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Business
{
    public class CreateInventarioBaseBusiness : ICreateInventarioBaseBusiness
    {
        private readonly IInventariosRepository _repoInventarios;
        private readonly IInventarioDetalleRepository _repoInventarioDetalle;
        private readonly IVistaResumenInventarioRepository _repoVistaInventarioDetalle;
        private readonly IUsuariosRepository _repoUsuariosPuntosVentas;
        private readonly IProductosPuntosVentaRepository _repoProductosPuntosVentas;
        private readonly IEmailService _email;
        private readonly IEmailInfoRepository _emailInfo;

        public CreateInventarioBaseBusiness(IInventariosRepository repoInventarios, IInventarioDetalleRepository repoInventarioDetalle,
            IVistaResumenInventarioRepository repoVistaInventarioDetalle,
            IUsuariosRepository repoUsuariosPuntosVentas,
            IProductosPuntosVentaRepository repoProductosPuntosVentas,
            IEmailService email,
            IEmailInfoRepository emailInfo)
        {
            _repoInventarios = repoInventarios;
            _repoInventarioDetalle = repoInventarioDetalle;
            _repoVistaInventarioDetalle = repoVistaInventarioDetalle;
            _repoUsuariosPuntosVentas = repoUsuariosPuntosVentas;
            _repoProductosPuntosVentas = repoProductosPuntosVentas;
            _email = email;
            _emailInfo = emailInfo;
        }
        async Task<RespuestaServicioEntity> ICreateInventarioBaseBusiness.CreateInventarioBase(CreateInventarioBaseEntity inventario_base)
        {
            RespuestaServicioEntity respuesta = new RespuestaServicioEntity();
            TblInventarioEntity inventarioBase = new TblInventarioEntity();
            IEnumerable<TblUsuarioPuntoVentaEntity> puntoVentaList = await _repoUsuariosPuntosVentas.GetUsuariosPuntosVentas(inventario_base.usuario_id, true);
            TblUsuarioPuntoVentaEntity puntoVenta = new TblUsuarioPuntoVentaEntity();
            if (puntoVentaList.Count() > 0)
            {
                puntoVenta = puntoVentaList.FirstOrDefault()!;
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
                TblProductoPuntoVentaEntity? productoPuntoVentaList = await _repoProductosPuntosVentas.GetProductoPuntoVentaId(detalle.producto_id, puntoVenta.punto_venta_id);
                if (productoPuntoVentaList is not null)
                {
                    TblInventarioDetalleEntity inventarioDetalle = new TblInventarioDetalleEntity();
                    inventarioDetalle.inventario_id = inventarioBase.inventario_id;
                    inventarioDetalle.producto_punto_venta_id = productoPuntoVentaList.producto_punto_venta_id;
                    inventarioDetalle.bodega_id = detalle.bodega_id;
                    inventarioDetalle.minima_unidad = detalle.minima_unidad;
                    inventarioDetalle.cantidad = detalle.cantidad;
                    _repoInventarioDetalle.Add(inventarioDetalle);
                }
            }
            respuesta.Respuesta = "Inventario creado : " + inventarioBase.codigo_inventario;
            InventarioEmailObject inventarioEmail = new InventarioEmailObject
            {
                Fecha = inventarioBase.fecha_registro.ToString("yyyy-MM-dd"),
                Usuario = await _emailInfo.GetUsuarioMail(inventarioBase.usuario_id),
                PuntoDeVenta = await _emailInfo.GetNombrePuntoDeVenta(inventarioBase.punto_venta_id),
                TipoDePedido = await _emailInfo.GetTipoDeInventario(inventarioBase.tipo_inventario_id),
                Codigo = inventarioBase.codigo_inventario,
                Productos = await this.GetProductos(inventario_base.inventario_detalle.Select(x => x.producto_id)),
                Bodegas = await this.GetBodegas(inventario_base.inventario_detalle.Select(x => x.bodega_id)),
                Cantidades = this.GetCantidades(inventario_base.inventario_detalle.Select(x => x.cantidad)),
                Unidades = this.GetUnidades(inventario_base.inventario_detalle.Select(x => x.minima_unidad))
            };
            this.EnviarCorreoInventario(inventarioEmail);
            return respuesta;
        }

        async Task<UpdateInventarioBaseEntity> ICreateInventarioBaseBusiness.UpdateInventarioBase(UpdateInventarioBaseEntity inventario_base)
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
                TblProductoPuntoVentaEntity productoPuntoVentaList = (await _repoProductosPuntosVentas.GetProductoPuntoVentaId(detalleCrear.producto_id, puntoVenta.punto_venta_id))!;
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

        void ICreateInventarioBaseBusiness.EnviarCorreoInventario(InventarioEmailObject inventarioEmail)
        {
            this.EnviarCorreoInventario(inventarioEmail);
        }

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
    }
}