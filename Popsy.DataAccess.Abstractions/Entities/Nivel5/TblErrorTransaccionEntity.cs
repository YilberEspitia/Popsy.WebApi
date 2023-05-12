using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("errores_transacciones")]
    public class TblErrorTransaccionEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid error_transaccion_id { get; set; }
        public string datos_enviados { get; set; } = default!;
        public string datos_recibidos { get; set; } = default!;
        #endregion
        #region Relaciones
        public Guid transaccion_id { get; set; }
        [ForeignKey("transaccion_id")]
        public virtual TblTransaccionEntity transaccion { get; protected set; } = default!;
        #endregion
    }
}
