using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("stock_teorico_inventarios_dos")]
    public class TblStockTeoricoInventariosDos : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid stock_teorico_inventarios_dos_id { get; set; }
        public double stock_teorico { get; set; } = default!;
        #endregion

        #region Relaciones
        public Guid producto_id { get; set; }
        [ForeignKey("producto_id")]
        public virtual TblProductoEntity producto { get; protected set; } = default!;
        public Guid punto_venta_id { get; set; }
        [ForeignKey("punto_venta_id")]
        public virtual TblPuntoVentaEntity punto_de_venta { get; protected set; } = default!;
        #endregion
    }
}