using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("productos_puntos_venta")]
    public class TblProductosPuntosVentaEntity
    {
        [Key]
        public Guid producto_punto_venta_id { get; set; }
        public Guid producto_id { get; set; }
        public Guid punto_venta_id { get; set; }
        public int cantidad_producto_maxima { get; set; }
        public int stock_actual { get; set; }
        public int stock_transito { get; set; }
        public string punto_distribucion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }

    }
}