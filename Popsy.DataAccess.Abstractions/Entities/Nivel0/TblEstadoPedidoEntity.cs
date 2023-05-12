using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("estados_pedidos")]
    public class TblEstadoPedidoEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid estado_pedido_id { get; set; }
        public string codigo { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string descripcion { get; set; } = default!;
        #endregion

        #region Relaciones
        public virtual ISet<TblPedidoEntity> pedidos { get; protected set; } = new HashSet<TblPedidoEntity>();
        #endregion
    }
}
