using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("productos_pedidos")]
    public class TblProductosPedidosEntity
    {
        [Key]
        public Guid producto_pedido_id { get; set; }
        public int cantidad { get; set; }
        public int stock_actual { get; set; }
        public int stock_transito { get; set; }
        public string? null_line { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public Guid producto_id { get; set; }
        public Guid pedido_id { get; set; }
        public string? justificacion { get; set; }
    }
}