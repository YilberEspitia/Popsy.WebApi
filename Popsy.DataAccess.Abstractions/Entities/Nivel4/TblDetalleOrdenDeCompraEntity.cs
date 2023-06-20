using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("detalle_orden_compra")]
    public class TblDetalleOrdenDeCompraEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid detalle_orden_compra_id { get; set; }
        public int cantidad_solicitada { get; set; }
        [MaxLength(50)]
        public String unidad_presentacion_solicitada { get; set; } = default!;
        public int posicion_producto { get; set; }
        public bool activo { get; set; }
        #endregion

        #region Relaciones
        public Guid producto_id { get; set; }
        [ForeignKey("producto_id")]
        public virtual TblProductoEntity producto { get; protected set; } = default!;
        public Guid orden_compra_id { get; set; }
        [ForeignKey("orden_compra_id")]
        public virtual TblOrdenDeCompraEntity orden_de_compra { get; protected set; } = default!;
        #endregion
    }
}