using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("inventariodetalle", Schema = "SIPOP")]
    public class TblInventarioDetalleEntity
    {
        #region Atributos
        [Key]
        public Guid inventario_detalle_id { get; set; }
        public Guid producto_punto_venta_id { get; set; }
        public string minima_unidad { get; set; } = default!;
        public double cantidad { get; set; }
        #endregion

        #region Relaciones
        public Guid inventario_id { get; set; }
        [ForeignKey("inventario_id")]
        public virtual TblInventarioEntity inventario { get; protected set; } = default!;
        public Guid bodega_id { get; set; }
        [ForeignKey("bodega_id")]
        public virtual TblBodegaEntity bodega { get; protected set; } = default!;
        #endregion
    }
}