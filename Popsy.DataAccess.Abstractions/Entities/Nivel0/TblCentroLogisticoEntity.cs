using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("centros_logisticos")]
    public class TblCentroLogisticoEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid centros_logisticos_id { get; set; }
        [MaxLength(10)]
        public string codigo_cedi_sap { get; set; } = default!;
        [MaxLength(50)]
        public string nombre_cedi_sap { get; set; } = default!;
        #endregion

        #region Relaciones
        public virtual ISet<TblTipoPedidoPorAlmacenEntity> tipos_de_pedido_por_almacen { get; protected set; } = new HashSet<TblTipoPedidoPorAlmacenEntity>();
        #endregion
    }
}
