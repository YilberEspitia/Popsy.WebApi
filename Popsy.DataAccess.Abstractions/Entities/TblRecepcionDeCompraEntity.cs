using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("recepcion_compra")]
    public class TblRecepcionDeCompraEntity
    {
        [Key]
        public Guid id_proveedor { get; set; }
        public Guid id_detalle_orden_compra { get; set; }
        public int cantidad_recibida { get; set; }
        public int numero_factura { get; set; }
        public String Unidad_presentacion_recibida { get; set; }
        public DateTime Fecha_de_creacion { get; set; }
        public DateTime Fecha_de_modificacion { get; set; }

    }
}