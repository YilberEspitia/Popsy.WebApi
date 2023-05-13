using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("roles")]
    public class TblRolEntity
    {
        #region Atributos
        [Key]
        public Guid rol_id { get; set; }
        public string nombre { get; set; } = default!;
        public string descripcion { get; set; } = default!;
        public DateTime fecha_eliminacion { get; set; }
        #endregion

        #region Relaciones
        public virtual ISet<TblRolPermisoEntity> permisos { get; protected set; } = new HashSet<TblRolPermisoEntity>();
        public virtual ISet<TblUsuarioRolEntity> usuarios { get; protected set; } = new HashSet<TblUsuarioRolEntity>();
        #endregion
    }
}
