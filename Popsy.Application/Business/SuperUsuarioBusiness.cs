using AutoMapper;

using Popsy.Common;
using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Business
{
    public class SuperUsuarioBusiness : ApplicationBase, ISuperUsuarioBusiness
    {
        private readonly IInventarioNuevoRepository _repository;
        private readonly IEmailService _email;
        private readonly IEmailInfoRepository _emailInfo;
        private readonly IPuntosVentasRepository _puntoVentaRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mapper">mapper.</param>
        /// <param name="repository"><see cref="IInventarioNuevoRepository"/> instancia.</param>
        /// <param name="email"><see cref="IEmailService"/> instancia.</param>
        /// <param name="emailInfo"><see cref="IEmailInfoRepository"/> instancia.</param>
        /// <param name="puntoVentaRepository"><see cref="IPuntosVentasRepository"/> instancia.</param>
        public SuperUsuarioBusiness(IMapper mapper,
            IInventarioNuevoRepository repository,
            IEmailService email,
            IEmailInfoRepository emailInfo,
            IPuntosVentasRepository puntoVentaRepository) : base(mapper)
        {
            _repository = repository;
            _email = email;
            _emailInfo = emailInfo;
            _puntoVentaRepository = puntoVentaRepository;
        }
        async Task<InventarioResponse> ISuperUsuarioBusiness.CreateInventarioBaseAsync(InventarioBaseSave inventario_base, Guid punto_venta_id)
        {
            if (!await _puntoVentaRepository.ExistePuntoDeVentaAsync(punto_venta_id))
                throw new PopsyException(ErrorType.PuntoDeVentaNoEncontrado, ErrorSource.NoEncontrado);
            TicketsSeguimientoPDVObject ticketsRepresados = await _repository.GetTicketsPDVAsync(punto_venta_id);
            Boolean tieneTickets = ticketsRepresados.TicketsICG > 0 || ticketsRepresados.TicketsSIPOP > 0 || ticketsRepresados.TicketsTracker > 0;
            Boolean validarCantidades = !tieneTickets;
            InventarioCreadoResponse response = await _repository.CreateInventarioBaseAsync(inventario_base, punto_venta_id, validarCantidades);
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

        #region Private
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
