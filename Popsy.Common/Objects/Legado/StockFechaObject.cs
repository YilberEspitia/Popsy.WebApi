using System.ComponentModel.DataAnnotations;

namespace Popsy.Objects
{
    public class StockFechaObject
    {
        #region Atributos
        public Guid stock_fecha_id { get; set; }
        public DateTime fecha { get; set; }
        public double cantidad { get; set; }
        #endregion

        #region Relaciones
        [Required]
        public Guid producto_id { get; set; }
        [Required]
        public Guid punto_venta_id { get; set; }
        #endregion
    }
}