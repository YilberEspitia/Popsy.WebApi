namespace Popsy.Objects
{
    public class InventarioConteoObjectBasic
    {
        #region Atributos
        public Guid Producto_id { get; set; }
        public String? Nombre { get; set; }
        public Double Cantidad { get; set; }
        #endregion

        #region Relaciones
        public Guid Inventario_detalle_id { get; set; }
        #endregion
    }
}