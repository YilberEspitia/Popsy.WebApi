namespace Popsy.Objects
{
    public class DetalleOrdenDeCompraRead : DetalleOrdenDeCompraSave
    {
        #region Relaciones
        public ReadProductosEntity producto { get; set; } = default!;
        public Guid orden_compra_id { get; set; }
        #endregion
    }
}