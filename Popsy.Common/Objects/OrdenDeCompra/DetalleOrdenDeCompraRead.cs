namespace Popsy.Objects
{
    public class DetalleOrdenDeCompraRead : DetalleOrdenDeCompraSave
    {
        #region Relaciones
        public ReadProductosEntity producto { get; set; } = default!;
        #endregion
    }
}