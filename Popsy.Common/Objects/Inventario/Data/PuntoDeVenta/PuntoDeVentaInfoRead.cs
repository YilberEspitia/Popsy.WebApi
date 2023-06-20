namespace Popsy.Objects
{
    public class PuntoDeVentaInfoRead
    {
        public Guid Punto_venta_id { get; set; }
        public String Nombre_punto_venta { get; set; } = default!;
        public String Codigo_punto_venta { get; set; } = default!;
        public DateTime? Fecha_ultimo_inventario { get; set; }
        public String? Nombre_tipo_inventario { get; set; }
        public ISet<BodegaInfoRead> Bodegas { get; set; } = new HashSet<BodegaInfoRead>();
    }
}
