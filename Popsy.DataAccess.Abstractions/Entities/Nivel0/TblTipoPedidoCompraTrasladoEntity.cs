using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("tipos_pedidos_compras_traslados")]
    public class TblTipoPedidoCompraTrasladoEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid tipo_pedido_compra_traslado_id { get; set; }
        [MaxLength(50)]
        public string codigo_tipo_pedido_sap { get; set; } = default!;
        [MaxLength(50)]
        public string nombre_tipo_pedido { get; set; } = default!;
        [MaxLength(50)]
        public string documento_tipo_pedido { get; set; } = default!;
        #endregion

        #region Relaciones
        public virtual ISet<TblTipoPedidoPorAlmacenEntity> tipos_de_pedido_por_almacen { get; protected set; } = new HashSet<TblTipoPedidoPorAlmacenEntity>();
        #endregion
    }
}
