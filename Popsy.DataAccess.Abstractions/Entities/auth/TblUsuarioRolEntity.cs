using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("usuarios_roles")]
    public class TblUsuarioRolEntity
    {
        #region Atributos
        [Key]
        public Guid usuario_rol_id { get; set; }
        public DateTime fecha_eliminacion { get; set; }
        #endregion

        #region Relaciones
        public Guid usuario_id { get; set; }
        [ForeignKey("usuario_id")]
        public virtual TblUsuarioEntity usuario { get; protected set; } = default!;
        public Guid rol_id { get; set; }
        [ForeignKey("rol_id")]
        public virtual TblRolEntity rol { get; protected set; } = default!;
        #endregion
    }
}
