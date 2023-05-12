using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("bodegas")]
    public class TblBodegaEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid bodega_id { get; set; }
        [MaxLength(100)]
        public string nombre_bodega { get; set; } = default!;
        [MaxLength(30)]
        public string codigo_sap { get; set; } = default!;
        #endregion
        #region Relaciones
        public virtual ISet<TblBodegaPuntoVentaEntity> puntos_de_venta { get; protected set; } = new HashSet<TblBodegaPuntoVentaEntity>();
        public virtual ISet<TblInventarioDetalleEntity> inventario_detalles { get; protected set; } = new HashSet<TblInventarioDetalleEntity>();
        #endregion
    }
}
