using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("historial_usuarios")]
    public class TblHistorialUsuarioEntity
    {
        #region Atributos
        [Key]
        public Guid historial_usuario_id { get; set; }
        public string observacion { get; set; } = default!;
        public DateTime fecha_eliminacion { get; set; }
        #endregion

        #region Relaciones
        public Guid autor_id { get; set; }
        [ForeignKey("autor_id")]
        public virtual TblUsuarioEntity autor { get; protected set; } = default!;
        public Guid usuario_modificado_id { get; set; }
        #endregion
    }
}
