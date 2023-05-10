using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("vistaproductosparainventario", Schema = "SIPOP")]
    public class VistaProductosParaInventarioEntity
    {
        [Key]
        public Guid producto_punto_venta_id { get; set; }
        public Guid punto_venta_id { get; set; }
        public Guid producto_id { get; set; }
        public string nombre_punto_venta { get; set; }
        public int cantidad_producto_maxima { get; set; }
        public int stock_actual { get; set; }
        public string presentacion { get; set; }
        public string minima_unidad { get; set; }
        public string categoria_producto { get; set; }
        public string factor_conversion { get; set; }
        public string categoria_id { get; set; }
        public string nombre_producto { get; set; }
        public int contador { get; set; }
        public string unidad_base { get; set; }
        public string unidad_medida_alter { get; set; }
    }
}