using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("proveedores_recepcion")]
    public class TblProveedoresRecepcionEntity : TblCreatableEntity
    {
        [Key]
        public Guid id_proveedor { get; set; }
        [MaxLength(50)]
        public string nombre { get; set; }
        [MaxLength(50)]
        public string codigo_sap_proveedor { get; set; }
    }
}