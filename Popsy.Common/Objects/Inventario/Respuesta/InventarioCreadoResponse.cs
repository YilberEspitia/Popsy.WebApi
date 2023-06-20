namespace Popsy.Objects
{
    public class InventarioCreadoResponse
    {
        public Guid Inventario_id { get; set; }
        public Guid Usuario_id { get; set; }
        public DateTime Fecha_registro { get; set; }
        public Guid Punto_venta_id { get; set; }
        public Guid Tipo_inventario_id { get; set; }
        public String Codigo_inventario { get; set; } = default!;
        public Boolean Reconteo { get; set; }
        public IEnumerable<DetalleInventarioCreadoResponse> Detalles { get; set; } = new HashSet<DetalleInventarioCreadoResponse>();
    }
}