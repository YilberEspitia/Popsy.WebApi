using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("proveedor_recepcion")]
    public class TblProveedorRecepcionEntity
    {
        [Key]
        public Guid id_proveedor { get; set; }
        public string nombre { get; set; }
        public string codigo_sap_proveedor { get; set; }
        public Guid id_producto { get; set; }
        public Guid id_punto_de_venta { get; set; }
        public String codigo_sap_producto { get; set; }

    }
}