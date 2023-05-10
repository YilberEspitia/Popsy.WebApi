using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("vistaresumeninventario", Schema = "SIPOP")]
    public class VistaResumenInventarioEntity
    {
        [Key]
        public Guid inventario_detalle_id { get; set; }
        public Guid inventario_id { get; set; }
        public Guid producto_id { get; set; }
        public Guid usuario_id { get; set; }
        public Guid punto_venta_id { get; set; }
        public string usuario { get; set; }
        public string nombre_punto_venta { get; set; }
        public string nombre_producto { get; set; }
        public int cantidad { get; set; }

    }
}