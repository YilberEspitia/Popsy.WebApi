using System.ComponentModel.DataAnnotations;

namespace Popsy.Entities
{
    public class VistaPedidosPuntoVentaEntity
    {
        [Key]
        public Guid pedido_id { get; set; }
        public Guid punto_venta_id { get; set; }
        public string codigo_punto_venta { get; set; }
        public string centro_cs { get; set; }
        public string almacen_cs { get; set; }
        public string doc_cs { get; set; }
        public string organizacion { get; set; }

    }
}