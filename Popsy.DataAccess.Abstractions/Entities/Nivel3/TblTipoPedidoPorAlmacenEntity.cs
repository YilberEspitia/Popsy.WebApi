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
        public TblPuntoVentaEntity punto_de_venta { get; set; }
        public Guid centro_logistico_id { get; set; }
        [ForeignKey("centro_logistico_id")]
        public TblCentroLogisticoEntity centro_logistico { get; set; }
        public Guid tipo_pedido_compra_traslado_id { get; set; }
        [ForeignKey("tipo_pedido_compra_traslado_id")]
        public TblTipoPedidoCompraTrasladoEntity tipo_pedido_compra_traslado { get; set; }
        #endregion
    }
}
