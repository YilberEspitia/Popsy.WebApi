using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("productos")]
    public class TblProductosEntity
    {
        [Key]
        public Guid producto_id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string Categoria_Producto2 { get; set; }
        public string Categoria_Producto1 { get; set; }
    }
}