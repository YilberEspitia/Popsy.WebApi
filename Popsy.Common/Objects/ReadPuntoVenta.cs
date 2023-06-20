using Popsy.Entities;

namespace Popsy.Objects
{
    public class ReadPuntoVenta
    {
        public string nombre_punto_venta { get; set; }
        public string codigo_punto_venta { get; set; }
        public Guid punto_venta_id { get; set; }
        public IEnumerable<VistaPuntosVentaBodegasObject> bodegas { get; set; }
        public DateTime? fecha_ultimo_inventario { get; set; }
        public String? nombre_tipo_inventario { get; set; }

    }
}