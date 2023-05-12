using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("distritos")]
    public class TblDistritoEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid distrito_id { get; set; }
        public string nombre { get; set; } = default!;
        public string codigo { get; set; } = default!;
        #endregion
        #region Relaciones
        public Guid organizacion_venta_id { get; set; }
        [ForeignKey("organizacion_venta_id")]
        public virtual TblOrganizacionVentaEntity organizacion_venta { get; protected set; } = default!;
        public virtual ISet<TblPuntoVentaEntity> puntos_de_venta { get; protected set; } = new HashSet<TblPuntoVentaEntity>();
        #endregion
    }
}
