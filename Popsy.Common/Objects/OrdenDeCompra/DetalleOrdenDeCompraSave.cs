namespace Popsy.Objects
{
    public class DetalleOrdenDeCompraSave
    {
        #region Atributos
        public Guid detalle_orden_compra_id { get; set; }
        public int cantidad_solicitada { get; set; }
        public String unidad_presentacion_solicitada { get; set; } = default!;
        #endregion

        #region Relaciones
        public Guid producto_id { get; set; }
        #endregion
    }
}