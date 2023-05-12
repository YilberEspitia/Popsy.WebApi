using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("tipo_pedido")]
    public class TblTipoPedidoEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid tipo_pedido_id { get; set; }
        public string nombre { get; set; } = default!;
        #endregion

        #region Relaciones
        public virtual ISet<TblPedidoEntity> pedidos { get; protected set; } = new HashSet<TblPedidoEntity>();
        #endregion
    }
}
