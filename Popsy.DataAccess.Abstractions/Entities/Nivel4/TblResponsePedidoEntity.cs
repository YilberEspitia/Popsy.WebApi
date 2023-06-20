using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("respuestas_pedidos_sap")]
    public class TblResponsePedidoEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid respuesta_pedido_sap_id { get; set; }
        public string type { get; set; } = default!;
        public string code { get; set; } = default!;
        public string message { get; set; } = default!;
        public string log_no { get; set; } = default!;
        public string? log_msg_no { get; set; }
        public string message_v1 { get; set; } = default!;
        public string? message_v2 { get; set; }
        public string? message_v3 { get; set; }
        public string? message_v4 { get; set; }
        #endregion

        #region Relaciones
        public Guid pedido_id { get; set; }
        [ForeignKey("pedido_id")]
        public virtual TblPedidoEntity pedido { get; protected set; } = default!;
        #endregion
    }
}