using System.ComponentModel.DataAnnotations;

namespace Popsy.Entities
{
    public class VistaPuntosVentaBodegasEntity
    {
        [Key]
        public Guid bodegas_punto_venta_id { get; set; }
        public Guid punto_venta_id { get; set; }
        public Guid bodega_id { get; set; }
        public string nombre_punto_venta { get; set; }
        public string codigo_punto_venta { get; set; }
        public string nombre_bodega { get; set; }

    }
}