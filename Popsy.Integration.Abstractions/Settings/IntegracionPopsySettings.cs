namespace Popsy.Settings
{
    public record IntegracionPopsySettings
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String AuthenticationType { get; set; }
        public String EndPoint { get; set; }
        public String ApiOrdenDeCompra { get; set; }
        public String ApiProveedorRecepcion { get; set; }
        public String ApiRecepcionDeCompra { get; set; }
        public String Ambiente { get; set; }
        public String SapClient { get; set; }
    }
}
