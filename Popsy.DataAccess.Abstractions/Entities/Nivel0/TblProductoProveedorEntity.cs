using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("productos_proveedores")]
    public class TblProductoProveedorEntity : TblCreableEntity
    {
        [Key]
        public Guid productos_proveedores_id { get; set; }
        public string codigo_producto_sap { get; set; }
        public string codigo_proveedor_sap { get; set; }
    }
}
