using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("Transacciones")]
    public class TblTransaccionEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid transaccion_id { get; set; }
        public string es_error { get; set; } = default!;
        public string codigo { get; set; } = default!;
        #endregion
        #region Relaciones
        public Guid tipo_transaccion_id { get; set; }
        [ForeignKey("tipo_transaccion_id")]
        public virtual TblTipoTransaccionEntity tipo_de_transaccion { get; protected set; } = default!;
        public Guid pedido_id { get; set; }
        [ForeignKey("pedido_id")]
        public virtual TblPedidoEntity pedido { get; protected set; } = default!;
        public virtual ISet<TblErrorTransaccionEntity> errores { get; protected set; } = new HashSet<TblErrorTransaccionEntity>();
        #endregion
    }
}
