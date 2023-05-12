using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("organizaciones_ventas")]
    public class TblOrganizacionVentaEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid organizacion_venta_id { get; set; }
        public string nombre { get; set; } = default!;
        public string codigo { get; set; } = default!;
        #endregion
        #region Relaciones
        public virtual ISet<TblDistritoEntity> distritos { get; protected set; } = new HashSet<TblDistritoEntity>();
        #endregion
    }
}
