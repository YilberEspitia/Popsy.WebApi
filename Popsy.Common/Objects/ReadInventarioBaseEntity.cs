using System.ComponentModel.DataAnnotations;

namespace Popsy.Objects
{
    public class ReadInventarioBaseEntity
    {
        [Key]
        public string categoria_id { get; set; }
        public string categoria_nombre { get; set; }
        public List<ReadProductosEntity>? productos { get; set; }
    }
}