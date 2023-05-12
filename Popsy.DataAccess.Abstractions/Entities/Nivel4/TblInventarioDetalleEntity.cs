using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("inventariodetalle", Schema = "SIPOP")]
    public class TblInventarioDetalleEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid inventario_detalle_id { get; set; }
        public Guid producto_punto_venta_id { get; set; }
        public string minima_unidad { get; set; } = default!;
        public int cantidad { get; set; }
        #endregion

        #region Relaciones
        public Guid inventario_id { get; set; }
        [ForeignKey("inventario_id")]
        public TblInventarioEntity inventario { get; set; } = default!;
        public Guid bodega_id { get; set; }
        [ForeignKey("bodega_id")]
        public TblBodegaEntity bodega { get; set; } = default!;
        #endregion
    }
}