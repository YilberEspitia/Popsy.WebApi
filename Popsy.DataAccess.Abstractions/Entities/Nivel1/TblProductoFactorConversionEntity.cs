using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("productos_factores_conversion")]
    public class TblProductoFactorConversionEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid producto_factor_conversion_id { get; set; }
        #endregion
        #region Relaciones
        public Guid producto_id { get; set; }
        [ForeignKey("producto_id")]
        public virtual TblProductoEntity producto { get; protected set; } = default!;
        public Guid factor_conversion_id { get; set; }
        [ForeignKey("factor_conversion_id")]
        public virtual TblFactorConversionEntity factor_conversion { get; protected set; } = default!;
        #endregion
    }
}
