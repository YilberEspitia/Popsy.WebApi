using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Popsy.Enums;

namespace Popsy.Entities
{
    [Table("recepciones_compras")]
    public class TblRecepcionDeCompraEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid recepcion_compra_id { get; set; }
        [MaxLength(50)]
        public string numero_factura { get; set; } = default!;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int constante { get; set; }
        public string codigo_recepcion_compra { get; set; } = default!;
        public SAPEstado estado { get; set; } = SAPEstado.Pendiente;
        #endregion

        #region Relaciones
        public Guid orden_compra_id { get; set; }
        [ForeignKey("orden_compra_id")]
        public virtual TblOrdenDeCompraEntity orden_de_compra { get; protected set; } = default!;
        public virtual ISet<TblRecepcionDeCompraDetalleEntity> recepciones_compras_detalles { get; protected set; } = new HashSet<TblRecepcionDeCompraDetalleEntity>();
        public virtual ISet<TblHistorialEnvioRecepcionDeCompraEntity> historial_envios { get; protected set; } = new HashSet<TblHistorialEnvioRecepcionDeCompraEntity>();
        public virtual ISet<TblResponseRecepcionDeCompraEntity> respuestas { get; protected set; } = new HashSet<TblResponseRecepcionDeCompraEntity>();
        #endregion
    }
}