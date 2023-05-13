using System.ComponentModel.DataAnnotations;

namespace Popsy.Objects
{
    public class OrdenDeCompraSave
    {
        #region Atributos
        public Guid orden_compra_id { get; set; }
        public String orden_compra { get; set; } = default!;
        public DateTime fecha_orden_compra { get; set; }
        #endregion

        #region Relaciones
        [Required]
        public Guid punto_venta_id { get; set; }
        [Required]
        public Guid proveedor_recepcion_id { get; set; }
        public IEnumerable<DetalleOrdenDeCompraSave> detalles_ordenes_de_compra { get; set; } = new HashSet<DetalleOrdenDeCompraSave>();
        #endregion
    }
}