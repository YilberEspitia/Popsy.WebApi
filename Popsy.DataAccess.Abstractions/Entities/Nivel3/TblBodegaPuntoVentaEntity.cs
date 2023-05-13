using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("bodegas_puntos_ventas")]
    public class TblBodegaPuntoVentaEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid bodega_punto_venta_id { get; set; }
        #endregion
        #region Relaciones
        public Guid bodegas_id { get; set; }
        [ForeignKey("bodegas_id")]
        public TblBodegaEntity bodega { get; set; } = default!;
        public Guid punto_venta_id { get; set; }
        [ForeignKey("punto_venta_id")]
        public TblPuntoVentaEntity punto_de_venta { get; set; } = default!;
        #endregion

    }
}
