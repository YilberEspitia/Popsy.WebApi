using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("recepciones_compras_detalle")]
    public class TblRecepcionDeCompraDetalleEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid recepcion_compra_detalle_id { get; set; }
        public int cantidad_recibida { get; set; }
        [MaxLength(50)]
        public string unidad_presentacion_recibida { get; set; } = default!;
        #endregion

        #region Relaciones
        public Guid recepcion_compra_id { get; set; }
        [ForeignKey("recepcion_compra_id")]
        public virtual TblRecepcionDeCompraEntity recepcion_compra { get; protected set; } = default!;
        public Guid producto_id { get; set; }
        [ForeignKey("producto_id")]
        public virtual TblProductoEntity producto { get; protected set; } = default!;
        #endregion
    }
}