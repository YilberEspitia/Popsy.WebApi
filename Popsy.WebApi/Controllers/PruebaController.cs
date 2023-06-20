using Microsoft.AspNetCore.Mvc;

using Popsy.Attributes;
using Popsy.Common;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Controllers
{
    /// <summary>
    /// Controlador para hacer pruebas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [DisableSwagger]
    [DisableAPI]
    public class PruebaController : ControllerBase
    {
        private readonly IEmailService _email;
        private readonly ISapSyncIntegration _sap;

        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="email">Email service.</param>
        /// <param name="sap">SAP service.</param>
        public PruebaController(IEmailService email, ISapSyncIntegration sap)
        {
            _email = email;
            _sap = sap;
        }
        /// <summary>
        /// Método para probar el envío de correos.
        /// Inventario: Fecha -- Usuario -- Punto de Venta -- Tipo de Inventario -- Código -- Producto (Nombre) -- Bodega -- Cantidad Inventariada -- Unidad de Medida
        /// Recepción de compra: Fecha -- Usuario -- Punto de Venta -- Recepción Proveedor -- Factura No -- Código -- Producto (Nombre) -- Cantidad Pedida -- Cantidad Recibida -- Unidad de Medida
        /// </summary>
        /// <param name="to">Destinatario.</param>
        /// <param name="emailType">Tipo de correo.</param>
        /// <param name="parametros">Parametros a reemplazar.</param>
        [HttpPost("SendEmail")]
        public ActionResult SendEmail(string to, EmailType emailType, [FromBody] params String[] parametros)
        {
            string htmlBody = String.Empty;
            switch (emailType)
            {
                case EmailType.Inventario:
                    htmlBody = PopsyConstants.InventarioBaseHTMLBody;
                    break;
                case EmailType.RecepcionDeCompra:
                    htmlBody = PopsyConstants.RecepcionDeCompraHTMLBody;
                    break;
            }
            string body = this.ReemplazarParametros(htmlBody, parametros);
            _email.SendEmail(to, body, emailType);
            return Ok();
        }
        /// <summary>
        /// Trae las órdenes de compra por código de almacén.
        /// </summary>
        /// <param name="codigo_almacen">Código de almacén (A005).</param>
        /// <returns>Sap response.</returns>

        [HttpGet("GetOrdenesDeCompra")]
        public async Task<ResponseSAP<ResultOrdenDeCompra>?> GetOrdenesDeCompra(string codigo_almacen)
            => await _sap.GetOrdenesDeCompra(codigo_almacen);
        /// <summary>
        /// Trae el stock del inventario teorico.
        /// </summary>
        /// <param name="codigo_almacen">Código de almacen (A005).</param>
        /// <returns>Sap response.</returns>
        [HttpGet("GetStockTeoricoDeInventario")]
        public async Task<ResponseSAP<ResultStockTeoricoDeInventario>?> GetStockTeoricoDeInventario(string codigo_almacen)
            => await _sap.GetStockTeoricoDeInventario(codigo_almacen);
        /// <summary>
        /// Trae los proveedores.
        /// </summary>
        /// <returns>Sap response.</returns>
        [HttpGet("GetProveedoresRecepcion")]
        public async Task<ResponseSAP<ResultProveedorRecepcion>?> GetProveedoresRecepcion()
            => await _sap.GetProveedoresRecepcion();
        /// <summary>
        /// Trae los factores de conversión para los inventarios.
        /// </summary>
        /// <returns>Sap response.</returns>
        [HttpGet("GetUnidadInventarioDos")]
        public async Task<ResponseSAP<ResultUnidadInventarioDos>?> GetUnidadInventarioDos()
            => await _sap.GetUnidadInventarioDos();
        /// <summary>
        /// Trae el stock del día.
        /// </summary>
        /// <param name="date">Fecha a consultar.</param>
        /// <param name="codigo_almacen">Código de almacen.</param>
        /// <returns>Sap response.</returns>
        [HttpGet("GetStockDia")]
        public async Task<ResponseSAP<ResultStockDia>?> GetStockDia(DateTime date, String codigo_almacen)
            => await _sap.GetStockDia(date.ToString("yyyyMMdd"), codigo_almacen);
        /// <summary>
        /// Envia las ordes de compra.
        /// </summary>
        /// <param name="xmlObject">Objeto.</param>
        /// <param name="recepcion_compra_id">Recepción de compra id.</param>
        /// <returns>Sap response.</returns>
        [HttpPost("EnviaRecepcionDeCompra")]
        public async Task<ResponseRecepcionDeCompraXMLObject> EnviaRecepcionDeCompra(XMLSoMvt xmlObject, Guid recepcion_compra_id)
            => await _sap.EnviaRecepcionDeCompra(xmlObject, recepcion_compra_id);

        #region Private
        private string ReemplazarParametros(string htmlBody, params String[] parametros)
        {
            string body = htmlBody;
            for (Int16 i = 0; i < parametros.Length; i++)
                body = body.Replace($"{{{i}}}", parametros[i]);
            return body;
        }
        #endregion
    }
}