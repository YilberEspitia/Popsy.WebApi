using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("roles_permisos")]
    public class TblRolPermisoEntity
    {
        #region Atributos
        [Key]
        public Guid rol_permiso_id { get; set; }
        public DateTime fecha_eliminacion { get; set; }
        #endregion

        #region Relaciones
        public Guid rol_id { get; set; }
        [ForeignKey("rol_id")]
        public virtual TblRolEntity rol { get; protected set; } = default!;
        public Guid permiso_id { get; set; }
        [ForeignKey("permiso_id")]
        public virtual TblPermisoEntity permiso { get; protected set; } = default!;
        #endregion
    }
}
