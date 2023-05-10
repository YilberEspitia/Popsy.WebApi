using System.ComponentModel.DataAnnotations;

namespace Popsy.Objects
{
    public class ReadXMLPedidosSAPEntity
    {
        [Key]
        public Guid producto_id { get; set; }
        public Guid pedido_id { get; set; }
        public string codigo_producto_sap { get; set; }
        public string codigo_proveedor_sap { get; set; }
    }
}