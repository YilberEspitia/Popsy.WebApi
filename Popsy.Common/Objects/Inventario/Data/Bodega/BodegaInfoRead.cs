namespace Popsy.Objects
{
    public class BodegaInfoRead
    {
        public Guid Bodegas_punto_venta_id { get; set; }
        public Guid Bodega_id { get; set; } = default!;
        public String Nombre_bodega { get; set; } = default!;
    }
}
