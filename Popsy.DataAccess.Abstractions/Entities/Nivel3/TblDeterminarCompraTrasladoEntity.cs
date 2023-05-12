using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("determinar_compras_traslados")]
    public class TblDeterminarCompraTrasladoEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid determinar_compra_traslado_id { get; set; }
        public int requiere_pedido_compra { get; set; }
        #endregion

        #region Relaciones
        public Guid producto_id { get; set; }
        [ForeignKey("producto_id")]
        public virtual TblProductoEntity producto { get; protected set; } = default!;
        public Guid punto_Venta_id { get; set; }
        [ForeignKey("punto_Venta_id")]
        public virtual TblPuntoVentaEntity punto_de_venta { get; protected set; } = default!;
        #endregion
    }
}