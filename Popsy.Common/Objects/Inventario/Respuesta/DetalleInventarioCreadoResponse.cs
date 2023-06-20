using Popsy.Enums;

namespace Popsy.Objects
{
    public class DetalleInventarioCreadoResponse : ReconteoBaseObject
    {
        public Guid Inventario_detalle_id { get; set; }
        public Guid Producto_id { get; set; }
        public Guid Bodega_id { get; set; }
        public Double Cantidad { get; set; }
        public String Unidad { get; set; } = default!;
        public AccionesBD Accion { get; set; }
    }
}