using Popsy.Enums;

namespace Popsy.Objects
{
    public class InventarioGestionSAP
    {
        public Guid Inventario_id { get; set; }
        public String Codigo_inventario { get; set; } = default!;
        public Guid Punto_venta_id { get; set; }
        public String Codigo_punto_venta { get; set; } = default!;
        public DateTime Fecha_creacion { get; set; }
        public SAPEstado Estado { get; set; }
        public IEnumerable<DetalleInventarioGestionSAP> Detalles { get; set; } = new HashSet<DetalleInventarioGestionSAP>();
    }
}
