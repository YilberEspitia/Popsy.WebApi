namespace Popsy.Objects
{
    public class RecepcionDeCompraSave
    {
        #region Atributos
        public Guid usuario_id { get; set; }
        public Guid recepcion_compra_id { get; set; }
        public string numero_factura { get; set; } = default!;
        #endregion

        #region Relaciones
        public Guid orden_compra_id { get; set; }
        public IEnumerable<RecepcionDeCompraDetalleObject> recepciones_compras_detalles { get; set; } = new HashSet<RecepcionDeCompraDetalleObject>();
        #endregion
    }
}