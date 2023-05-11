using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("ordenes_compras")]
    public class TblOrdenesDeCompraEntity : TblCreatableEntity
    {
        [Key]
        public Guid id_orden_compra { get; set; }
        /// <summary>
        /// Tabla puntosventas
        /// </summary>
        public Guid id_punto_venta { get; set; }
        [MaxLength(50)]
        public String orden_compra { get; set; }
        /// <summary>
        /// Tabla proveedoesrecepcion
        /// </summary>
        public Guid id_proveedor_recepcion { get; set; }
        public DateTime fecha_orden_compra { get; set; }
        public DateTime Fecha_de_creacion { get; set; }
        public DateTime Fecha_de_modificacion { get; set; }

    }
}