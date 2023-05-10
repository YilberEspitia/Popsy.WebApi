using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("usuarios_puntos_ventas")]
    public class TblUsuariosPuntosVentasEntity
    {
        [Key]
        public Guid usuario_punto_venta_id { get; set; }
        public Guid punto_venta_id { get; set; }
        public Guid usuario_id { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public Nullable<DateTime> fecha_eliminacion { get; set; }
    }
}