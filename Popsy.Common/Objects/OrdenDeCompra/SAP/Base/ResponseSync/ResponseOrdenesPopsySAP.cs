namespace Popsy.Objects
{
    public record ResponseOrdenesPopsySAP
    {
        public Guid Punto_venta_id { get; set; }
        public string Codigo { get; set; }
        public ISet<ResponsePopsySAP> Ordenes { get; set; }
    }
}