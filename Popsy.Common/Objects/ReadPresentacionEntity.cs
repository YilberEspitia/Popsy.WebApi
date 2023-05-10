using System.ComponentModel.DataAnnotations;

namespace Popsy.Objects
{
    public class ReadPresentacionEntity
    {
        [Key]
        public string presentacion_id { get; set; }
        public string presentacion_nombre { get; set; }
        public bool unidad_minima { get; set; }
        public int cantidad_unidad_minima { get; set; }
    }
}