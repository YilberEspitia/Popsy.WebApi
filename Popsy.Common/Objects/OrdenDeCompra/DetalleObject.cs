namespace Popsy.Objects
{
    public record DetalleObject
    {
        public Guid producto_id { get; set; }
        public Guid orden_compra_id { get; set; }
        public string unidad_presentacion { get; set; } = default!;
    }
}
