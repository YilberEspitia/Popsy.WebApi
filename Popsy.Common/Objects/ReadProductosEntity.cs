using System.ComponentModel.DataAnnotations;

namespace Popsy.Objects
{
    public class ReadProductosEntity
    {
        [Key]
        public Guid producto_id { get; set; }
        public string producto_nombre { get; set; }
        public int cantidad { get; set; }

        public List<ReadPresentacionEntity>? presentacion { get; set; }
    }
}