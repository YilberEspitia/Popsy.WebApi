using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("productos_puntos_venta")]
    public class TblProductoPuntoVentaEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid producto_punto_venta_id { get; set; }
        public int cantidad_producto_maxima { get; set; }
        public int stock_actual { get; set; }
        public int stock_transito { get; set; }
        public string punto_distribucion { get; set; } = default!;
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