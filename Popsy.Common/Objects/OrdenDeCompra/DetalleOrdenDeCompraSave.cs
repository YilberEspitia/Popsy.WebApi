namespace Popsy.Objects
{
    public class DetalleOrdenDeCompraSave
    {
        #region Atributos
        public Guid detalle_orden_compra_id { get; set; }
        public int cantidad_solicitada { get; set; }
        public String unidad_presentacion_solicitada { get; set; } = default!;
        public int posicion_producto { get; set; }
        public String? codigo_producto { get; set; }
        #endregion

        #region Relaciones
        public Guid orden_compra_id { get; set; }
        public Guid producto_id { get; set; }
        #endregion
    }
}