using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("productos_pedidos")]
    public class TblProductoPedidoEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid producto_pedido_id { get; set; }
        public int cantidad { get; set; }
        public int stock_actual { get; set; }
        public int stock_transito { get; set; }
        public string? null_line { get; set; }
        public string? justificacion { get; set; }
        #endregion

        #region Relaciones
        public Guid producto_id { get; set; }
        [ForeignKey("producto_id")]
        public virtual TblProductoEntity producto { get; protected set; } = default!;
        public Guid pedido_id { get; set; }
        [ForeignKey("pedido_id")]
        public virtual TblPedidoEntity pedido { get; protected set; } = default!;
        #endregion
    }
}