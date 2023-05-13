using Popsy.Entities;

namespace Popsy.Objects
{
    public class ReadPuntoVentaDetalleEntity
    {
        public Guid punto_venta_id { get; set; }
        public string punto_venta_nombre { get; set; }
        public string codigo_punto_venta { get; set; }
        public IEnumerable<VistaPuntosVentaBodegasObject> bodegas { get; set; }

    }
}