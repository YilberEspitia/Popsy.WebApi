namespace Popsy.Settings
{
    /// <summary>
    /// Configuración de integración para popsy.
    /// </summary>
    public record IntegracionPopsySettings
    {
        /// <summary>
        /// Nombre de usuario para autenticación.
        /// </summary>
        public String Username { get; set; } = default!;
        /// <summary>
        /// Contraseña para autenticación.
        /// </summary>
        public String Password { get; set; } = default!;
        /// <summary>
        /// Tipo de autenticación.
        /// </summary>
        public String AuthenticationType { get; set; } = default!;
        /// <summary>
        /// Endpoint.
        /// </summary>
        public String EndPoint { get; set; } = default!;
        /// <summary>
        /// Api para ordenes de compra.
        /// </summary>
        public String ApiOrdenDeCompra { get; set; } = default!;
        /// <summary>
        /// Api para proveedores.
        /// </summary>
        public String ApiProveedorRecepcion { get; set; } = default!;
        /// <summary>
        /// Api para recepcion de compras.
        /// </summary>
        public String ApiRecepcionDeCompra { get; set; } = default!;
        /// <summary>
        /// Api para stock teorico de inventario.
        /// </summary>
        public String ApiStockTeoricoInventario { get; set; } = default!;
        /// <summary>
        /// Api de factores de conversión para inventarios.
        /// </summary>
        public String ApiFacConversionInventario { get; set; } = default!;
        /// <summary>
        /// Api de stock diario.
        /// </summary>
        public String ApiStockDiario { get; set; } = default!;
        /// <summary>
        /// Ambiente.
        /// </summary>
        public String Ambiente { get; set; } = default!;
        /// <summary>
        /// Cliente.
        /// </summary>
        public String SapClient { get; set; } = default!;
    }
}
