namespace Popsy.Objects
{
    public record ResponsePuntoDeVentaPopsySAP
    {
        public Guid Punto_venta_id { get; set; }
        public string Codigo { get; set; } = default!;
        public ISet<ResponsePopsySAP> Stocks { get; set; } = new HashSet<ResponsePopsySAP>();
    }
}