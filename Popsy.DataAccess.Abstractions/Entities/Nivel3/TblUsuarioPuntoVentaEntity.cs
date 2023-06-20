using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("usuarios_puntos_ventas")]
    public class TblUsuarioPuntoVentaEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid usuario_punto_venta_id { get; set; }
        public Nullable<DateTime> fecha_eliminacion { get; set; }
        #endregion

        #region Relaciones
        public Guid usuario_id { get; set; }
        [ForeignKey("usuario_id")]
        public virtual TblUsuarioEntity usuario { get; protected set; } = default!;
        public Guid punto_venta_id { get; set; }
        [ForeignKey("punto_venta_id")]
        public virtual TblPuntoVentaEntity punto_de_venta { get; protected set; } = default!;
        #endregion
    }
}