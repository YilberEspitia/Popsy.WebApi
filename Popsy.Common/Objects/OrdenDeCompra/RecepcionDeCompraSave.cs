namespace Popsy.Objects
{
    public class RecepcionDeCompraSave
    {
        #region Atributos
        public Guid recepcion_compra_id { get; set; }
        public int cantidad_recibida { get; set; }
        public string numero_factura { get; set; } = default!;
        public string Unidad_presentacion_recibida { get; set; } = default!;
        #endregion

        #region Relaciones
        public Guid detalle_orden_compra_id { get; set; }
        #endregion
    }
}