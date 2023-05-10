using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("puntos_ventas")]
    public class TblPuntosVentasEntity
    {
        [Key]
        public Guid punto_venta_id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }

    }
}