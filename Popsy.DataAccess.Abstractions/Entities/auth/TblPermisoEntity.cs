using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("permisos")]
    public class TblPermisoEntity
    {
        #region Atributos
        [Key]
        public Guid permiso_id { get; set; }
        public string codigo { get; set; } = default!;
        public string descripcion { get; set; } = default!;
        public DateTime fecha_eliminacion { get; set; }
        #endregion

        #region Relaciones
        public virtual ISet<TblRolPermisoEntity> roles { get; protected set; } = new HashSet<TblRolPermisoEntity>();
        #endregion
    }
}
