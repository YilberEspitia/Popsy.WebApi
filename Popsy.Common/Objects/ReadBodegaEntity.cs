using System.ComponentModel.DataAnnotations;

namespace Popsy.Objects
{
    public class ReadBodegaEntity
    {
        [Key]
        public Guid bodega_id { get; set; }
        public string bodega_nombre { get; set; }
    }
}