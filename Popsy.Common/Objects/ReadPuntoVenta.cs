using Popsy.Entities;

namespace Popsy.Objects
{
    public class ReadPuntoVenta
    {
        public IEnumerable<VistaPuntosVentaBodegasEntity> bodegas { get; set; }
        public DateTime? fecha_ultimo_inventario { get; set; }

    }
}