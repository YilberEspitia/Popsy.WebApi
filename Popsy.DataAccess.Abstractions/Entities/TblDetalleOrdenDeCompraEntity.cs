using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("detalle_oden_compra")]
    public class TblDetalleOrdenDeCompraEntity
    {
        [Key]
        public Guid id_recepcion_productos { get; set; }
        public int cantidad_solicitada { get; set; }
        public Guid id_producto { get; set; }
        public Guid id_orden_compra { get; set; }
        public String unidad_presentacion_solicitada { get; set; }

    }
}