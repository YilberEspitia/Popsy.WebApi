using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("recepciones_compras")]
    public class TblRecepcionDeCompraEntity : TblCreatableEntity
    {
        [Key]
        public Guid id_proveedor { get; set; }
        /// <summary>
        /// Tabla detalle orden de compra
        /// </summary>
        public Guid id_detalle_orden_compra { get; set; }
        public int cantidad_recibida { get; set; }
        [MaxLength(50)]
        public String numero_factura { get; set; }
        [MaxLength(50)]
        public String Unidad_presentacion_recibida { get; set; }
    }
}