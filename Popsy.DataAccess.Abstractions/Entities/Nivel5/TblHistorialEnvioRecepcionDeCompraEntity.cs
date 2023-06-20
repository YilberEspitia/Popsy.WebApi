using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("historial_envio_recepciones_compras")]
    public class TblHistorialEnvioRecepcionDeCompraEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid historial_envio_recepciones_compras_id { get; set; }
        public String? XML { get; set; }
        #endregion

        #region Relaciones
        public Guid recepcion_compra_id { get; set; }
        [ForeignKey("recepcion_compra_id")]
        public virtual TblRecepcionDeCompraEntity recepcion_compra { get; protected set; } = default!;
        #endregion
    }
}