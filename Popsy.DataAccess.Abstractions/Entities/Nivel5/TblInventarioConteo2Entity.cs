using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("inventario_conteo")]
    public class TblInventarioConteo2Entity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid inventario_conteo_id { get; set; }
        public Double cantidad { get; set; }
        public Boolean inicial { get; set; }
        public Boolean final { get; set; }
        #endregion

        #region Relaciones
        public Guid inventario_detalle_id { get; set; }
        [ForeignKey("inventario_detalle_id")]
        public virtual TblInventarioDetalle2Entity inventario_detalle { get; protected set; } = default!;
        #endregion
    }
}