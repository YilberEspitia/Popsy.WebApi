namespace Popsy.Objects
{
    public class OrdenDeCompraRead
    {
        #region Atributos
        public Guid orden_compra_id { get; set; }
        public String orden_compra { get; set; } = default!;
        public DateTime fecha_orden_compra { get; set; }
        #endregion

        #region Relaciones
        public ReadPuntoVenta punto_de_venta { get; set; } = default!;
        public ProveedorRecepcionObject proveedor_recepcion { get; set; } = default!;
        #endregion
    }
}