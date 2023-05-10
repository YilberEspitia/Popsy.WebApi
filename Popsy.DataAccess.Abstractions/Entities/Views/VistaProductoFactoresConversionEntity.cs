using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("vistaproductofactoresconversion", Schema = "SIPOP")]
    public class VistaProductoFactoresConversionEntity
    {
        [Key]
        public Guid producto_factor_conversion_id { get; set; }
        public Guid producto_id { get; set; }
        public Guid factor_conversion_id { get; set; }
        public string unidad_base { get; set; }
        public int contador { get; set; }
        public string unidad_medida_alter { get; set; }


    }
}