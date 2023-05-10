using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("determinar_compras_traslados")]
    public class TblDeterminarComprasTrasladosEntity
    {
        [Key]
        public Guid determinar_compra_traslado_id { get; set; }
        public Guid producto_id { get; set; }
        public Guid punto_Venta_id { get; set; }
        public int requiere_pedido_compra { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
}