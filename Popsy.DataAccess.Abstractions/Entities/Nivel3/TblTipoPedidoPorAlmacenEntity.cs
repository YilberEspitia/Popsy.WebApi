using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("tipo_pedidos_por_almacen")]
    public class TblTipoPedidoPorAlmacenEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid tipo_pedido_por_almacen_id { get; set; }
        public string codigo_almacen { get; set; } = default!;
        #endregion

        #region Relaciones
        public Guid punto_venta_id { get; set; }
        [ForeignKey("punto_venta_id")]
        public virtual TblPuntoVentaEntity punto_de_venta { get; protected set; } = default!;
        public Guid centro_logistico_id { get; set; }
        [ForeignKey("centro_logistico_id")]
        public virtual TblCentroLogisticoEntity centro_logistico { get; protected set; } = default!;
        public Guid tipo_pedido_compra_traslado_id { get; set; }
        [ForeignKey("tipo_pedido_compra_traslado_id")]
        public virtual TblTipoPedidoCompraTrasladoEntity tipo_pedido_compra_traslado { get; protected set; } = default!;
        #endregion
    }
}
