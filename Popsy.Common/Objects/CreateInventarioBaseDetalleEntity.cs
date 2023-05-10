namespace Popsy.Objects
{
    public class CreateInventarioBaseDetalleEntity
    {
        public Guid producto_id { get; set; }
        public Guid bodega_id { get; set; }
        public string minima_unidad { get; set; }
        public int cantidad { get; set; }
    }
}