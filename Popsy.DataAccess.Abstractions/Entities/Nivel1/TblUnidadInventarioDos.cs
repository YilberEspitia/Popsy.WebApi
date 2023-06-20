using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Popsy.Entities
{
    [Table("unidades_inventarios_dos")]
    [Index(nameof(producto_id), IsUnique = true)]
    public class TblUnidadInventarioDos : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid unidad_inventario_dos_id { get; set; }
        public String unidad_consumo { get; set; }
        public String unidad_despacho { get; set; }
        public String unidad_conteo { get; set; }
        #endregion
        #region Relaciones
        public Guid producto_id { get; set; }
        [ForeignKey("producto_id")]
        public virtual TblProductoEntity producto { get; protected set; } = default!;
        #endregion
    }
}
