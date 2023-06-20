namespace Popsy.Objects
{
    public class DetalleInventarioBaseSave
    {
        public Guid producto_id { get; set; }
        public Guid bodega_id { get; set; }
        public string unidad { get; set; } = default!;
        public double cantidad { get; set; }
        public UnidadInventarioDosSave unidad_inventario { get; set; } = default!;
    }
}