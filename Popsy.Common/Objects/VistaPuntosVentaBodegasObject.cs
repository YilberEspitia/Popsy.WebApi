using System.ComponentModel.DataAnnotations;

namespace Popsy.Entities
{
    public class VistaPuntosVentaBodegasObject
    {
        [Key]
        public Guid bodegas_punto_venta_id { get; set; }
        public Guid bodega_id { get; set; }
        public string nombre_bodega { get; set; }

    }
}