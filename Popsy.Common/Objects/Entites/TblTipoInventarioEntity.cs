using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("tipoinventario", Schema = "SIPOP")]
    public class TblTipoInventarioEntity
    {
        [Key]
        public Guid tipo_inventario_id { get; set; }
        public string nombre_tipo_inventario { get; set; }
        public string abreviatura_inventario { get; set; }
    }
}