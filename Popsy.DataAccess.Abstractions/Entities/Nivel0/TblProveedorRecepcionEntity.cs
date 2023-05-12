using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("proveedores_recepcion")]
    public class TblProveedorRecepcionEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid proveedor_recepcion_id { get; set; }
        [MaxLength(50)]
        public string nombre { get; set; } = default!;
        [MaxLength(50)]
        public string codigo_sap_proveedor { get; set; } = default!;
        #endregion

        #region Relaciones
        public virtual ISet<TblOrdenDeCompraEntity> ordenes_de_compra { get; protected set; } = new HashSet<TblOrdenDeCompraEntity>();
        #endregion
    }
}