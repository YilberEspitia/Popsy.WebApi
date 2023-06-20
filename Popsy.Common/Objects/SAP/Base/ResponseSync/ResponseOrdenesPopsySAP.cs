namespace Popsy.Objects
{
    public record ResponseOrdenesPopsySAP
    {
        public Guid Punto_venta_id { get; set; }
        public string Codigo { get; set; } = default!;
        public ISet<ResponsePopsyOrdenesSAP> Ordenes { get; set; } = new HashSet<ResponsePopsyOrdenesSAP>();
    }
}