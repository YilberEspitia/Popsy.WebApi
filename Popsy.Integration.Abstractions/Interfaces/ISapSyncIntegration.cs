using Popsy.Objects;

namespace Popsy.Interfaces
{
    /// <summary>
    /// Integración que expone los metodos referentes a las recepciones de compras con SAP.
    /// </summary>
    public interface ISapSyncIntegration
    {
        /// <summary>
        /// Trae las ordes de compra por código de almacen.
        /// </summary>
        /// <param name="codigo_almacen">Código de almacen.</param>
        /// <returns>Sap response.</returns>
        Task<ResponseSAP<ResultOrdenDeCompra>?> GetOrdenesDeCompra(String codigo_almacen);
        /// <summary>
        /// Trae el stock del inventario teorico.
        /// </summary>
        /// <param name="codigo_almacen">Código de almacen.</param>
        /// <returns>Sap response.</returns>
        Task<ResponseSAP<ResultStockTeoricoDeInventario>?> GetStockTeoricoDeInventario(String codigo_almacen);
        /// <summary>
        /// Trae los proveedores.
        /// </summary>
        /// <returns>Sap response.</returns>
        Task<ResponseSAP<ResultProveedorRecepcion>?> GetProveedoresRecepcion();
        /// <summary>
        /// Trae los factores de conversión para los inventarios.
        /// </summary>
        /// <returns>Sap response.</returns>
        Task<ResponseSAP<ResultUnidadInventarioDos>?> GetUnidadInventarioDos();
        /// <summary>
        /// Trae el stock del día.
        /// </summary>
        /// <param name="date">Fecha a consultar.</param>
        /// <param name="codigo_almacen">Código de almacen.</param>
        /// <returns>Sap response.</returns>
        Task<ResponseSAP<ResultStockDia>?> GetStockDia(String date, String codigo_almacen);
        /// <summary>
        /// Envia una orden de compra.
        /// </summary>
        /// <param name="xmlObject">Objeto.</param>
        /// <param name="recepcion_compra_id">Recepción de compra id.</param>
        /// <returns>Sap response.</returns>
        Task<ResponseRecepcionDeCompraXMLObject> EnviaRecepcionDeCompra(XMLSoMvt xmlObject, Guid recepcion_compra_id);
        /// <summary>
        /// Envia una orden de compra con XML.
        /// </summary>
        /// <param name="xmlFormateado">Xml del historial.</param>
        /// <param name="recepcion_compra_id">Recepción de compra id.</param>
        /// <returns>Sap response.</returns>
        Task<ResponseRecepcionDeCompraXMLObject> EnviaRecepcionDeCompra(String xmlFormateado, Guid recepcion_compra_id);
    }
}
