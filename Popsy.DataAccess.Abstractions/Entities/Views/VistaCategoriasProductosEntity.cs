using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("vistacategoriasproductos", Schema = "SIPOP")]
    public class VistaCategoriasProductosEntity
    {
        [Key]
        public string categoria_id { get; set; }
        public string categoria_nombre { get; set; }
    }
}