using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("recepciones_compras_respuesta")]
    public class TblResponseRecepcionDeCompraEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid recepcion_compra_respuesta_id { get; set; }
        public string? Type { get; set; }
        public string? Id { get; set; }
        public int? Number { get; set; }
        public string? Message { get; set; }
        public string? LogNo { get; set; }
        public int? LogMsgNo { get; set; }
        public string? MessageV1 { get; set; }
        public string? MessageV2 { get; set; }
        public string? MessageV3 { get; set; }
        public string? MessageV4 { get; set; }
        public string? Parameter { get; set; }
        public int? Row { get; set; }
        public string? Field { get; set; }
        public string? System { get; set; }
        public Int32 Orden { get; set; }
        public Boolean Activo { get; set; }
        #endregion

        #region Relaciones
        public Guid recepcion_compra_id { get; set; }
        [ForeignKey("recepcion_compra_id")]
        public virtual TblRecepcionDeCompraEntity recepcion_compra { get; protected set; } = default!;
        #endregion
    }
}