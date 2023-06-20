using System.ComponentModel.DataAnnotations;

namespace Popsy.Entities
{
    public class VistaMonitorInventarioEntity
    {
        [Key]
        public Guid inventario_id { get; set; }
        public string codigo_inventario { get; set; }
        public Guid tipo_inventario_id { get; set; }
        public string? nombre_tipo_inventario { get; set; }
        public DateTime fecha_toma_fisica { get; set; }
        public DateTime fecha_registro { get; set; }
        public string? usuario_inventario { get; set; }
        public Guid punto_venta_id { get; set; }
    }
}