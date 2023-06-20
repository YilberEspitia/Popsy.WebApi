using System.ComponentModel.DataAnnotations;

namespace Popsy.Objects
{
    public class InventarioBaseRead
    {
        [Key]
        public string categoria_id { get; set; }
        public string categoria_nombre { get; set; }
        public List<InventarioProductosRead>? productos { get; set; }
    }
}