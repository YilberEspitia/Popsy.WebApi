using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("ordenes_compras")]
    public class TblOrdenDeCompraEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid orden_compra_id { get; set; }
        [MaxLength(50)]
        public string orden_compra { get; set; } = default!;
        public DateTime fecha_orden_compra { get; set; }
        public bool recibida { get; set; } = false;
        #endregion

        #region Relaciones
        public Guid punto_venta_id { get; set; }
        [ForeignKey("punto_venta_id")]
        public TblPuntoVentaEntity punto_de_venta { get; set; } = default!;
        public Guid proveedor_recepcion_id { get; set; }
        [ForeignKey("proveedor_recepcion_id")]
        public TblProveedorRecepcionEntity proveedor_recepcion { get; set; } = default!;
        public virtual ISet<TblDetalleOrdenDeCompraEntity> detalles_ordenes_de_compra { get; protected set; } = new HashSet<TblDetalleOrdenDeCompraEntity>();
        public virtual ISet<TblRecepcionDeCompraEntity> recepciones_de_compra { get; protected set; } = new HashSet<TblRecepcionDeCompraEntity>();
        #endregion
    }
}