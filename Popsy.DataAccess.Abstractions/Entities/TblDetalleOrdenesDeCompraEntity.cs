using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("detalle_oden_compra")]
    public class TblDetalleOrdenesDeCompraEntity : TblCreatableEntity
    {
        [Key]
        public Guid id_recepcion_productos { get; set; }
        public int cantidad_solicitada { get; set; }
        /// <summary>
        /// Tabla de productos.
        /// </summary>
        public Guid id_producto { get; set; }
        /// <summary>
        /// Tabla de ordenes de compra
        /// </summary>
        public Guid id_orden_compra { get; set; }
        [MaxLength(50)]
        public String unidad_presentacion_solicitada { get; set; }

    }
}