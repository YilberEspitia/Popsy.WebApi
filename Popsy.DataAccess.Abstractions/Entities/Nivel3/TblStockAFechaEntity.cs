using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("stock_fecha")]
    public class TblStockAFechaEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid stock_fecha_id { get; set; }
        public DateTime fecha { get; set; }
        public double cantidad { get; set; }
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