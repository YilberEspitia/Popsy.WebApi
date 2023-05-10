using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("inventarios", Schema = "SIPOP")]
    public class TblInventariosEntity
    {
        [Key]
        public Guid inventario_id { get; set; }
        public Guid punto_venta_id { get; set; }
        public Guid usuario_id { get; set; }
        public Guid tipo_inventario_id { get; set; }
        public string codigo_inventario { get; set; }
        public DateTime fecha_toma_fisica { get; set; }
        public DateTime fecha_registro { get; set; }

    }
}