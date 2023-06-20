namespace Popsy.Objects
{
    public record PuntoDeVentaBasicRead
    {
        public Guid punto_venta_id { get; set; }
        public string codigo { get; set; }
    }
}
