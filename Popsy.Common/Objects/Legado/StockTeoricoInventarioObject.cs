using System.ComponentModel.DataAnnotations;

namespace Popsy.Objects
{
    public class StockTeoricoInventarioObject
    {
        #region Atributos
        public Guid stock_teorico_inventarios_dos_id { get; set; }
        public double stock_teorico { get; set; } = default!;
        #endregion

        #region Relaciones
        [Required]
        public Guid producto_id { get; set; }
        [Required]
        public Guid punto_venta_id { get; set; }
        #endregion
    }
}