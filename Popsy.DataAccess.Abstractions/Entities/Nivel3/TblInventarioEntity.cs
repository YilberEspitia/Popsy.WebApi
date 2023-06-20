using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("inventarios", Schema = "SIPOP")]
    public class TblInventarioEntity
    {
        #region Atributos
        [Key]
        public Guid inventario_id { get; set; }
        public string codigo_inventario { get; set; } = default!;
        public DateTime fecha_toma_fisica { get; set; }
        public DateTime fecha_registro { get; set; }
        #endregion

        #region Relaciones
        public Guid usuario_id { get; set; }
        [ForeignKey("usuario_id")]
        public virtual TblUsuarioEntity usuario { get; protected set; } = default!;
        public Guid punto_venta_id { get; set; }
        [ForeignKey("punto_venta_id")]
        public virtual TblPuntoVentaEntity punto_de_venta { get; protected set; } = default!;
        public Guid tipo_inventario_id { get; set; }
        [ForeignKey("tipo_inventario_id")]
        public virtual TblTipoInventarioEntity tipo_inventario { get; protected set; } = default!;
        public virtual ISet<TblInventarioDetalleEntity> detalles { get; protected set; } = new HashSet<TblInventarioDetalleEntity>();
        #endregion
    }
}