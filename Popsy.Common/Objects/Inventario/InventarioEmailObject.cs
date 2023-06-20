namespace Popsy.Objects
{
    public record InventarioEmailObject
    {
        public string Fecha { get; set; } = default!;
        public string Usuario { get; set; } = default!;
        public string PuntoDeVenta { get; set; } = default!;
        public string TipoDePedido { get; set; } = default!;
        public string Codigo { get; set; } = default!;
        public string Productos { get; set; } = default!;
        public string Bodegas { get; set; } = default!;
        public string Cantidades { get; set; } = default!;
        public string Unidades { get; set; } = default!;
    }
}
