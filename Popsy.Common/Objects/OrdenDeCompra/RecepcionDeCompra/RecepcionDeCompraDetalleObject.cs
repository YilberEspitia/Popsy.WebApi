namespace Popsy.Objects
{
    public class RecepcionDeCompraDetalleObject
    {
        #region Atributos
        public Guid recepcion_compra_detalle_id { get; set; }
        public int cantidad_recibida { get; set; }
        public string Unidad_presentacion_recibida { get; set; } = default!;
        #endregion

        #region Relaciones
        public Guid producto_id { get; set; }
        #endregion
    }
}