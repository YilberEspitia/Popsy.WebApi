using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("orden_compra")]
    public class TblOrdenDeCompraEntity
    {
        [Key]
        public Guid id_orden_compra { get; set; }
        public Guid id_punto_venta { get; set; }
        public String orden_compra { get; set; }
        public Guid id_proveedor { get; set; }
        public DateTime fecha_orden_compra { get; set; }

    }
}