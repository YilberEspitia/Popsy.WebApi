namespace Popsy.Objects
{
    public record RecepcionEmailObject
    {
        public string Fecha { get; set; } = default!;
        public string Usuario { get; set; } = default!;
        public string PuntoDeVenta { get; set; } = default!;
        public string Proveedor { get; set; } = default!;
        public string Factura { get; set; } = default!;
        public string Codigo { get; set; } = default!;
        public string Productos { get; set; } = default!;
        public string CantidadesPedidas { get; set; } = default!;
        public string CantidadesRecibidas { get; set; } = default!;
        public string Unidades { get; set; } = default!;
    }
}
