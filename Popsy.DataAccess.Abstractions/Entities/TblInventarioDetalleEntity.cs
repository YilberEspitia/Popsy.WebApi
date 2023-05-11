using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("inventariodetalle", Schema = "SIPOP")]
    public class TblInventarioDetalleEntity : TblCreatableEntity
    {
        [Key]
        public Guid inventario_detalle_id { get; set; }
        public Guid inventario_id { get; set; }
        public Guid producto_punto_venta_id { get; set; }
        public Guid bodega_id { get; set; }
        public string minima_unidad { get; set; }
        public int cantidad { get; set; }
    }
}