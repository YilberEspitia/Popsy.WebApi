using System.ComponentModel.DataAnnotations;

namespace Popsy.Entities
{
    public class VistaCategoriasProductosEntity
    {
        [Key]
        public string categoria_id { get; set; }
        public string categoria_nombre { get; set; }
    }
}