namespace Popsy.Objects
{
    public class ResponseRecepcionDeCompraObject
    {
        #region Atributos
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
        #endregion
    }
}