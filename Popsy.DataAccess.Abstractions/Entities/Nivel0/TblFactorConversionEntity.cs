using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("factores_conversion")]
    public class TblFactorConversionEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid factor_conversion_id { get; set; }
        public string unidad_base { get; set; } = default!;
        public int contador { get; set; } = default!;
        public string unidad_medida_alter { get; set; } = default!;
        public string codigo_fc_sap { get; set; } = default!;
        #endregion

        #region Relaciones
        public virtual ISet<TblProductoFactorConversionEntity> factores_de_conversion { get; protected set; } = new HashSet<TblProductoFactorConversionEntity>();
        #endregion
    }
}
