using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("inventariodetalle2")]
    public class TblInventarioDetalle2Entity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid inventario_detalle_id { get; set; }
        public String unidad { get; set; } = default!;
        public Double cantidad { get; set; }
        public String? unidad_consumo { get; set; }
        public Double? unidad_consumo_total { get; set; }
        public String? unidad_despacho { get; set; }
        public Double? unidad_despacho_total { get; set; }
        public String? unidad_conteo { get; set; }
        public Double? unidad_conteo_total { get; set; }
        public Boolean requiere_conteo { get; set; } = false;
        #endregion

        #region Relaciones
        public Guid inventario_id { get; set; }
        [ForeignKey("inventario_id")]
        public virtual TblInventario2Entity inventario { get; protected set; } = default!;
        public Guid bodega_id { get; set; }
        [ForeignKey("bodega_id")]
        public virtual TblBodegaEntity bodega { get; protected set; } = default!;
        public Guid producto_punto_venta_id { get; set; }
        public virtual ISet<TblInventarioConteo2Entity> conteos { get; protected set; } = new HashSet<TblInventarioConteo2Entity>();
        #endregion
    }
}