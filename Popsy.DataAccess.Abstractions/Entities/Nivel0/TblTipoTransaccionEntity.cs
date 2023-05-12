using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("tipos_transacciones")]
    public class TblTipoTransaccionEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid tipo_transaccion_id { get; set; }
        public string codigo { get; set; } = default!;
        public string descripcion { get; set; } = default!;
        #endregion

        #region Relaciones
        public virtual ISet<TblTransaccionEntity> transacciones { get; protected set; } = new HashSet<TblTransaccionEntity>();
        #endregion
    }
}
