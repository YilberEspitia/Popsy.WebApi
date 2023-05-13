using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("recepciones_compras")]
    public class TblRecepcionDeCompraEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid recepcion_compra_id { get; set; }
        public int cantidad_recibida { get; set; }
        [MaxLength(50)]
        public string numero_factura { get; set; } = default!;
        [MaxLength(50)]
        public string Unidad_presentacion_recibida { get; set; } = default!;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int constante { get; set; }
        public string codigo_recepcion_compra { get; set; } = default!;
        #endregion

        #region Relaciones
        public Guid detalle_orden_compra_id { get; set; }
        [ForeignKey("detalle_orden_compra_id")]
        public virtual TblDetalleOrdenDeCompraEntity detalle_orden_de_compra { get; protected set; } = default!;
        #endregion
    }
}